using Core.Entities.Company;
using Core.Entities.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IItemData
    {
        public List<ItemLote> GetLotesPorItem(Item item);
        public List<ItemLote> GetLotesPorItemAll();

        public List<ItemLote> GetNumeroSeriePorItem(Item item);
    }
}
