using Core.Entities.Errors;
using Core.Entities.SocioNegocio;
using Core.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IContactEmployeeRepository
    {
        Task<(List<ContactEmployee> Result, CodeErrorException Error)> GetAll(String sessionID);
    }
}
