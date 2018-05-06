using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JCSoft.SSA.Tools.Http
{
    public class HttpHelper : IHttpHelper
    {
        private static HttpClient _client = new HttpClient();
        static HttpHelper()
        {
            //init http client settings
            _client.Timeout = new TimeSpan(0, 0, 5);

        }
        public async Task<string> DeleteAsync(string url)
            => await (await _client.DeleteAsync(url)).Content.ReadAsStringAsync();

        public async Task<string> GetAsync(string url)
            => await (await _client.GetAsync(url)).Content.ReadAsStringAsync();

        public async Task<string> PostAsync(string url, string data)
            => await (await _client.PostAsync(url, new JsonContent(data))).Content.ReadAsStringAsync();

        public async Task<string> PutAsync(string url, string data)
            => await (await _client.PutAsync(url, new JsonContent(data))).Content.ReadAsStringAsync();
    }
}
