using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.DTO
{
    public class CiudadDropDTO
    {
        [Key]
        [Display(Name = "ID Ciudad")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_ciudad { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Nombre_ciudad { get; set; } = null!;
    }
}
