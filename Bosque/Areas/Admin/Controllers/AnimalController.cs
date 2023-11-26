using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using Bosque.Utilidades;
using Microsoft.AspNetCore.Mvc;

namespace Bosque.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnimalController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;

        public AnimalController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Animal animal = new Animal();

            if (id == null)
            {
                // Crear una nueva especie            
                return View(animal);
            }
            // Actualizamos especie
            animal = await _unidadTrabajo.Animal.Obtener(id.GetValueOrDefault());
            if (animal == null)
            {
                return NotFound();
            }
            return View(animal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Animal animal)
        {
            if (ModelState.IsValid)
            {
                if (animal.Id == 0)
                {
                    await _unidadTrabajo.Animal.Agregar(animal);
                    TempData[DS.Exitosa] = "Especie creada Exitosamente";
                    
                }
                else
                {
                    _unidadTrabajo.Animal.Actualizar(animal);
                    TempData[DS.Exitosa] = "Especie actualizada Exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar Especie";
            return View(animal);
        }

        #region API

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Animal.ObtenerTodos();
            return Json(new { data = todos });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var animalDb = await _unidadTrabajo.Animal.Obtener(id);
            if (animalDb == null)
            {
                return Json(new { success = false, message = "Error al borrar Especie" });
            }
            _unidadTrabajo.Animal.Remover(animalDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Especie borrada exitosamente" });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombreComun, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Animal.ObtenerTodos();
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
