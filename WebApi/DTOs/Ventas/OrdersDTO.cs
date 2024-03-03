namespace WebApi.DTOs.Ventas
{
    public class OrdersDTO
    {
        public double? Id { get; set; }
        public double? CodigoSap { get; set; }
        public string NombreFactura { get; set; }
        public string NitFactura { get; set; }
        public int? DiasPlazo { get; set; }
        public DateTimeOffset? FechaEntrega { get; set; }
        public Double? Total { get; set; }
        public Double? TipoCambio { get; set; }
        public Double? Descuento { get; set; }
        public string Observacion { get; set; }
        public DateTimeOffset? FechaRegistro { get; set; }
        public string? Estado { get; set; }
        public string IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public string IdEmpleado { get; set; }
        public string Moneda { get; set; }
        public string PersonaContacto { get; set; }
    }
}
