using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TOS.Common.Serialization.Json;

namespace TOS.CaseChecker.Application.Utils
{
    public class HttpDataLoader : IHttpDataLoader
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonSerializer _jsonSerializer;

        public HttpDataLoader(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                Proxy = new System.Net.WebProxy("127.0.0.1:8118"),
                UseProxy = true,
            };
            _httpClient = new HttpClient(httpClientHandler);

        }

        public async Task<IEnumerable<CaseInfoDto>> LoadCasesAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return _jsonSerializer.Deserialize<Result<CaseInfoDto[]>>(responseBody).Value;
        }

        public class Result<T>
        {
            public T Value { get; set; }
        }
    }
}
