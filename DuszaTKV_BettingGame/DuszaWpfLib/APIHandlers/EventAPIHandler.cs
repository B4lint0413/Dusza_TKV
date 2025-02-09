using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Net.Http;
using DuszaTKVGameLib.DTOs.EventDTOs;

namespace DuszaTKVGameLib.APIHandlers
{
    public class EventAPIHandler : APIHandlerBase
    {
        public IEnumerable<Event> GetEvents()
        {
            var message = _httpClient.GetAsync($"BettingGame/Event").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<IEnumerable<Event>>(json, _options)!;
        } 
        public Event GetEvent(int id)
        {
            var message = _httpClient.GetAsync($"BettingGame/Event/${id}").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Event>(json, _options)!;
        }
        public void CreateEvent(CreateEventDto createDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(createDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("BettingGame/Event", content).Result;
            message.EnsureSuccessStatusCode();
        }
        public void UpdateEvent(int id, UpdateEventDto updateDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(updateDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PutAsync($"BettingGame/Event/{id}", content).Result;
            message.EnsureSuccessStatusCode();
        }
        public void DeleteBet(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.DeleteAsync($"BettingGame/Event/{id}").Result;
            message.EnsureSuccessStatusCode();
        }
    }
}
