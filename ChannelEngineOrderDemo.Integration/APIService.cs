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
    /*
     * Abstract class provides necessary functions required to communicate with an API
     */
    public abstract class APIService<T> : IDataService<T>
    {
        /*
         * Relative path of the service. eg. products, orders etc.
         */
        protected readonly string _apiPathMinor;

        /*
         * The credential needed to access the API
         */

        protected readonly string _apiKey;

        private readonly HttpClient _client;

        public APIService(string apiPathMajor, string apiPathMinor, string apiKey)
        {
            _apiPathMinor = apiPathMinor;
            _apiKey = apiKey;
            _client = new HttpClient() { BaseAddress = new Uri(apiPathMajor) };
        }

        /*
         * Generic method for call a list from an API
         */
        public async Task<IList<T>> GetList(IDictionary<string, string> filters)
        {
            return ExtractGetListFromResponse(await Get(_apiPathMinor, DictionaryToQueryString(filters)));
        }

        /*
         * Generic method for patching an entity through API
         */
        public async Task Patch(IList<PatchData> patches, string id)
        {
            await Patch(_apiPathMinor + "/" + id, patches);
        }

        /*
         * Obtains the required list from the response object received from the API
         */
        protected IList<T> ExtractGetListFromResponse(string response)
        {
            var responseObj = JsonConvert.DeserializeObject<GetListReponse<T>>(response);
            return responseObj.Content.ToList();
        }

        /*
         * Peforms HTTP Get call to an endpoint
         */
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

        /*
         * Performs HTTP Patch call to an endpoint
         */
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

        /*
         * Converts a dictionary to query string
         */
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
