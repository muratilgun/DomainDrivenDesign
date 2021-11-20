using DDD.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.AggregateModels.OrderModels
{
    public class Order : BaseEntity, IAggregateRoot
    {
        public DateTime OrderDate { get; private set; }
        public string Description { get; private set; }
        public int BuyerId { get; private set; }
        public string OrderStatus { get; private set; }
        public Address Address { get; private set; }
        public ICollection<OrderItem> OrderItems { get; set; }

        public Order(DateTime orderDate, string description, int buyerId, string orderStatus, Address address, ICollection<OrderItem> orderItems)
        {
            if (orderDate < DateTime.Now)
                throw new Exception("Orderdate must be greater than now");
            if (address.City == "")
                throw new Exception("city cannot be empty");
            OrderDate = orderDate;
            Description = description ?? throw new ArgumentNullException(nameof(description));
            BuyerId = buyerId;
            OrderStatus = orderStatus ?? throw new ArgumentNullException(nameof(orderStatus));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            OrderItems = orderItems ?? throw new ArgumentNullException(nameof(orderItems));
        }
        public void AddOrderItem(int quantity, decimal price, int productId)
        {
            OrderItem item = new(quantity, productId, productId);

            OrderItems.Add(item);
        }
    }
}
