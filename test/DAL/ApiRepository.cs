using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CaseStudy.DAL
{
    class ApiRepository
    {
        private static readonly HttpClient _client = new HttpClient();
        private string _apiKey;

        public ApiRepository(string apiKey)
        {
            _apiKey = apiKey;
        }

        public List<Api> GetApiByCountries(Covid covid)
        {
            List<Api> apiResults = new List<Api>();

            
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://covid-19-data.p.rapidapi.com/country/code?code=" + covid.Code),
                    Headers =
    {
        { "x-rapidapi-host", "covid-19-data.p.rapidapi.com" },
        { "x-rapidapi-key", _apiKey },
    },
                };
                HttpResponseMessage response = client.Send(request);
                using (var reader = new StreamReader(response.Content.ReadAsStream()))
                {
                    apiResults = JsonSerializer.Deserialize<List<Api>>(reader.ReadToEnd());
                }
                return apiResults;
            }
            
        }
    
}

