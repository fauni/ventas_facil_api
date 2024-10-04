using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Ventas
{
    public class OrderModificarLinea
    {
        public int? DocEntry { get; set; }
        public List<OrderModificarLineaItem> DocumentLines { get; set; }
    }

    public class OrderModificarLineaItem
    {
        public int? LineNum { get; set; }
        public string LineStatus { get; set; }
    }
}
