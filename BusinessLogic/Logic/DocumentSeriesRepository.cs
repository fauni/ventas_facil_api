using Core.Entities.Errors;
using Core.Entities.Series;
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
    public class DocumentSeriesRepository : IDocumentSeriesRepository
    {
        private readonly IConfiguration _configuration;

        public DocumentSeriesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(List<DocumentSeries> Result, CodeErrorException Error)> GetForDocumentCode(string sessionID, int documentCode)
        {
            string url = _configuration["UrlSap"] + "/SeriesService_GetDocumentSeries";
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));
                    string json = $@"{{ ""DocumentTypeParams"": {{ ""Document"": ""{documentCode}"" }} }}";
                    // var json = JsonConvert.SerializeObject(body);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ResponseDocumentSeries>(responseBody);
                        return (result.value, null);
                    } else
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
