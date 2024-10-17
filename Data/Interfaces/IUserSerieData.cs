using Core.Entities;
using Core.Entities.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserSerieData
    {
        public List<UserSerie> GetSeriesByUser(string idUsuario);
    }
}
