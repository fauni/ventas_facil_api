﻿using Core.Entities.Errors;
using Core.Entities.SocioNegocio;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Logic
{
    public class ContactEmployeeRepository : IContactEmployeeRepository
    {
        private readonly IConfiguration _configuration;

        public ContactEmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(List<ContactEmployee> Result, CodeErrorException Error)> GetAll(string sessionID)
        {
            string url = _configuration["UrlSap"] + "/BusinessPartners?$filter=CardType eq 'cCustomer'";

            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ResponseBusinessPartners>(responseBody);

                        List<ContactEmployee> contactos = new List<ContactEmployee>();
                        foreach (var item in result.value)
                        {
                            foreach (var itemContacto in item.ContactEmployees)
                            {
                                contactos.Add(itemContacto);
                            }
                        }

                        return (contactos, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (null, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (null, codeError);
            }

        }
    }
}
