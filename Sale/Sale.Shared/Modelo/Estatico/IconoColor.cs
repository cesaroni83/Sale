﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sale.Shared.Modelo.Estatico
{
    public class IconoColor
    {
        public string? Id { get; set; }
        public string? Text { get; set; }

        public static List<IconoColor> GetItems() => new()
        {
            new IconoColor { Id = "1" , Text = "Primary" },
            new IconoColor { Id = "2" , Text = "Secondary" },
            new IconoColor { Id = "3" , Text = "Success" },
            new IconoColor { Id = "4" , Text = "Danger" },
            new IconoColor { Id = "5" , Text = "Warning" },
            new IconoColor { Id = "6" , Text = "Info" },
            new IconoColor { Id = "7" , Text = "Dark" },
            new IconoColor { Id = "8" , Text = "Boby" },
            new IconoColor { Id = "7" , Text = "Muted" },
            new IconoColor { Id = "9"  , Text = "White" },
        };
        public static string GetTextIconoColor(string  id)
        {
            var estado = GetItems().FirstOrDefault(e => e.Id == id);
            return estado?.Text ?? string.Empty; // Retorna vacío si no encuentra
        }
    }
}
