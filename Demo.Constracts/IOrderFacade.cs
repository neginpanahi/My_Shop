﻿using Demo.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Contracts
{
    public interface IOrderFacade
    {
        void SaveOrder(Order order);

        void SetTransactionId(int orderId, string token);

        void PaymentDone(string token, string tId);
    }
}

