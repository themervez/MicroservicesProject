using ECommerce.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Domain.OrderAggregate
{
    public class OrderItem:Entity
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public OrderItem()
        {

        }
        public OrderItem(string productId, string name, string pictureUrl, decimal price)
        {
            ProductId = productId;
            Name = name;
            PictureUrl = pictureUrl;
            Price = price;
        }
        public void UpdateOrderItem(string name, string pictureUrl, decimal price)
        {
            Name = name;
            PictureUrl = pictureUrl;
            Price = price;
        }
    }
}
