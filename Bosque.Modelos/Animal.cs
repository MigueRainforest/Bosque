using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.Modelos
{
    public class Animal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre común es requerido")]
        [MaxLength(100, ErrorMessage = "El Nombre debe ser máximo 100 caracteres")]
        public string NombreComun { get; set; }

        [Required(ErrorMessage = "El Nombre científico es requerido")]
        [MaxLength(100, ErrorMessage = "La Ubicacion ser máximo 100 caracteres")]
        public string NombreCientifico { get; set; }
        
        [Required(ErrorMessage = "El Estatus es requerido")]
        [MaxLength(100, ErrorMessage = "La Descripcion ser máximo 100 caracteres")]
        public string EstatusAmenaza { get; set; }

        //[Required(ErrorMessage = "El Estatus es requerido")]
        [MaxLength(100, ErrorMessage = "La descripción de Dieta ser máximo 100 caracteres")]
        public string Dieta { get; set; }
    }
}
