using ECommerce.Shared.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<ResponseDto<List<Models.Discount>>> GetAll();
        Task<ResponseDto<Models.Discount>> GetByID(int id);
        Task<ResponseDto<NoContent>> Save(Models.Discount discount);
        Task<ResponseDto<NoContent>> Update(Models.Discount discount);
        Task<ResponseDto<NoContent>> Delete(int id);
        Task<ResponseDto<Models.Discount>> GetByCodeUserId(string code, string userId);
    }
}
