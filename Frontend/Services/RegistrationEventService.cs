using Backend.Models;
using Frontend.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class RegistrationEventService : IRegistrationEventService
    {
        private HttpClient _httpClient { get; }
        private IOptions<BackendDomain> _config { get; }

        public RegistrationEventService(HttpClient httpClient, IOptions<BackendDomain> config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<bool> AcceptToRegisterAsync(RegistrationEvent registrationEvent)
        {
            var serializedRegistartionEvent = JsonConvert.SerializeObject(registrationEvent);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/RegistrationEvents/accepttoregister/");
            requestMessage.Content = new StringContent(serializedRegistartionEvent);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedAccess = JsonConvert.DeserializeObject<bool>(responseBody);

            return await Task.FromResult(returnedAccess);
        }

        public async Task<RegistrationEvent> RegisterAsync(RegistrationEvent registrationEvent)
        {
            var serializedRegistartionEvent = JsonConvert.SerializeObject(registrationEvent);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/RegistrationEvents/");
            requestMessage.Content = new StringContent(serializedRegistartionEvent);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedRegister = JsonConvert.DeserializeObject<RegistrationEvent>(responseBody);

            return await Task.FromResult(returnedRegister);
        }
    }
}
