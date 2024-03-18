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
        public List<DocumentLineGuardarOrder> DocumentLines { get; set; }
        public string PickRemark { get; set; }
    }

    public class DocumentLineGuardarOrder
    {
        public string ItemCode { get; set; }
        public double? Quantity { get; set; }
        public string TaxCode { get; set; }
        public double? UnitPrice { get; set; }   
    }
}
