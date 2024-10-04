using Core.Entities.Errors;
using Core.Entities.Producto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IItemUnidadMedidaRepository
    {
        Task<(List<ItemUnidadMedida> Result, CodeErrorException Error)> GetAll(String sessionID);
    }
}
