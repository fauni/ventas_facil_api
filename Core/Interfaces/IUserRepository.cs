using Core.Entities.Errors;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Login;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        User Login(string username, string password, int id_company, out CodeErrorException Error);
        Task<ResponseLoginSap> AuthenticatedUserSap(LoginRequestModel model);
    }
}
