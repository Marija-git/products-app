using ProductsApp.API.DTOs.Request;
using ProductsApp.API.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsApp.GUI.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public ProductService()
        {
            _httpClient = new HttpClient();
            _url = Properties.Settings.Default.ApiBaseUrl;  
        }

        public async Task<ProductDtoResponse> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductDtoResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            throw new Exception($"API Error: {response.StatusCode}");
        }

        public async Task<ProductDtoResponse> GetByIdWithCategoriesAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_url}/{id}/with-categories");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductDtoResponse>(json, GetJsonOptions());
            }

            throw new Exception($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        public async Task<List<ProductDtoResponse>> GetAllWithCategoriesAsync()
        {
            var response = await _httpClient.GetAsync($"{_url}/with-categories");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<ProductDtoResponse>>(json, GetJsonOptions());
            }

            throw new Exception($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
        }

        public async Task<ProductDtoResponse> AddProductAsync(ProductDtoRequest dto)
        {
            var json = JsonSerializer.Serialize(dto, GetJsonOptions());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductDtoResponse>(responseJson, GetJsonOptions());
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"API Error: {response.StatusCode} - {errorContent}");
        }

        public async Task<ProductDtoResponse> UpdateProductAsync(int id, ProductDtoRequest dto)
        {
            var json = JsonSerializer.Serialize(dto, GetJsonOptions());
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_url}/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ProductDtoResponse>(responseJson, GetJsonOptions());
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new Exception($"API Error: {response.StatusCode} - {errorContent}");
        }

        public async Task DeleteProductAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"{_url}?productId={productId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"API Error: {response.StatusCode} - {errorContent}");
            }
        }

        private JsonSerializerOptions GetJsonOptions()
        {
            return new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }


        public void Dispose()
        {
            _httpClient?.Dispose();
        }

    }
}
