using DeliveryApplication.Models;
using DeliveryApplication.Models.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryApplication.Controllers
{ 
    public class CreateNewOrderController : Controller
    {
        private OrderService orderService;

        public CreateNewOrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public IActionResult CreateNewOrderForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowNewOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                long orderNumber = orderService.AddNewOrder(order);
                order.OrderNumber = orderNumber;
                return View(order);
            }
            else
            {
                return RedirectToAction("CreateNewOrderForm");
            }
        }
    }
}
