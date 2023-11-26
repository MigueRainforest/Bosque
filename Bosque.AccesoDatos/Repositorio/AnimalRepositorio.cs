using Bosque.AccesoDatos.Data;
using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio
{
    public class AnimalRepositorio : Repositorio<Animal>, IAnimalRepositorio  //"Repositorio es genérico, así que le podemos pasar cualquier objeto"
    {
        private readonly ApplicationDbContext _db;

        public AnimalRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Animal animal)
        {
            var animalBD = _db.Animales.FirstOrDefault(b => b.Id == animal.Id);
            if (animalBD != null)
            {
                animalBD.NombreComun = animal.NombreComun;
                animalBD.NombreCientifico = animal.NombreCientifico;
                animalBD.EstatusAmenaza = animal.EstatusAmenaza;
                animalBD.Dieta = animal.Dieta;
                _db.SaveChanges();
            }
        }
    }
}
