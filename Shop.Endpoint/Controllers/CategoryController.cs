using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Application.Service;
using Demo.Contracts;
using Demo.Domain;
using Microsoft.AspNetCore.Mvc;
using Shop.Endpoint.Models;

namespace Shop.Endpoint.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Cart cart;
        private readonly IProductFacade productFacade;

        public CategoryController(Cart cart, IProductFacade productFacade)
        {
            this.cart = cart;
            this.productFacade = productFacade;
        }
        public IActionResult HealthProducts(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(1, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult FaceMakeup(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(2, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult Eyemakeup(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(3, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult EyebrowMakeup(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(4, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult LipMakeup(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(5, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult Skincareup(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(6, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult Haircareup(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(7, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
        public IActionResult MakeupTool(int Categoryid, int page = 1)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            var prodcuts = productFacade.GetCategory(8, page, 8);
            PagedList<Product> pageList = new PagedList<Product>(prodcuts.Item1, page, 8, prodcuts.Item2);
            return View(pageList);
        }
    }
}