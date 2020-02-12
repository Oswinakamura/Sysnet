using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sysnet.Models
{
    public class PersonaClass
    {
        
        public int id { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name =  "")]
        public string identificacion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "")]
        public string tipoIdentificacion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "")]
        public string primerNombre { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "")]
        public string segundoNombre { get; set; }
        public string primerApellido { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "")]
        public string segundoApellido { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "")]
        public string email { get; set; }
        public string ocupacion { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "")]
        public DateTime? fechaNacimiento { get; set; }
        public string foto { get; set; }
    }
}