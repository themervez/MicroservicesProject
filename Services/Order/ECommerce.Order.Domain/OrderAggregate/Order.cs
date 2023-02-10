using ECommerce.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; set; }
        public Address Address { get; set; }
        public string BuyerId { get; set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> orderItems => _orderItems;
        public Order()//Constructor
        {

        }
        public Order(string buyerId, Address address)//Overload Constructor
        {
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
            BuyerId = buyerId;
            Address = address;
        }

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            var existProduct = _orderItems.Any(x => x.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }
        public decimal GetTotalPrice => _orderItems.Sum(x => x.Price);
    }
}
