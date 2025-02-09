using DuszaTKVGameLib.DTOs.GameDTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DuszaTKVGameLib.APIHandlers
{
    public class GameAPIHandler : APIHandlerBase
    {
        public IEnumerable<Game> GetGames()
        {
            var message = _httpClient.GetAsync("Game").Result;
            ExceptionHandler.CheckHttpResponse(message);
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<IEnumerable<Game>>(json, _options)!;
        }
        public Game GetGame(int id)
        {
            var message = _httpClient.GetAsync($"Game/{id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Game>(json, _options)!;
        }
        public void CreateGame(CreateGameDto createDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(createDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("Game", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void UpdateGame(int id, UpdateGameDto updateDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(updateDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PutAsync($"Game/{id}", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void DeleteGame(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.DeleteAsync($"Game/{id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
    }
}
