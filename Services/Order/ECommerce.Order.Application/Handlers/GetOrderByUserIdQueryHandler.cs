using AutoMapper;
using AutoMapper.Internal.Mappers;
using ECommerce.Order.Application.DTOs;
using ECommerce.Order.Application.Queries;
using ECommerce.Order.Infrastructure;
using ECommerce.Shared.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Handlers
{
    public class GetOrderByUserIdQueryHandler : IRequestHandler<GetOrdersByUserIdQuery, ResponseDto<List<OrderDto>>>
    {
        private readonly OrderDbContext _orderDbContext;
        private readonly IMapper _mapper;

        public GetOrderByUserIdQueryHandler(OrderDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public async Task<ResponseDto<List<OrderDto>>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderDbContext.Orders.Include(x => x.orderItems).Where(x => x.BuyerId == request.UserId).ToListAsync();

                return ResponseDto<List<OrderDto>>.Success(_mapper.Map<List<OrderDto>>(orders), 200);
            //Mapping here
        }
    }
}
