using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.Modelos
{
    public class Botanico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [MaxLength(50, ErrorMessage ="El Nombre debe ser máximo 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido")]
        [MaxLength(50, ErrorMessage = "Apellidos ser máximo 100 caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Fecha de Nacimiento es requerido (AÑO-MES-DIA)")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Genero es requerido")]
        [MaxLength(15, ErrorMessage = "El Genero debe ser máximo 15 caracteres")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "Cedula es requerida")]
        [MaxLength(30, ErrorMessage = "Cedula ser máximo 30 caracteres")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Personal ID es Requerido")]
        public int PersonalId { get; set; }

        [ForeignKey("PersonalId")]
        public Personal Personal { get; set; }
    }
}
