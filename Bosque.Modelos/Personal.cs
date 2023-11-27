using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.Modelos
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La Especialidad es requerida")]
        [MaxLength(100, ErrorMessage ="El Nombre debe ser máximo 100 caracteres")]
        public string Especialidad { get; set; }


        [Required(ErrorMessage = "Laboratorio ID es Requerido")]
        public int LaboratorioId { get; set; }

        [ForeignKey("LaboratorioId")]
        public Laboratorio Laboratorio { get; set; }
    }
}
