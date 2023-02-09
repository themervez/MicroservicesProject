using ECommerce.Services.Basket.DTOs;
using ECommerce.Shared.DTOs;
using System.Threading.Tasks;

namespace ECommerce.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<ResponseDto<BasketDto>> GetBasket(string userId);
        Task<ResponseDto<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<ResponseDto<bool>> Delete(string userId);
    }
}
