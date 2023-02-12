using ECommerce.Web.Models.Catalogs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Web.Services.Abstract
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetAllProductAsync();
        Task<bool> CreateProductAsync(ProductCreateViewModel productCreateViewModel);
        Task<bool> UpdateProductAsync(ProductUpdateViewModel productUpdateViewModel);
        Task<bool> DeleteProductAsync(string Id);
    }
}
