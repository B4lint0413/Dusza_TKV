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
            var message = _httpClient.GetAsync($"Event").Result;
            ExceptionHandler.CheckHttpResponse(message);
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<IEnumerable<Event>>(json, _options)!;
        } 
        public Event GetEvent(int id)
        {
            var message = _httpClient.GetAsync($"Event/${id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Event>(json, _options)!;
        }
        public void CreateEvent(CreateEventDto createDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(createDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("Event", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void UpdateEvent(int id, UpdateEventDto updateDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(updateDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PutAsync($"Event/{id}", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void DeleteBet(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.DeleteAsync($"Event/{id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
    }
}
