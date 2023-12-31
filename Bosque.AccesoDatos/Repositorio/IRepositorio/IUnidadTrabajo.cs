﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ILaboratorioRepositorio Laboratorio { get; }
        IPlantaRepositorio Planta { get; }
        IAnimalRepositorio Animal { get; }
        IPersonalRepositorio Personal { get; }
        IBotanicoRepositorio Botanico { get; }
        IZoologoRepositorio Zoologo { get; }

        Task Guardar();
    }
}
