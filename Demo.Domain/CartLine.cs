using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain
{
   public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
