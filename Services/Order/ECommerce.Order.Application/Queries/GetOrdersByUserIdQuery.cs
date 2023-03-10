using ECommerce.Order.Application.DTOs;
using ECommerce.Shared.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery : IRequest<ResponseDto<List<OrderDto>>>
    {
        public string UserId { get; set; }
    }
}
