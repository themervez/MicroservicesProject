using AutoMapper;
using ECommerce.Services.Catalog.DTOs;
using ECommerce.Services.Catalog.Models;
using ECommerce.Services.Catalog.Services.Abstract;
using ECommerce.Services.Catalog.Settings;
using ECommerce.Shared.DTOs;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        public CategoryService(IDatabaseSettings databaseSettings, IMapper mapper)//Constructor
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }
        public async Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<List<CategoryDto>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ResponseDto<CategoryDto>> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
