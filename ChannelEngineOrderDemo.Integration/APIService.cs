using ChannelEngineOrderDemo.Core;
using ChannelEngineOrderDemo.Logic.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChannelEngineOrderDemo.Integration
{
    public abstract class APIService<T> : IDataService<T>
    {
        protected string _apiPathMajor;

        protected string _apiPathMinor;

        private readonly HttpClient _client;

        public APIService(string apiPathMajor, string apiPathMinor, HttpClient client)
        {
            _apiPathMajor = apiPathMajor;
            _apiPathMinor = apiPathMinor;
            _client = client;
        }

        public async Task<IList<T>> GetList(IDictionary<string, string> filters)
        {
            return ExtractGetListFromResponse(await Get(_apiPathMajor + _apiPathMinor, DictionaryToQueryString(filters)));
        }

        protected abstract IList<T> ExtractGetListFromResponse(string response);

        protected async Task<string> Get(string url, string queryString)
        {
            var response = await _client.GetAsync(url + "?" + queryString);
            if (!response.IsSuccessStatusCode)
            {
                // TODO: Log the error and return
                throw new Exception(response.StatusCode.ToString());
            }
            return await response.Content.ReadAsStringAsync();
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
