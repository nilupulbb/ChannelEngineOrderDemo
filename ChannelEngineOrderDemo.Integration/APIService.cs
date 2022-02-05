using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Integration.ResponseObj;
using ChannelEngineOrderDemo.Logic.Infrastructure;
using ChannelEngineOrderDemo.Logic.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Linq;

namespace ChannelEngineOrderDemo.Integration
{
    public abstract class APIService<T> : IDataService<T>
    {
        protected readonly string _apiPathMinor;

        protected readonly string _apiKey;

        private readonly HttpClient _client;

        public APIService(string apiPathMajor, string apiPathMinor, string apiKey)
        {
            _apiPathMinor = apiPathMinor;
            _apiKey = apiKey;
            _client = new HttpClient() { BaseAddress = new Uri(apiPathMajor) };
        }

        public async Task<IList<T>> GetList(IDictionary<string, string> filters)
        {
            return ExtractGetListFromResponse(await Get(_apiPathMinor, DictionaryToQueryString(filters)));
        }

        public async Task Patch(IList<PatchData> patches, string id)
        {
            await Patch(_apiPathMinor + id + "/", patches);
        }
        protected IList<T> ExtractGetListFromResponse(string response)
        {
            var responseObj = JsonConvert.DeserializeObject<GetListReponse<T>>(response);
            return responseObj.Content.ToList();
        }

        protected async Task<string> Get(string url, string queryString)
        {
            using (var response = await _client.GetAsync(url + "?" + queryString + "&apikey=" + HttpUtility.UrlEncode(_apiKey)))
            {
                if (!response.IsSuccessStatusCode)
                {
                    // TODO: Log the error and return
                    throw new Exception(response.StatusCode.ToString());
                }
                return await response.Content.ReadAsStringAsync();
            }
        }

        protected async Task Patch(string url, IList<PatchData> patches)
        {
            using (var response = await _client.PatchAsync(url + "?apikey=" + HttpUtility.UrlEncode(_apiKey)
                    , new StringContent(JsonConvert.SerializeObject(patches), Encoding.UTF8, "application/json-patch+json")))
            {
                if (!response.IsSuccessStatusCode)
                {
                    // TODO: Log the error and return
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

        protected string DictionaryToQueryString(IDictionary<string, string> parameters)
        {
            var sb = new StringBuilder();
            foreach(var item in parameters)
            {
                sb.Append(HttpUtility.UrlEncode(item.Key));
                sb.Append("=");
                sb.Append(HttpUtility.UrlEncode(item.Value));
                sb.Append("&");
            }
            var retStr = sb.ToString();
            if(retStr.Length > 0)
            {
                retStr.Substring(0, retStr.Length - 1);
            }
            return retStr;
        }

    }
}
