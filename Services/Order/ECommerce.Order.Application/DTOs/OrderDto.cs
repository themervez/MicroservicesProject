using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public AddressDto Address { get; set; }
        public string BuyerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
