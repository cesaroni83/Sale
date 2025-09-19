using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.DTO
{
    public class PaisDTO
    {
        [Key]
        [Display(Name ="ID Pais",Order =2)]
        public int Id_pais { get; set; }

        [Display(Name = "Pais", Order = 3)]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Nombre_pais { get; set; } = null!;

        [Display(Name = "Informacion De Pais", Order = 4)]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Informacion { get; set; } = string.Empty;

        [Display(Name = "Foto", Order = 1)]
        public byte[]? Foto_pais { get; set; }

        [Display(Name = "Estado De Pais", Order = 5)]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(10, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Estado_pais { get; set; } = string.Empty;
    }
}
