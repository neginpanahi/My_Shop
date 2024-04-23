using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Contracts;
using Demo.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Endpoint.Models;

namespace Identity.Controllers
{
    public class IdentityController : Controller
    {
        private readonly Cart cart;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IProductFacade productFacade;
        public IdentityController(Cart cart,UserManager <IdentityUser> userManager,RoleManager<IdentityRole> roleManager,SignInManager<IdentityUser> signInManager, IProductFacade productFacade)
        {
            this.cart = cart;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.productFacade = productFacade;
        }
        public IActionResult Register()
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser appUser = new IdentityUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                };
                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(appUser, "guest");
                    return RedirectToAction("Index", "home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
            }
            return View(user);
        }
          public IActionResult Login(string ReturnUrl)
        {
            var cartCount = cart.CalculateCartCount();
            ViewBag.CartCount = cartCount;
            LoginViewModel loginmodel = new LoginViewModel();
            loginmodel.ReturnUrl = ReturnUrl;
            return View(loginmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginmodel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByEmailAsync(loginmodel.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginmodel.Password, true, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("index","home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "کاربری با این مشخصات پیدا نشد");
                }
            }
                return View();
            }
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            ProductViewModel viewModel = new ProductViewModel();
            viewModel.products = productFacade.GetAll();
            return View(viewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index","home");
        }
        public IActionResult AccessDenied()
        {
            return Content("دسترسی شما امکان پذیر نیست");
        }
    }
    }
