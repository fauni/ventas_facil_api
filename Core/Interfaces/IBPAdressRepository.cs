using Core.Entities.Errors;
using Core.Entities.SocioNegocio;

namespace Core.Interfaces
{
    public interface IBPAdressRepository
    {
        Task<(List<BPAddress> Result, CodeErrorException Error)> GetAll(String sessionID);
    }
}
