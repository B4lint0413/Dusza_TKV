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
            var message = _httpClient.GetAsync($"BettingGame/Bet/${id}").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Bet>(json, _options)!;
        }
        public void CreateBet(CreateBetDto createDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(createDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("BettingGame/Bet", content).Result;
            message.EnsureSuccessStatusCode();
        }
        public void UpdateBet(int id, UpdateBetDto updateDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(updateDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PutAsync($"BettingGame/Bet/{id}", content).Result;
            message.EnsureSuccessStatusCode();
        }
        public void DeleteBet(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.DeleteAsync($"BettingGame/Bet/{id}").Result;
            message.EnsureSuccessStatusCode();
        }
    }
}
