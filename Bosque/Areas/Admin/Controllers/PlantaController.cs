using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using Bosque.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Bosque.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PlantaController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public PlantaController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Planta planta = new Planta();

            if (id == null)
            {
                // Crear una nueva especie            
                return View(planta);
            }
            // Actualizamos especie
            planta = await _unidadTrabajo.Planta.Obtener(id.GetValueOrDefault());
            if (planta == null)
            {
                return NotFound();
            }
            return View(planta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Planta planta)
        {
            if (ModelState.IsValid)
            {
                if (planta.Id == 0)
                {
                    await _unidadTrabajo.Planta.Agregar(planta);
                    TempData[DS.Exitosa] = "Especie creada Exitosamente";
                    
                }
                else
                {
                    _unidadTrabajo.Planta.Actualizar(planta);
                    TempData[DS.Exitosa] = "Especie actualizada Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Especie";
            return View(planta);
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Planta.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var plantaDb = await _unidadTrabajo.Planta.Obtener(id);
            if (plantaDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Especie" });
            }
            _unidadTrabajo.Planta.Remover(plantaDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Especie borrada exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombreComun, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Planta.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.NombreComun.ToLower().Trim() == nombreComun.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.NombreComun.ToLower().Trim() == nombreComun.ToLower().Trim() && b.Id != id);
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
