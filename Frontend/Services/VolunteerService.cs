using Backend.Models;
using Frontend.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class VolunteerService : IVolunteerService
    {
        private HttpClient _httpClient { get; }
        private IOptions<BackendDomain> _config { get; }

        public VolunteerService(HttpClient httpClient, IOptions<BackendDomain> config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<Volunteer> AddVolunteerAsync(Volunteer volunteer)
        {
            var serializedVolunteer = JsonConvert.SerializeObject(volunteer);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Volunteers/");
            requestMessage.Content = new StringContent(serializedVolunteer);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedVolunteer = JsonConvert.DeserializeObject<Volunteer>(responseBody);

            return await Task.FromResult(returnedVolunteer);
        }

        public async Task<Volunteer> EditVolunteerAsync(Volunteer volunteer)
        {
            var serializedVolunteer = JsonConvert.SerializeObject(volunteer);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_config.Value.Domain}/api/Volunteers/");
            requestMessage.Content = new StringContent(serializedVolunteer);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedVolunteer = JsonConvert.DeserializeObject<Volunteer>(responseBody);

            return await Task.FromResult(returnedVolunteer);
        }

        public async Task<bool> ExistVolunteerAsync(int volunteerId)
        {
            return await _httpClient.GetJsonAsync<bool>($"{_config.Value.Domain}/api/Volunteers/exist/{volunteerId}");
        }
    }
}
