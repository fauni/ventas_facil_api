using Core.Entities.Errors;
using Core.Entities.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISalesPersonsRepository
    {
        Task<(List<SalesPersons> Result, CodeErrorException Error)> GetAll(String sessionID);
        Task<(SalesPersons Result, CodeErrorException Error)> GetById(String sessionID, int? id);
    }
}
