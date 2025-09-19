using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.Entidades
{
    public class Pais
    {
        [Key]
        public int Id_pais { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100,ErrorMessage ="El Campo {0} no puede mas de {1} Caracteres")]
        public string Nombre_pais { get; set; } = null!;

        [Display(Name = "Informacion De Pais")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Informacion { get; set; }=string.Empty;

        [Display(Name = "Pais Icono")]
        public byte[]? Foto_pais { get; set; }

        public DateTime Date_reg { get; set; } = DateTime.Now;


        [Display(Name = "Estado Pais")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(10, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Estado_pais { get; set; } = string.Empty;
    }
}
