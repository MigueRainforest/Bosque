using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using Bosque.Modelos.ViewModels;
using Bosque.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Bosque.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonalController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;
        //private readonly IWebHostEnvironment _webHostEnvironment;

        public PersonalController(IUnidadTrabajo unidadTrabajo) //, IWebHostEnvironment webHostEnvironment
        {
            _unidadTrabajo = unidadTrabajo;
            //_webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*
        public async Task<IActionResult> Upsert(int? id)
        {
            Personal personal = new Personal();

            if (id == null)
            {
                // Crear nuevo personal (Profesión)              
                return View(personal);
            }
            // Actualizamos personal
            personal = await _unidadTrabajo.Personal.Obtener(id.GetValueOrDefault());
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        } */

        public async Task<IActionResult> Upsert(int? id)
        {

            PersonalVM personalVM = new PersonalVM()
            {
                Personal = new Personal(),
                LaboratorioLista = _unidadTrabajo.Personal.ObtenerTodosDropdownLista("Laboratorio")

            };

            if (id == null)
            {
                // Crear nuevo Personal                
                return View(personalVM);
            }
            else
            {
                personalVM.Personal = await _unidadTrabajo.Personal.Obtener(id.GetValueOrDefault());
                if (personalVM.Personal == null)
                {
                    return NotFound();
                }
                return View(personalVM);
            }
        }


        /* -------------------------------------------------------------------- */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(PersonalVM personalVM)
        {
            if (ModelState.IsValid)
            {
                if (personalVM.Personal.Id == 0)
                {
                    //Cear Personal
                    await _unidadTrabajo.Personal.Agregar(personalVM.Personal);
                    TempData[DS.Exitosa] = "Personal creado Exitosamente";
                    
                }
                else
                {
                    //Actualizar Personal
                    _unidadTrabajo.Personal.Actualizar(personalVM.Personal);
                    TempData[DS.Exitosa] = "Personal actualizado Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Personal";
            return View(personalVM);
        } 

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Personal.ObtenerTodos(incluirPropiedades:"Laboratorio");
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var personalDb = await _unidadTrabajo.Personal.Obtener(id);
            if (personalDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Personal" });
            }
            _unidadTrabajo.Personal.Remover(personalDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Personal borrado exitosamente" });
        }

        [ActionName("ValidarEspecialidad")]
        public async Task<IActionResult> ValidarEspecialidad(string especialidad, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Personal.ObtenerTodos();
            if (id == 0)
            {
                valor = lista.Any(b => b.Especialidad.ToLower().Trim() == especialidad.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Especialidad.ToLower().Trim() == especialidad.ToLower().Trim() && b.Id != id);
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
