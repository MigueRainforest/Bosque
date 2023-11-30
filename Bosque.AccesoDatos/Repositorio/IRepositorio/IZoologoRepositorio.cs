using Bosque.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio.IRepositorio
{
    public interface IZoologoRepositorio : IRepositorio<Zoologo>
    {
        void Actualizar(Zoologo zoologo);
        IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj);
    }
}
