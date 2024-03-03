using Core.Entities.Errors;
using Core.Entities.SocioNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPaymentTermsTypesRepository
    {
        Task<(List<PaymentTermsTypes> Result, CodeErrorException Error)> GetAll(String sessionID);
        Task<(PaymentTermsTypes Result, CodeErrorException Error)> GetByGrupo(String sessionID, int idGrupo);
    }
}
