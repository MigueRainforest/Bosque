using Bosque.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio.IRepositorio
{
    public interface IPersonalRepositorio : IRepositorio<Personal>
    {
        void Actualizar(Personal personal);
        IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj);
    }
}
