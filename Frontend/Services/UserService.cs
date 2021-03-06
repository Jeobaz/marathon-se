﻿using Backend.Models;
using Frontend.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace Frontend.Services
{
    public class UserService : IUserService
    {
        private  HttpClient _httpClient { get; }
        private IOptions<BackendDomain> _config { get; }

        public UserService(HttpClient httpClient, IOptions<BackendDomain> config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<UserWithToken> LoginAsync(User user)
        {
            var serializedUser = JsonConvert.SerializeObject(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Users/Login/");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<UserWithToken>(responseBody);

            return await Task.FromResult(returnedUser);

        }

        public async Task<User> GetUserByEmail(string email)
        {
            var serializedUser = JsonConvert.SerializeObject(email);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Users/email/");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

            return await Task.FromResult(returnedUser);
        }

        public async Task<User> GetUserByToken(string token)
        {
            string serializedRefreshRequest = JsonConvert.SerializeObject(token);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Users/user_by_token");
            requestMessage.Content = new StringContent(serializedRefreshRequest);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

            return await Task.FromResult(returnedUser);
        }

        public async Task<string> GetTokenByUser(User user)
        {
            string serializedRefreshRequest = JsonConvert.SerializeObject(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Users/token_by_user");
            requestMessage.Content = new StringContent(serializedRefreshRequest);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedToken = JsonConvert.DeserializeObject<string>(responseBody);

            return await Task.FromResult(returnedToken);
        }

        public async Task EditUserAsync(User user)
        {
            var serializedUser = JsonConvert.SerializeObject(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_config.Value.Domain}/api/Users/{user.Email}/");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            var serializedUser = JsonConvert.SerializeObject(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Users/");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<User>(responseBody);

            return await Task.FromResult(returnedUser);
        }
    }
}
