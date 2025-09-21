﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.DTO
{
    public class SucursalDTO
    {
        [Key]
        [Display(Name = "ID Sucursal")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_sucursal { get; set; }


        [Display(Name = "ID Empresa")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_empresa { get; set; }

        [Display(Name = "Nombre Sucursal")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Nombre_sucursal { get; set; } = null!;

        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_pais { get; set; }

        [Display(Name = "Provincia")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_provincia { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_ciudad { get; set; }


        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Direccion_sucursal { get; set; } = null!;


        [Display(Name = "CAP")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(10, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Cap_sucursal { get; set; } = string.Empty;

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(20, ErrorMessage = "El Campo {0} no puede mas de {2} Caracteres")]
        public string Telefono { get; set; } = null!;

        [Display(Name = "Telefono Secundario")]
        [MaxLength(20, ErrorMessage = "El Campo {0} no puede mas de {2} Caracteres")]
        public string Telefono_secundario { get; set; } = string.Empty;

        [Display(Name = "Email")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Email { get; set; } = string.Empty;


        [Display(Name = "Gerente General")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        public int Id_persona { get; set; }


        [Display(Name = "Horario Atencion")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Horario_atencion { get; set; } = null!;


        [Display(Name = "Informacion Sucursal")]
        [MaxLength(100, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Informacion_sucursal { get; set; } = string.Empty;

        [Display(Name = "Estado Sucursal")]
        [Required(ErrorMessage = "El Campo {0} es Obligatorio!")]
        [MaxLength(10, ErrorMessage = "El Campo {0} no puede mas de {1} Caracteres")]
        public string Estado_sucursal { get; set; } = string.Empty;
    }
}
