using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Producto
{
    public class ItemLote
    {
        public string Almacen { get; set; }
        public string CodigoArticulo { get; set; }
        public string NombreArticulo { get; set; }
        public string NumeroLote { get; set; }
        public double? Stock { get; set; }
        public DateTimeOffset? FechaVencimiento { get; set; }
    }
}