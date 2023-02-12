using ECommerce.Shared.DTOs;
using ECommerce.Web.Models.Catalogs;
using ECommerce.Web.Services.Abstract;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ECommerce.Web.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;

        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<CategoryViewModel>> GetAllCategoryAsync()
        {
            var response = await _client.GetAsync("Category");
            //if (!response.IsSuccessStatusCode)
            //{
            //    return null;
            //}
            var responseSuccess = await response.Content.ReadFromJsonAsync<ResponseDto<List<CategoryViewModel>>>();
            return responseSuccess.Data;//showing data to user
        }
    }
}
