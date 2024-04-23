using Demo.Contracts;
using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace demo.Application.Service
{
    public class ProductFacade : IProductFacade
    {
        private readonly IProductRepository productRepository;

        public ProductFacade(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public List<Product> GetChippestProduct()
        {
            return productRepository.GetChippestProduct()
                 .Take(6).ToList();
        }
        public Product Get(int ProductId)
        {
            return productRepository.Get(ProductId);
        }

        public (List<Product>, int) ProductSearch(string q, string category, int pageNumber, int PageSize)
        {
            return productRepository.GetFilterProducts(q, category, pageNumber, PageSize);
        }
        public List<Product> GetNewestProduct()
        {
            return productRepository.GetNewstProduct();
        }
        public (List<Product>, int) GetCategory(int Categoryid, int pageNumber, int PageSize)
        {
            return productRepository.GetCategory(Categoryid, pageNumber, PageSize);
        }
            public List<Product> GetAll()
        {
            return productRepository.GetAll();
        }
    }
}


