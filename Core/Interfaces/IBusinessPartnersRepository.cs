using Core.Entities.Errors;
using Core.Entities.SocioNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IBusinessPartnersRepository
    {
        Task<(List<BusinessPartners> Result, CodeErrorException Error)> GetAll(String sessionID);
    }
}
