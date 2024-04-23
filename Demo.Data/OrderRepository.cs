using Demo.Contracts;
using Demo.Domain;
using Demo.Infra.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infra.Data
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ShopContext shopContext;

        public OrderRepository(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public void PaymentDone(string token, string tId)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order)
        {
            throw new NotImplementedException();
        }

        public void SetOrderToken(int orderId, string token)
        {
            throw new NotImplementedException();
        }
    }
}
