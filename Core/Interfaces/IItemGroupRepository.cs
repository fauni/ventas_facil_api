using Core.Entities.Errors;
using Core.Entities.Producto;

namespace Core.Interfaces
{
    public interface IItemGroupRepository
    {
        Task<(List<ItemGroup> Result, CodeErrorException Error)> GetAll(String sessionID);
        Task<(ItemGroup Result, CodeErrorException Error)> GetPorNumero(String sessionID, int numero);
    }
}
