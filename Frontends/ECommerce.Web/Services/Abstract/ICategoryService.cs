using ECommerce.Web.Models.Catalogs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Web.Services.Abstract
{
    public interface ICategoryService
    {
        Task<List<CategoryViewModel>> GetAllCategoryAsync();
    }
}
