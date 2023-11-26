using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bosque.Modelos
{
    public class Laboratorio
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido")]
        [MaxLength(100, ErrorMessage ="El Nombre debe ser máximo 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La Ubicacion es requerida")]
        [MaxLength(100, ErrorMessage = "La Ubicacion ser máximo 100 caracteres")]
        public string Ubicacion { get; set; }

        /*
        [Required(ErrorMessage = "Personal es requerida")]
        [MaxLength(50, ErrorMessage = "Debe ser máximo 50 caracteres")]
        public string Personal { get; set; } */

        [Required(ErrorMessage = "La Descripcion es requerida")]
        [MaxLength(100, ErrorMessage = "La Descripcion ser máximo 100 caracteres")]
        public string Descripcion { get; set; }
    }
}
