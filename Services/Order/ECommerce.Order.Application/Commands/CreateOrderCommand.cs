using ECommerce.Order.Application.DTOs;
using ECommerce.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Commands
{
    public class CreateOrderCommand:IRequest<ResponseDto<CreatedOrderDto>>
    {
        public string BuyerId { get; set; }
        public AddressDto Address { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
