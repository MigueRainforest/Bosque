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
    public class ZoologoConfiguracion : IEntityTypeConfiguration<Zoologo>
    {
        public void Configure(EntityTypeBuilder<Zoologo> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Apellidos).IsRequired().HasMaxLength(50);
            builder.Property(x => x.FechaNacimiento).IsRequired();
            builder.Property(x => x.Genero).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Cedula).IsRequired().HasMaxLength(30);
            builder.Property(x => x.PersonalId).IsRequired();

            /* Relaciones*/

            builder.HasOne(x => x.Personal).WithMany()
                   .HasForeignKey(x => x.PersonalId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
