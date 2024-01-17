using Azure.Core;
using DeliveryApplication.Models;
using DeliveryApplication.Models.DataBase;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeliveryApplication.Controllers
{
    public class HomeController : Controller
    {
        private OrderService orderService;

        public HomeController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult Home()
        {
            return View(orderService.GetAllOrders());
        }

        [HttpPost]
        public IActionResult ShowOrder(long orderNumber)
        {
            Order? order = orderService.GetOrderByNumber(orderNumber);

            if (order != null)
                return View(order);
            else
                return NotFound();
        }
    }
}





//Order order = new Order();
//order.AddressOfSender = "street 1";
//order.AddressOfRecipient = "street 16";
//order.CityOfSender = "Spb";
//order.CityOfRecipient = "Moscow";
//order.CargoWeight = 1.3;
//orderService.AddNewOrder(order);

//order = new Order();
//order.AddressOfSender = "street 1";
//order.AddressOfRecipient = "street 16";
//order.CityOfSender = "Surgut";
//order.CityOfRecipient = "Tuymen";
//order.CargoWeight = 2.5;
//orderService.AddNewOrder(order);

//order = new Order();
//order.AddressOfSender = "street 34";
//order.AddressOfRecipient = "street 23";
//order.CityOfSender = "Spt";
//order.CityOfRecipient = "Astana";
//order.CargoWeight = 3;
//orderService.AddNewOrder(order);