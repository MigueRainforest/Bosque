using Bosque.AccesoDatos.Data;
using Bosque.AccesoDatos.Repositorio.IRepositorio;
using Bosque.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio
{
    public class BotanicoRepositorio : Repositorio<Botanico>, IBotanicoRepositorio  //"Repositorio es genérico, así que le podemos pasar cualquier objeto"
    {
        private readonly ApplicationDbContext _db;

        public BotanicoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Botanico botanico)
        {
            var botanicoBD = _db.Botanicos.FirstOrDefault(b => b.Id == botanico.Id);
            if (botanicoBD != null)
            {
                botanicoBD.Nombre = botanico.Nombre;
                botanicoBD.Apellidos = botanico.Apellidos;
                botanicoBD.FechaNacimiento = botanico.FechaNacimiento;
                botanicoBD.Genero = botanico.Genero;
                botanicoBD.Cedula = botanico.Cedula;
                // Llave foranea
                botanicoBD.PersonalId = botanicoBD.PersonalId;
                
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj)
        {
            if (obj == "Personal")
            {
                //return _db.Personal.Where(c => c.Especialidad == "Botanico").Select(c => new SelectListItem
                return _db.Personal.Select(c => new SelectListItem
                {
                    Text = c.Especialidad,
                    Value = c.Id.ToString()
                });
            }           
            return null;
        }
    }
}
