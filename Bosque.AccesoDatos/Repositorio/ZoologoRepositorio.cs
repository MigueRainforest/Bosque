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
    public class ZoologoRepositorio : Repositorio<Zoologo>, IZoologoRepositorio  //"Repositorio es genérico, así que le podemos pasar cualquier objeto"
    {
        private readonly ApplicationDbContext _db;

        public ZoologoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Zoologo zoologo)
        {
            var zoologoBD = _db.Zoologos.FirstOrDefault(b => b.Id == zoologo.Id);
            if (zoologoBD != null)
            {
                zoologoBD.Nombre = zoologo.Nombre;
                zoologoBD.Apellidos = zoologo.Apellidos;
                zoologoBD.FechaNacimiento = zoologo.FechaNacimiento;
                zoologoBD.Genero = zoologo.Genero;
                zoologoBD.Cedula = zoologo.Cedula;
                // Llave foranea
                zoologoBD.PersonalId = zoologoBD.PersonalId;
                
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj)
        {
            if (obj == "Personal")
            {
                //return _db.Personal.Where(c => c.Especialidad == "Zoologo").Select(c => new SelectListItem
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
