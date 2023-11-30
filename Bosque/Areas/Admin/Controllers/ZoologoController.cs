using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using Bosque.Modelos.ViewModels;
using Bosque.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Bosque.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ZoologoController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;        

        public ZoologoController(IUnidadTrabajo unidadTrabajo) 
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {

            ZoologoVM zoologoVM = new ZoologoVM()
            {
                Zoologo = new Zoologo(),
                PersonalLista = _unidadTrabajo.Zoologo.ObtenerTodosDropdownLista("Personal")

            };

            if (id == null)
            {
                // Crear nuevo Zoologo               
                return View(zoologoVM);
            }
            else
            {
                zoologoVM.Zoologo = await _unidadTrabajo.Zoologo.Obtener(id.GetValueOrDefault());
                if (zoologoVM.Zoologo == null)
                {
                    return NotFound();
                }
                return View(zoologoVM);
            }
        }


        /* -------------------------------------------------------------------- */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(ZoologoVM zoologoVM)
        {
            if (ModelState.IsValid)
            {
                if (zoologoVM.Zoologo.Id == 0)
                {
                    //Cear Zoologo
                    await _unidadTrabajo.Zoologo.Agregar(zoologoVM.Zoologo);
                    TempData[DS.Exitosa] = "Zoólogo creado Exitosamente";
                    
                }
                else
                {
                    //Actualizar Zoólogo
                    _unidadTrabajo.Zoologo.Actualizar(zoologoVM.Zoologo);
                    TempData[DS.Exitosa] = "Zoólogo actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Zoólogo";
            return View(zoologoVM);
        } 

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Zoologo.ObtenerTodos(incluirPropiedades:"Personal");
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var zoologoDb = await _unidadTrabajo.Zoologo.Obtener(id);
            if (zoologoDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Zoologo" });
            }
            _unidadTrabajo.Zoologo.Remover(zoologoDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Zoologo borrado exitosamente" });
        }

        [ActionName("ValidarCedula")]
        public async Task<IActionResult> ValidarCedula(string cedula, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Zoologo.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Cedula.ToLower().Trim() == cedula.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Cedula.ToLower().Trim() == cedula.ToLower().Trim() && b.Id != id);
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
