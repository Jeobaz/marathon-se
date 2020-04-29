using Backend.Models;
using Frontend.Data;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Services
{
    public class CharityService : ICharityService
    {
        private HttpClient _httpClient { get; }
        private IOptions<BackendDomain> _config { get; }

        public CharityService(HttpClient httpClient, IOptions<BackendDomain> config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<Charity> AddCharity(Charity charity)
        {
            var serializedCharity = JsonConvert.SerializeObject(charity);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Charities/");
            requestMessage.Content = new StringContent(serializedCharity);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedCharity = JsonConvert.DeserializeObject<Charity>(responseBody);

            return await Task.FromResult(returnedCharity);
        }

        public async Task<Charity> EditCharity(Charity charity)
        {
            var serializedCharity = JsonConvert.SerializeObject(charity);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_config.Value.Domain}/api/Charities/{charity.CharityId}");
            requestMessage.Content = new StringContent(serializedCharity);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;
            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedCharity = JsonConvert.DeserializeObject<Charity>(responseBody);

            return await Task.FromResult(returnedCharity);
        }
    }
}
