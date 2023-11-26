using Bosque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio.IRepositorio
{
    public interface IPlantaRepositorio : IRepositorio<Planta>
    {
        void Actualizar(Planta planta);
    }
}
