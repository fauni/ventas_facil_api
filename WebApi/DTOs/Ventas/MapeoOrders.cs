using Core.Entities.Ventas;

namespace WebApi.DTOs.Ventas
{
    public class MapeoOrders
    {
        public static OrdersDTO MapToDTO(Order order)
        {
            return new OrdersDTO()
            {
                Id = order.DocEntry,
                CodigoSap = order.DocNum,
                NombreFactura = null,
                NitFactura = null,
                DiasPlazo = null,
                FechaEntrega = order.DocDueDate,
                Total = order.DocTotal,
                // TipoCambio = order.BpChannelCode,
                Descuento = order.DiscountPercent,
                Observacion = order.JournalMemo,
                FechaRegistro = order.DocDate,
                Estado = order.DocumentStatus,
                IdCliente = order.CardCode,
                NombreCliente = order.CardName,
                Moneda = order.DocCurrency,
                PersonaContacto = order.ContactPersonCode
            };
        }
    }
}
