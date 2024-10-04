using Core.Entities.Errors;
using Core.Entities.Ventas;
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
    public class OrderPendingRepository : IOrderPendingRepository
    {
        private readonly IConfiguration _configuration;

        public OrderPendingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<(bool Result, CodeErrorException Error)> CrearDocumento(string sessionID, int idOrder)
        {
            string url = _configuration["UrlSap"] + $"/DraftsService_SaveDraftToDocument";
            DocumentDraft documentDraft = new DocumentDraft();
            documentDraft.DocEntry = idOrder.ToString();

            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using (HttpClient httpClient = new HttpClient(handler))
                {
                    httpClient.DefaultRequestHeaders.Add("Cookie", String.Format("B1SESSION={0}", sessionID));

                    var json = JsonConvert.SerializeObject(new DocumentoDraftEntidad { Document = documentDraft });

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return (true, null);
                    }
                    else
                    {
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        var codeError = new CodeErrorException((int)response.StatusCode, errorResponse);
                        return (false, codeError);
                    }
                }
            }
            catch (Exception ex)
            {
                var codeError = new CodeErrorException(500, ex.Message, ex.StackTrace);
                return (false, codeError);
            }
        }

        public async Task<(List<Order> Result, CodeErrorException Error)> GetAll(string sessionID, int top, int skip)
        {
            string url = _configuration["UrlSap"] + $"/Drafts?$filter=DocObjectCode eq 'oOrders' and AuthorizationStatus eq 'dasPending'&$orderby=DocEntry desc&$top={top}&$skip={skip}";
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
                        var result = JsonConvert.DeserializeObject<ResponseOrder>(responseBody);
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

        public async Task<(List<Order> Result, CodeErrorException Error)> GetAllAprobados(string sessionID, int top, int skip)
        {
            string url = _configuration["UrlSap"] + $"/Drafts?$filter=DocObjectCode eq 'oOrders' and AuthorizationStatus eq 'dasApproved'&$orderby=DocEntry desc&$top={top}&$skip={skip}";
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
                        var result = JsonConvert.DeserializeObject<ResponseOrder>(responseBody);
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

        public async Task<(List<Order> Result, CodeErrorException Error)> GetBySearch(string sessionID, string search)
        {
            string url = _configuration["UrlSap"] + @$"/Drafts?$filter=(contains(DocNum, '{search}') or contains(DocEntry, '{search}') 
                or contains(CardCode, '{search}') or contains(CardName, '{search}')) and AuthorizationStatus eq 'dasPending'&$orderby=DocEntry desc";
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
                        var result = JsonConvert.DeserializeObject<ResponseOrder>(responseBody);
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

        public async Task<(List<Order> Result, CodeErrorException Error)> GetBySearchAprobados(string sessionID, string search)
        {
            string url = _configuration["UrlSap"] + @$"/Drafts?$filter=(contains(DocNum, '{search}') or contains(DocEntry, '{search}') 
                or contains(CardCode, '{search}') or contains(CardName, '{search}')) and AuthorizationStatus eq 'dasApproved'&$orderby=DocEntry desc";
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
                        var result = JsonConvert.DeserializeObject<ResponseOrder>(responseBody);
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
    }

    public class DocumentoDraftEntidad
    {
        public DocumentDraft Document { get; set; }
    }

    public class DocumentDraft
    {
        public string DocEntry { get; set; }
    }
}
