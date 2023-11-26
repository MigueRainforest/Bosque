using Bosque.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio.IRepositorio
{
    public interface IAnimalRepositorio : IRepositorio<Animal>
    {
        void Actualizar(Animal animal);
    }
}
