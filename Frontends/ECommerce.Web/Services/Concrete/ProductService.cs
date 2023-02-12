using ECommerce.Shared.DTOs;
using ECommerce.Web.Models.Catalogs;
using ECommerce.Web.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ECommerce.Web.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<bool> CreateProductAsync(ProductCreateViewModel productCreateViewModel)
        {
            var response = await _client.PostAsJsonAsync<ProductCreateViewModel>("Product", productCreateViewModel);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(string Id)
        {
            var response = await _client.DeleteAsync($"Product/{Id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<List<ProductViewModel>> GetAllProductAsync()
        {
            var response = await _client.GetAsync("Product");
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var responseSuccess = await response.Content.ReadFromJsonAsync<ResponseDto<List<ProductViewModel>>>();
            return responseSuccess.Data;
        }

        public async Task<bool> UpdateProductAsync(ProductUpdateViewModel productUpdateViewModel)
        {
            var response = await _client.PutAsJsonAsync<ProductUpdateViewModel>("Product", productUpdateViewModel);
            return response.IsSuccessStatusCode;
        }
    }
}
