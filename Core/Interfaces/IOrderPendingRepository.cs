using Core.Entities.Errors;
using Core.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderPendingRepository
    {
        Task<(List<Order> Result, CodeErrorException Error)> GetAll(String sessionID, int top, int skip);
        Task<(List<Order> Result, CodeErrorException Error)> GetBySearch(String sessionID, string search);

        Task<(List<Order> Result, CodeErrorException Error)> GetAllAprobados(String sessionID, int top, int skip);
        Task<(List<Order> Result, CodeErrorException Error)> GetBySearchAprobados(String sessionID, string search);

        Task<(bool Result, CodeErrorException Error)> CrearDocumento(String sessionID, int idOrder);
    }
}
