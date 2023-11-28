using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using Bosque.Modelos.ViewModels;
using Bosque.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Bosque.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BotanicoController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;        

        public BotanicoController(IUnidadTrabajo unidadTrabajo) 
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> Upsert(int? id)
        {

            BotanicoVM botanicoVM = new BotanicoVM()
            {
                Botanico = new Botanico(),
                PersonalLista = _unidadTrabajo.Botanico.ObtenerTodosDropdownLista("Personal")

            };

            if (id == null)
            {
                // Crear nuevo Botanico               
                return View(botanicoVM);
            }
            else
            {
                botanicoVM.Botanico = await _unidadTrabajo.Botanico.Obtener(id.GetValueOrDefault());
                if (botanicoVM.Botanico == null)
                {
                    return NotFound();
                }
                return View(botanicoVM);
            }
        }


        /* -------------------------------------------------------------------- */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(BotanicoVM botanicoVM)
        {
            if (ModelState.IsValid)
            {
                if (botanicoVM.Botanico.Id == 0)
                {
                    //Cear Botanico
                    await _unidadTrabajo.Botanico.Agregar(botanicoVM.Botanico);
                    TempData[DS.Exitosa] = "Botánico creado Exitosamente";
                    
                }
                else
                {
                    //Actualizar Botanico
                    _unidadTrabajo.Botanico.Actualizar(botanicoVM.Botanico);
                    TempData[DS.Exitosa] = "Botanico actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Botanico";
            return View(botanicoVM);
        } 

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Botanico.ObtenerTodos(incluirPropiedades:"Personal");
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var botanicoDb = await _unidadTrabajo.Botanico.Obtener(id);
            if (botanicoDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Botanico" });
            }
            _unidadTrabajo.Botanico.Remover(botanicoDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Botanico borrado exitosamente" });
        }

        [ActionName("ValidarCedula")]
        public async Task<IActionResult> ValidarCedula(string cedula, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Botanico.ObtenerTodos();
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
