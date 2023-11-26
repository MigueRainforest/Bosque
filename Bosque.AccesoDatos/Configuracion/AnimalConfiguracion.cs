using Bosque.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.AccesoDatos.Configuracion
{
    public class AnimalConfiguracion : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.NombreComun).IsRequired().HasMaxLength(100);
            builder.Property(x => x.NombreCientifico).IsRequired().HasMaxLength(100);            
            builder.Property(x => x.EstatusAmenaza).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Dieta).HasMaxLength(100);
        }
    }
}
