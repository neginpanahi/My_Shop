using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Contracts
{
   public interface IProductFacade
    {
        Product Get(int ProductId);
        List<Product> GetAll();
        (List<Product>, int) ProductSearch(string q, string category, int pageNumber, int PageSize);
        (List<Product>, int Count) GetCategory(int Categoryid, int pageNumber, int PageSize);
        List<Product> GetChippestProduct();
        List<Product> GetNewestProduct();
    }
}
