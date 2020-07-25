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
    public class SegmentationProxy
    {
        public async Task<ResponseBase<SegmentationModel>> CreateSegmentationAsync(SegmentationRequest segmentModel)
        {
            try
            {
                var request = JsonConvert.SerializeObject(segmentModel);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "segmentations/", "segment");
                var response = client.PostAsync(url, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<SegmentationModel>>(result);
                }
                else
                {
                    return new ResponseBase<SegmentationModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<SegmentationModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public async Task<ResponseBase<SegmentationModel>> UpdateSegmentationAsync(SegmentationModel segmentModel)
        {
            try
            {
                var request = JsonConvert.SerializeObject(segmentModel);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "segmentations/", "update");
                var response = client.PostAsync(url, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<SegmentationModel>>(result);
                }
                else
                {
                    return new ResponseBase<SegmentationModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<SegmentationModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public async Task<ResponseBase<SegmentationModel>> DleteSegmentationAsync(SegmentationModel segmentModel)
        {
            try
            {
                var request = JsonConvert.SerializeObject(segmentModel);
                var content = new StringContent(request, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);
                var url = string.Concat(baseUrl, "segmentations/", "delete");
                var response = client.PostAsync(url, content).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<SegmentationModel>>(result);
                }
                else
                {
                    return new ResponseBase<SegmentationModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<SegmentationModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
        public async Task<ResponseBase<SegmentationModel>> GetSegmentsAsync()
        {
            try
            {
                var client = new HttpClient();
                string baseUrl = ConstantURL.ApiCore;
                client.BaseAddress = new Uri(baseUrl);

                var url = string.Concat(baseUrl, "segmentations/", "list");
                var response = client.GetAsync(url).Result;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ResponseBase<SegmentationModel>>(result);
                }
                else
                {
                    return new ResponseBase<SegmentationModel>
                    {
                        Status = false,
                        Message = "Error"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase<SegmentationModel>
                {
                    Status = false,
                    Message = ex.Message
                };
                throw;
            }
        }
    }
}