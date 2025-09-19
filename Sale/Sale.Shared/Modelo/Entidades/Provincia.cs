using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.Entidades
{
    public class Provincia
    {
        [Key]
        [Display(Name = "ID Provincia")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_provincia { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_pais { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Nombre_provincia { get; set; } = null!;

        [Display(Name = "Informacion De Pais")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Informacion_provincia { get; set; } = string.Empty;

        [Display(Name = "Fecha De Registro")]
        public DateTime Date_reg { get; set; } = DateTime.Now;


        [Display(Name = "Estado Pais")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(10, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Estado_provincia { get; set; } = string.Empty;
    }
}
