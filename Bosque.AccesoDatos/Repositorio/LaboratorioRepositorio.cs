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
    public class LaboratorioRepositorio : Repositorio<Laboratorio>, ILaboratorioRepositorio  //"Repositorio es genérico, así que le podemos pasar cualquier objeto"
    {
        private readonly ApplicationDbContext _db;

        public LaboratorioRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Laboratorio laboratorio)
        {
            var laboratorioBD = _db.Laboratorios.FirstOrDefault(b => b.Id == laboratorio.Id);
            if (laboratorioBD != null)
            {
                laboratorioBD.Nombre = laboratorio.Nombre;
                laboratorioBD.Ubicacion = laboratorio.Ubicacion;
                laboratorioBD.Personal = laboratorio.Personal;
                laboratorioBD.Descripcion = laboratorio.Descripcion;
                _db.SaveChanges();
            }
        }
    }
}
