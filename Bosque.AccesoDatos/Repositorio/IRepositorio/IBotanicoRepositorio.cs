using Bosque.Modelos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio.IRepositorio
{
    public interface IBotanicoRepositorio : IRepositorio<Botanico>
    {
        void Actualizar(Botanico botanico);
        IEnumerable<SelectListItem> ObtenerTodosDropdownLista(string obj);
    }
}
