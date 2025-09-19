using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.DTO
{
    public class PaisDropDTO
    {
        [Key]
        [Display(Name = "ID Pais", Order = 1)]
        public int Id_pais { get; set; }

        [Display(Name = "Pais", Order = 2)]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Nombre_pais { get; set; } = null!;
    }
}
