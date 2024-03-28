using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Ventas
{
    public class OrderModificar
    {
        public int? DocEntry { get; set; }
        public DateTimeOffset? DocDate { get; set; }
        public DateTimeOffset? DocDueDate { get; set; }
        //public string CardCode { get; set; }
        public string Comments { get; set; }
        public int? SalesPersonCode { get; set; }
        public int? ContactPersonCode { get; set; }
        public List<DocumentLineModificarOrder> DocumentLines { get; set; }
        //public string PickRemark { get; set; }
    }

    public class DocumentLineModificarOrder
    {
        public string ItemCode { get; set; }
        public double? Quantity { get; set; }
        public string TaxCode { get; set; }
        public double? UnitPrice { get; set; }
        public double? PriceAfterVAT { get; set; }
        public double? DiscountPercent { get; set; }
        public string U_descitemfacil { get; set; }
        public double? U_PrecioVenta { get; set; }
        public double? Volume { get; set; }
    }
}
