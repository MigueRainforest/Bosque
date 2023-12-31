﻿using Bosque.AccesoDatos.Data;
using Bosque.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ILaboratorioRepositorio Laboratorio { get; private set; }
        public IPlantaRepositorio Planta { get; private set; }
        public IAnimalRepositorio Animal { get; private set; }
        public IPersonalRepositorio Personal { get; private set; }
        public IBotanicoRepositorio Botanico { get; private set; }
        public IZoologoRepositorio Zoologo { get; private set; }
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Laboratorio = new LaboratorioRepositorio(_db);
            Planta = new PlantaRepositorio(_db);
            Animal = new AnimalRepositorio(_db);
            Personal = new PersonalRepositorio(_db);
            Botanico = new BotanicoRepositorio(_db);
            Zoologo = new ZoologoRepositorio(_db);

        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
