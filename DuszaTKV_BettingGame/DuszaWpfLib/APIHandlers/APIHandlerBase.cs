using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DuszaTKVGameLib.APIHandlers
{
    public abstract class APIHandlerBase
    {
        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _options;
        protected APIHandlerBase(string baseUrl = "http://127.0.0.1:5133/BettingGame/")
        {
            _options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(baseUrl)
            };
        }
    }
}
