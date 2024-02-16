using Core.Entities;
using Core.Entities.Errors;
using Core.Entities.Login;
using Core.Interfaces;
using Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class UserRepository : IUserRepository
    {
        IUserData _userData;
        private readonly IConfiguration _configuration;

        public UserRepository(IUserData userData, IConfiguration configuration)
        {
            _userData = userData;
            _configuration = configuration;
        }

        public async Task<ResponseLoginSap> AuthenticatedUserSap(LoginRequestModel model)
        {
            string url = _configuration["UrlSap"] + "/Login";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient client = new HttpClient(handler))
                {
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        // Leee y muetra la respuesta
                        // string responseContent = await response.Content.ReadAsStringAsync();
                        var responseContent = JsonConvert.DeserializeObject<ResponseLoginSap>(await response.Content.ReadAsStringAsync());
                        responseContent.isCorrect = true;
                        return responseContent;

                    }
                    else
                    {
                        // Muestra un mensaje de error si la solicitud no funciona
                        Console.WriteLine($"Error en la solicitud: {response.StatusCode} - {response.ReasonPhrase}");
                        return new ResponseLoginSap()
                        {
                            isCorrect = false
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseLoginSap()
                {
                    isCorrect = false,
                };
            }
        }

        public User Login(string username, string password, int id_company, out CodeErrorException Error)
        {
            CodeErrorException error;
            var user = _userData.Login(username, password, id_company, out error);
            if (error != null)
            {
                Error = error;
            } else
            {
                Error = null;
            }
            return user;
        }
    }
}
