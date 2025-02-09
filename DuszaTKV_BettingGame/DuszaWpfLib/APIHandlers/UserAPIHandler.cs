using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text.Json;
using DuszaTKVGameLib.DTOs.UserDTOs;
using System.Net.Http;

namespace DuszaTKVGameLib.APIHandlers
{
    public class UserAPIHandler : APIHandlerBase
    {
        public User GetUser(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.GetAsync($"BettingGame/User/${id}").Result;
            message.EnsureSuccessStatusCode();
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<User>(json, _options)!;
        }
        public void CreateUser(CreateUserDto createDto)
        {
            string json = JsonSerializer.Serialize(createDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("BettingGame/User", content).Result;
            message.EnsureSuccessStatusCode();
        }
        public void UpdateEvent(int id, UpdateUserDto updateDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(updateDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PutAsync($"BettingGame/User/{id}", content).Result;
            message.EnsureSuccessStatusCode();
        }
        public void DeleteBet(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.DeleteAsync($"BettingGame/User/{id}").Result;
            message.EnsureSuccessStatusCode();
        }
        public LoginUserDto Login(CreateUserDto login)
        {
            string json = JsonSerializer.Serialize(login, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("BettingGame/Login", content).Result;
            message.EnsureSuccessStatusCode();
            string response = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<LoginUserDto>(response, _options)!;
        }
    }
}
