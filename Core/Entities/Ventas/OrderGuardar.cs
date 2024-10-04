namespace Core.Entities.Ventas
{
    public class OrderGuardar
    {
        public int? DocEntry { get; set; }
        public DateTimeOffset? DocDate { get; set; }
        public DateTimeOffset? DocDueDate { get; set; }
        public string CardCode { get; set; }
        public string Comments { get; set; }
        public int? SalesPersonCode { get; set; }
        public int? ContactPersonCode { get; set; }
        public int? PaymentGroupCode { get; set; }
        public List<DocumentLineGuardarOrder> DocumentLines { get; set; }
        public string U_usrventafacil { get; set; }
        public string U_latitud { get; set; }
        public string U_longitud { get; set; }
        public DateTimeOffset? U_fecharegistroapp { get; set; }
        public DateTimeOffset? U_horaregistroapp { get; set; } 
    }

    public class DocumentLineGuardarOrder
    {
        public string ItemCode { get; set; }
        public double? Quantity { get; set; }
        public string TaxCode { get; set; }
        public double? UnitPrice { get; set; }
        public double? PriceAfterVAT { get; set; }
        public double? DiscountPercent { get; set; }
        public int? UoMEntry { get; set; }
        public DateTimeOffset? ShipDate { get; set; }
        public string U_descitemfacil { get; set; }
        public double? U_PrecioVenta { get; set; }
        public double? U_PrecioItemVenta { get; set; }
    }
}
