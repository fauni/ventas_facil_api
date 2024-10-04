using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Producto
{
    public class ResponseItemUnidadMedida
    {
        public List<ItemUnidadMedida> value { get; set; }
    }

    public class ItemUnidadMedida
    {
        public int AbsEntry { get; set; }
        public string Code { get; set; }
    }
}
