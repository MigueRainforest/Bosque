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
    public class PersonalConfiguracion : IEntityTypeConfiguration<Personal>
    {
        public void Configure(EntityTypeBuilder<Personal> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Especialidad).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LaboratorioId).IsRequired();

            /* Relaciones*/

            builder.HasOne(x => x.Laboratorio).WithMany()
                   .HasForeignKey(x => x.LaboratorioId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
