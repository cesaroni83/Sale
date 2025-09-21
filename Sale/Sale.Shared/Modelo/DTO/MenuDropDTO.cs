using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.DTO
{
    public class MenuDropDTO
    {
        [Key]
        public int Id_menu { get; set; }

        [Display(Name = "Texto")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Descripcion { get; set; } = null!;
    }
}
