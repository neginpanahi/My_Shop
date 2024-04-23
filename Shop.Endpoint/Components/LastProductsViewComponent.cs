using demo.Application.Service;
using Demo.Contracts;
using Demo.Infra.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Endpoint.Components
{
    public class LastProductsViewComponent:ViewComponent
    {
        private readonly IProductRepository productRepository;

        public LastProductsViewComponent(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = productRepository.GetNewstProduct().Take(6).ToList();
            return View(data);
        }
    }
}