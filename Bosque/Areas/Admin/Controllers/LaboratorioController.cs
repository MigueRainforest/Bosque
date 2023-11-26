using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using Bosque.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Bosque.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LaboratorioController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public LaboratorioController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Laboratorio laboratorio = new Laboratorio();

            if (id == null)
            {
                // Crear una nuevo Lab               
                return View(laboratorio);
            }
            // Actualizamos Lab
            laboratorio = await _unidadTrabajo.Laboratorio.Obtener(id.GetValueOrDefault());
            if (laboratorio == null)
            {
                return NotFound();
            }
            return View(laboratorio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                if (laboratorio.Id == 0)
                {
                    await _unidadTrabajo.Laboratorio.Agregar(laboratorio);
                    TempData[DS.Exitosa] = "Laboratorio creado Exitosamente";
                    
                }
                else
                {
                    _unidadTrabajo.Laboratorio.Actualizar(laboratorio);
                    TempData[DS.Exitosa] = "Laboratorio actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Laboratorio";
            return View(laboratorio);
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Laboratorio.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var laboratorioDb = await _unidadTrabajo.Laboratorio.Obtener(id);
            if (laboratorioDb == null)
            {
                return Json(new { success = false, message = "Error al borrar laboratorio" });
            }
            _unidadTrabajo.Laboratorio.Remover(laboratorioDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Laboratorio borrado exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Laboratorio.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });

        }

        #endregion

    }
}
