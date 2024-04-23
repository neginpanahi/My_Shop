using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Contracts
{
     public interface IProductRepository
    {
        Product Get(int ProductId);
        List<Product> GetAll();
        (List<Product>, int Count) GetFilterProducts(string search, string category, int pageNumber, int PageSize);

        List<Product> GetChippestProduct();
        List<Product> GetNewstProduct();
        (List<Product>, int Count) GetCategory(int categoryid, int pageNumber, int pageSize);
    }
}
