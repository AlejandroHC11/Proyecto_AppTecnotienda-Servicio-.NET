using System;
using System.Collections.Generic;

namespace ApiTecnotienda.Models
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string? Nombre { get; set; }
        public string? Img { get; set; }
        public string? Precio { get; set; }
        public string? Stock { get; set; }
    }
}
