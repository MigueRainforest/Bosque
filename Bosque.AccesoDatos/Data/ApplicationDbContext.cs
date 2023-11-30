using Bosque.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Bosque.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Laboratorio> Laboratorios { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Animal> Animales { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Botanico> Botanicos { get; set; }
        public DbSet<Zoologo> Zoologos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}