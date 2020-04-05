using Backend.Models;
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
    public class RunnerService : IRunnerService
    {
        private HttpClient _httpClient { get; }
        private IOptions<BackendDomain> _config { get; }

        public RunnerService(HttpClient httpClient, IOptions<BackendDomain> config)
        {
            _httpClient = httpClient;
            _config = config;
        }
        public async Task<Runner> RegisterRunnerAsync(Runner runner)
        {
            var serializedRunner = JsonConvert.SerializeObject(runner);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_config.Value.Domain}/api/Runners/Register/");
            requestMessage.Content = new StringContent(serializedRunner);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseBody = await response.Content.ReadAsStringAsync();

            var returnedUser = JsonConvert.DeserializeObject<Runner>(responseBody);

            return await Task.FromResult(returnedUser);
        }

        public async Task EditRunnerAsync(Runner runner)
        {
            var serializedRunner = JsonConvert.SerializeObject(runner);

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, $"{_config.Value.Domain}/api/Runners/{runner.RunnerId}/");
            requestMessage.Content = new StringContent(serializedRunner);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            //var responseBody = await response.Content.ReadAsStringAsync();
        }
    }
}
