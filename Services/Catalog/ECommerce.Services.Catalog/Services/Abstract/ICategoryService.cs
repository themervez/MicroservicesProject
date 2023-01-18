using ECommerce.Services.Catalog.DTOs;
using ECommerce.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<ResponseDto<List<CategoryDto>>> GetAllAsync();//All Categories List
        Task<ResponseDto<CategoryDto>> CreateAsync(CategoryDto categoryDto);
        Task<ResponseDto<CategoryDto>> GetByIdAsync(string id);
    }
}
