using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using DuszaTKVGameLib.DTOs.BetDTOs;
using System.Net.Http;

namespace DuszaTKVGameLib.APIHandlers
{
    public class BetAPIHandler : APIHandlerBase
    {
        public Bet GetBet(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.GetAsync($"Bet/${id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Bet>(json, _options)!;
        }
        public void CreateBet(CreateBetDto createDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(createDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("Bet", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void UpdateBet(int id, UpdateBetDto updateDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(updateDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PutAsync($"Bet/{id}", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void DeleteBet(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.DeleteAsync($"Bet/{id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
    }
}
