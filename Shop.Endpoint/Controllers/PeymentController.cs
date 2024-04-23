using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Contracts;
using Microsoft.AspNetCore.Mvc;
using Shop.Endpoint.Models;
using Shop.Endpoint.Models.PeymentSistem;
using static Shop.Endpoint.Models.PeymentInfo;

namespace Shop.Endpoint.Controllers
{
    public class PeymentController : Controller
    {
        private readonly IDPay iDPay;
        private readonly IOrderFacade orderFacade;

        public PeymentController(IDPay iDPay, IOrderFacade orderFacade)
        {
            this.iDPay = iDPay;
            this.orderFacade = orderFacade;
        }
        public async Task<IActionResult> Pay (int orderId, int totalprice)
        {
            PaymentRequestModel model = new PaymentRequestModel(orderId.ToString());
            model.amount = totalprice;

            var result = await iDPay.RequestPayment(model);
            if (result.Item2)
            {
                SucessRequestRespons item = result.Item1 as SucessRequestRespons;
                orderFacade.SetTransactionId(orderId, item.Id);
                return Redirect(item.Link);
            }
            return View();
        }

        public async Task<IActionResult> Verify(ResultPayment model)
        {
            if (model.IsOK == true)
            {
                var res = await iDPay.VerifyPayment(model);
                PaymentInfo info = res as PaymentInfo;
                orderFacade.PaymentDone(info.id, info.track_id);
                //VerifyPayment verifyResult = payment.Verify(model.token.ToString());
                //if (verifyResult.Status == 1)
                //{
                //    orderService.PaymentDone(model.token, verifyResult.transId);
                return Content($"پرداخت با موفقیت انجام شد شماره پیگیری {info.track_id}");
                //}
            }
            return View(model);
  }
public IActionResult Thankyou()
{
    return View();
}
}
}