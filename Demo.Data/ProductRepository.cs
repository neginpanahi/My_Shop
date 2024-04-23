using Demo.Contracts;
using Demo.Domain;
using Demo.Infra.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Infra.Data
{
     public class ProductRepository : IProductRepository
    {
        private readonly ShopContext Context;
        public ProductRepository(ShopContext Context)
        {
            this.Context = Context;
        }
        public Product Get(int ProductId)
        {
            return Context.Products.Include(a => a.Medias)
                .First(a => a.ProductID == ProductId);
        }
        List<Product> IProductRepository.GetChippestProduct()
        {
            List<Product> result = new List<Product>();
            foreach (var category in Context.Categories.ToList())
            {
                int minPrice = Context.Products.Include(a => a.Category).Where(a => a.Category == category)
                    .Min(a => a.Price);
                result.Add(Context.Products.Include(a => a.Medias).First(a => a.Price == minPrice));

            }
            return result;
        }

        (List<Product>, int Count) IProductRepository.GetFilterProducts(string search, string category, int pageNumber, int PageSize)
        {
            IQueryable<Product> Query = Context.Products.Include(a => a.Category).Include(a => a.Medias);
            if (!string.IsNullOrEmpty(search))
            {
                Query = Query.Where(a => a.Name.Contains(search) || a.Description.Contains(search));
            }
            if (category != "All")
            {
                Query = Query.Where(a => a.Category.CategoryName == category);
            }
            var lengthQuery = Query.ToList().Count;

            return (Query.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList(), lengthQuery);
        }
        public List<Product> GetNewstProduct()
        {
            return Context.Products.Include(a => a.Medias)
            .OrderByDescending(a => a.InseretTime).ToList();
        }
        public (List<Product>, int Count) GetCategory(int Categoryid, int pageNumber, int PageSize)
        {
            var query = Context.Products.Include(a => a.Medias).Where(a => a.Category.CategoryId == Categoryid).ToList();
            var lengthQuery = query.ToList().Count;
            return (query.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList(), lengthQuery);
        }
            public List<Product> GetAll()
        {
            return Context.Products.Include(a => a.Medias)
                .ToList();
        }
    }
}