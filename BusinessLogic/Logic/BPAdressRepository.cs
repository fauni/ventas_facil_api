using Core.Entities.Errors;
using Core.Entities.SocioNegocio;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLogic.Logic
{
    public class BPAdressRepository : IBPAdressRepository
    {
        private readonly IConfiguration _configuration;

        public BPAdressRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<(List<BPAddress> Result, CodeErrorException Error)> GetAll(string sessionID)
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

                        List<BPAddress> adresses = new List<BPAddress>();
                        foreach (var item in result.value)
                        {
                            foreach (var itemAdress in item.BpAddresses)
                            {
                                adresses.Add(itemAdress);
                            }
                        }

                        return (adresses, null);
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
