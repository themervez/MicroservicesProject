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
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;
        public ProductService(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);

            _mapper = mapper;

        }
        public Task<ResponseDto<ProductDto>> CreateAsync(ProductDto productDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<NoContent>> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<List<ProductDto>>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<ProductDto>> GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResponseDto<NoContent>> UpdateAsync(UpdateProductDto updateProductDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
