using Core.Entities.Errors;
using Core.Entities.Producto;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
        Task<(List<Item> Result, CodeErrorException Error)> GetAll(String sessionID);
    }
}
