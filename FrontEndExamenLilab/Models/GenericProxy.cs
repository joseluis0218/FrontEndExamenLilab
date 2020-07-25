using Common.HttpHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FrontEndExamenLilab.Models
{
    public class GenericProxy
    {
        public async Task<ResponseBase<MonthModel>> GetMonthsAsync()
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);

                var url = string.Concat(baseUrl,"months/", "list");
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<MonthModel>>(result);
                }
                else
                {
                    return new ResponseBase<MonthModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<MonthModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
    }
}