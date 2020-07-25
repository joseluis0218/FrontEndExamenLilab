using Common.HttpHelpers;
using FrontEndExamenLilab.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FrontEndExamenLilab.Proxy
{
    public class ClientProxy
    {
        public async Task<ResponseBase<ClientModel>> CreateClientAsync(ClientModel clientModel)
        {
            try
            {
                var request = JsonConvert.SerializeObject(clientModel);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "clients/", "create");
                var response = client.PostAsync(url, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<ClientModel>>(result);
                }
                else
                {
                    return new ResponseBase<ClientModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<ClientModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public async Task<ResponseBase<ClientModel>> GetClientsAsync()
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "clients/", "list");
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<ClientModel>>(result);
                }
                else
                {
                    return new ResponseBase<ClientModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<ClientModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public async Task<ResponseBase<ClientResponse>> GetClientsByFilterAsync(ClientRequest clientRequest)
        {
            try
            {
                var request = JsonConvert.SerializeObject(clientRequest);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "clients/", "getClientsByFilter");
                var response = client.PostAsync(url, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<ClientResponse>>(result);
                }
                else
                {
                    return new ResponseBase<ClientResponse>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<ClientResponse>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
    }
}