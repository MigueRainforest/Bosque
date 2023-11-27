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
    public class PersonalRepositorio : Repositorio<Personal>, IPersonalRepositorio  //"Repositorio es genérico, así que le podemos pasar cualquier objeto"
    {
        private readonly ApplicationDbContext _db;

        public PersonalRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Personal personal)
        {
            var personalBD = _db.Personal.FirstOrDefault(b => b.Id == personal.Id);
            if (personalBD != null)
            {
                personalBD.Especialidad = personal.Especialidad;
                personalBD.LaboratorioId = personal.LaboratorioId;
                
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj)
        {
            if (obj == "Laboratorio")
            {
                //return _db.Laboratorios.Where(c => c.Estado == true).Select(c => new SelectListItem 
                //Podemos condicionar para que solo filtre 1 SOLO LABORATORIO, por ejemplo: c.Nombre == "ECOSUR - Chiapas" 
                //return _db.Laboratorios.Select(c => new SelectListItem
                return _db.Laboratorios.Where(c => c.Nombre == "ECOSUR - San Cristobal de las Casas").Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }           
            return null;
        }
    }
}
