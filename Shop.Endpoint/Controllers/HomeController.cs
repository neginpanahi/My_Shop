using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using demo.Application.Service;
using Demo.Contracts;
using Demo.Domain;
using Microsoft.AspNetCore.Mvc;
using Shop.Endpoint.Models;

namespace Shop.Endpoint.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductFacade productFacade;
        private readonly Cart cart;
        public HomeController(IProductFacade productFacade, Cart cart)
        {
            this.productFacade = productFacade;
            this.cart = cart;
        }
        public IActionResult Index()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            List<Product> products = productFacade.GetChippestProduct();
            return View(products);
        }
        public IActionResult Search(int page =1, string category = "All", string q = "")
        {
            var data =productFacade.ProductSearch(q, category, page, 4);
            PagedList<Product> pageList = new PagedList<Product>(data.Item1, page, 4, data.Item2);
            ViewBag.category = category;
            ViewBag.q = q;
            return View(pageList);
        }
        public IActionResult Products()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            List<Product> products = productFacade.GetAll();
            return View(products);
        }
        public IActionResult ShopSingle(int Id)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            Product product = productFacade.Get(Id);
            return View(product);
        }
        public IActionResult About()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View();
        }
        public IActionResult Contact()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View();
        }
        public IActionResult Cart()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View(cart);
        }
        public IActionResult AddToCart(int productId, int qunaity)
        {
            string referer = Request.Headers["Referer"].ToString();
            Product product = productFacade.Get(productId);
            if (product != null)
            {
                cart.AddItem(product, qunaity);
            }
            return Redirect(referer);
        }
        public IActionResult RemoveAtCart(int productId)
        {
            string referer = Request.Headers["Referer"].ToString();
            cart.RemoveLine(productId);
            return Redirect(referer);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
