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
    public class BusinessPartnersRepository : IBusinessPartnersRepository
    {
        private readonly IConfiguration _configuration;

        public BusinessPartnersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<(List<BusinessPartners> Result, CodeErrorException Error)> GetAll(string sessionID, int top, int skip, string text)
        {
            string url = string.Empty;
            if(String.IsNullOrEmpty(text)) 
            {
                url = _configuration["UrlSap"] + $"/BusinessPartners?$filter=CardType eq 'cCustomer'&$top={top}&$skip={skip}";
            } else
            {
                url = _configuration["UrlSap"] + $"/BusinessPartners?$filter=(contains(CardName, '{text}') or contains(CardCode, '{text}')) and CardType eq 'cCustomer'";
            }
            
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
                        return (result.value, null);
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

        public async Task<(BusinessPartners Result, CodeErrorException Error)> GetByCodigo(string sessionID, string codigo)
        {
            string url = _configuration["UrlSap"] + $"/BusinessPartners('{codigo}')";
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
                        var result = JsonConvert.DeserializeObject<BusinessPartners>(responseBody);
                        return (result, null);
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
