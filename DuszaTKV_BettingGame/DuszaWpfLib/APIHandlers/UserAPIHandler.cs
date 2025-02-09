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
            var message = _httpClient.GetAsync($"User/{id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
            string json = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<User>(json, _options)!;
        }
        public void CreateUser(CreateUserDto createDto)
        {
            string json = JsonSerializer.Serialize(createDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("User", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void UpdateEvent(int id, UpdateUserDto updateDto, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            string json = JsonSerializer.Serialize(updateDto, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PutAsync($"User/{id}", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public void DeleteBet(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var message = _httpClient.DeleteAsync($"User/{id}").Result;
            ExceptionHandler.CheckHttpResponse(message);
        }
        public LoginUserDto Login(CreateUserDto login)
        {
            string json = JsonSerializer.Serialize(login, _options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var message = _httpClient.PostAsync("Login", content).Result;
            ExceptionHandler.CheckHttpResponse(message);
            string response = message.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<LoginUserDto>(response, _options)!;
        }
    }
}
