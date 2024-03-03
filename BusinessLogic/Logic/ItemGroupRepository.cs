using Core.Entities.Errors;
using Core.Entities.Producto;
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
    public class ItemGroupRepository : IItemGroupRepository
    {
        IConfiguration _configuration;

        public ItemGroupRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<(List<ItemGroup> Result, CodeErrorException Error)> GetAll(string sessionID)
        {
            string url = _configuration["UrlSap"] + "/ItemGroups";
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
                        var result = JsonConvert.DeserializeObject<ResponseItemGroup>(responseBody);
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

        public async Task<(ItemGroup Result, CodeErrorException Error)> GetPorNumero(string sessionID, int numero)
        {
            string url = _configuration["UrlSap"] + $"/ItemGroups({numero})";
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
                        var result = JsonConvert.DeserializeObject<ItemGroup>(responseBody);
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
