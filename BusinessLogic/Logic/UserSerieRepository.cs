using Core.Entities;
using Core.Entities.Errors;
using Core.Interfaces;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class UserSerieRepository : IUserSerieRepository
    {
        IUserData _userData;
        private readonly IConfiguration _configuration;

        public UserSerieRepository(IUserData userData, IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task<(List<UserSerie> Result, CodeErrorException Error)> GetByUser(string sessionID, string idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
