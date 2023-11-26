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
    public class PlantaRepositorio : Repositorio<Planta>, IPlantaRepositorio  //"Repositorio es genérico, así que le podemos pasar cualquier objeto"
    {
        private readonly ApplicationDbContext _db;

        public PlantaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Planta planta)
        {
            var plantaBD = _db.Plantas.FirstOrDefault(b => b.Id == planta.Id);
            if (plantaBD != null)
            {
                plantaBD.NombreComun = planta.NombreComun;
                plantaBD.NombreCientifico = planta.NombreCientifico;
                plantaBD.EstatusAmenaza = planta.EstatusAmenaza;
                _db.SaveChanges();
            }
        }
    }
}
