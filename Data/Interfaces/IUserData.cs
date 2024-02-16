using Core.Entities;
using Core.Entities.Errors;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IUserData
    {
        public User Login(string username, string password, int id_company, out CodeErrorException Error);
    }
}
