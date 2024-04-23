using Demo.Contracts;
using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace demo.Application.Service
{
    public class OrderFacade : IOrderFacade
    {
        private readonly IOrderRepository orderRepository;

        public OrderFacade(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public void PaymentDone(string token, string tId)
        {
            orderRepository.PaymentDone(token, tId);
        }

        public void SaveOrder(Order order)
        {
            orderRepository.Save(order);
        }

        public void SetTransactionId(int orderId, string token)
        {
            orderRepository.SetOrderToken(orderId, token);
        }
    }
}