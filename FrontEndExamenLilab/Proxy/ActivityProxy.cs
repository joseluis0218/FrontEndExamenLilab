using Common.HttpHelpers;
using FrontEndExamenLilab.Models;
using Newtonsoft.Json;
using System;

using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FrontEndExamenLilab.Proxy
{
    public class ActivityProxy
    {
        public async Task<ResponseBase<ActivityModel>> CreateActivityAsync(ActivityModel activityModel)
        {
            try
            {
                var request = JsonConvert.SerializeObject(activityModel);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "activities/", "create");
                var response = client.PostAsync(url, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<ActivityModel>>(result);
                }
                else
                {
                    return new ResponseBase<ActivityModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<ActivityModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public async Task<ResponseBase<ActivityResponse>> GetActiviesAsync()
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "activities/", "list");
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<ActivityResponse>>(result);
                }
                else
                {
                    return new ResponseBase<ActivityResponse>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<ActivityResponse>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }

    }
}