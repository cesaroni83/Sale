using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.DTO
{
    public class CiudadDTO
    {
        [Key]
        [Display(Name = "ID Ciudad")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_ciudad { get; set; }


        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_provincia { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_pais { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Nombre_ciudad { get; set; } = null!;

        [Display(Name = "Informacion De Ciudad")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Informacion_ciudad { get; set; } = string.Empty;

        [Display(Name = "Estado Ciudad")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(10, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Estado_ciudad { get; set; } = string.Empty;
    }
}
