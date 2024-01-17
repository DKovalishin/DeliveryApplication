using Microsoft.AspNetCore.Mvc;

namespace DeliveryApplication.Models.DataBase
{
    public class OrderService
    {
        private OrderDBContext context;

        public OrderService(OrderDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return context.orders;
        }

        public long AddNewOrder(Order order) // return unique number of order
        {
            order.OrderNumber = UniqueNumberGenerator.GenerateNumber();
            context.orders.Add(order);
            context.SaveChanges();
            return order.OrderNumber;   
        }

        public Order? GetOrderByNumber(long orderNumber)  // return order by number or null (if order doesnt exist)
        {
            return context.orders.Where(o => o.OrderNumber == orderNumber).Select(o => o).FirstOrDefault();
        }
    }

    public static class UniqueNumberGenerator
    {
        public static long GenerateNumber()
        {
            DateTime centuryBegin = new DateTime(2024, 1, 1);
            DateTime currentDate = DateTime.Now;
            long uniqueNumber = currentDate.Ticks - centuryBegin.Ticks;
            return uniqueNumber;
        }
    }
}
