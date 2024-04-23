using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Contracts;
using Demo.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Endpoint.Controllers
{
    public class CheckoutController : Controller
    {
       
        private readonly IOrderFacade orderFacade;
        private readonly Cart cart;

        public CheckoutController(IOrderFacade orderFacade,Cart cart)
        {
            
            this.orderFacade = orderFacade;
            this.cart = cart;
        }
        public IActionResult Index()
        { 
         var cartCount = cart.CalculateCartCount();
        ViewBag.CartCount = cartCount;
            ViewBag.Cart=cart;
            return View(new Order());
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(Order order)
        {
            var totalPice = cart.GetTotalPrice();
            if (cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "سفارشی موجود نیست");
            }

            if (ModelState.IsValid)
            {
                order.Lines = cart.CartLines.ToList();
                orderFacade.SaveOrder(order);
                cart.Clear();
                return RedirectToAction("Pay", "Payment", new { orderId = order.OrderID, totalPrice = totalPice });
            }
            return View(order);
        }
    }
}