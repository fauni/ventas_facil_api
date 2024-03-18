
namespace Core.Entities.Ventas
{
    public class ResponseSalesPersons
    {
        public List<SalesPersons> value { get; set; }
    }
    public class SalesPersons
    {
        public int? SalesEmployeeCode { get; set; }
        public string SalesEmployeeName { get; set; }
        public string Remarks { get; set; }
        public double? CommissionForSalesEmployee { get; set; }
        public double? CommissionGroup { get; set; }
        public string Locked { get; set; }
        public string EmployeeId { get; set; }
        public string Active { get; set; }
        public double? Telephone { get; set; }
        public double? Mobile { get; set; }
        public double? Fax { get; set; }
        public string Email { get; set; }
    }
}
