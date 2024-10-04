using Core.Entities.Errors;
using Core.Entities.Ventas;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<(List<Order> Result, CodeErrorException Error)> GetAll(String sessionID, int top, int skip);

        Task<(List<Order> Result, CodeErrorException Error)> GetForText(String sessionID, string search);

        Task<(Order Result, CodeErrorException Error)> GetById(String sessionID, int id);

        Task<(Order Result, CodeErrorException Error)> SaveOrder(String sessionID, OrderGuardar order);

        Task<(bool Result, CodeErrorException Error)> UpdateOrder(String sessionID, int idOrder, OrderModificar order);

        Task<(bool Result, CodeErrorException Error)> UpdateStatusLineOrder(String sessionID, int idOrder, OrderModificarLinea order);

        MemoryStream GenerarPDF(Order order);
    }
}
