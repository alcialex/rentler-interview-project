using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Rentler.Interview.Api.Entities;
using Rentler.Interview.Api;
using System.Linq;

namespace Rentler.Interview.Lib
{
    public class FoodClient
    {
        private readonly HttpClient _httpClient;
        public FoodClient(string httpUrl) {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(httpUrl);
        }

        public async Task<(PagingMetaData,List<Food>)> getAllFoods(int pageNumber = 1, int pageSize = 5, string searchTerm = "")
        {   
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using HttpResponseMessage response = await _httpClient.GetAsync($"/api/Foods?PageNumber={pageNumber}&PageSize={pageSize}&SearchTerm={searchTerm}");
            response.EnsureSuccessStatusCode();
            string jsonString = await response.Content.ReadAsStringAsync();
            var pagingHeader = string.Join(",", response.Headers.GetValues("Paging-Headers"));
            
            var pagingMetadata = JsonSerializer.Deserialize<PagingMetaData>(pagingHeader, options)!;
            var foods = JsonSerializer.Deserialize<List<Food>>(jsonString, options) ?? new List<Food>();

            return (pagingMetadata, foods);
        }

        public async Task<Food> getFood(int id) 
        {
          using HttpResponseMessage response = await _httpClient.GetAsync($"/api/Foods/{id}");
          response.EnsureSuccessStatusCode();
            
          string jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

          return  JsonSerializer.Deserialize<Food>(jsonString, options) ?? new Food();
        }

        public async Task<Food> getFoodsInPages(int id)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"/api/Foods/{id}");
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<Food>(jsonString, options) ?? new Food();
        }
    }
}
