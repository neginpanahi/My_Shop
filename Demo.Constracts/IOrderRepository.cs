using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Contracts
{
    public interface IOrderRepository
    {
        void Save(Order order);
        void SetOrderToken(int orderId, string token);
        void PaymentDone(string token, string tId);
    }
}
