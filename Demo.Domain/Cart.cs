using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Domain
{
     public class Cart
    {
        private List<CartLine> Lines = new List<CartLine>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine cartLine = GetCartLine(product.ProductID);
            if (cartLine != null)
            {
                cartLine.Quantity += quantity;
            }
            else
            {
                Lines.Add(new CartLine() { Quantity = quantity, Product = product });
            }
        }
        public virtual void RemoveLine(int productId)
        {
            Lines.RemoveAll(a => a.Product.ProductID == productId);
        }

        public virtual int GetTotalPrice()
        {
            return Lines.Sum(e => e.Product.Price * e.Quantity);
        }
        public virtual void Clear()
        {
            Lines.Clear();
        }
        public virtual int CalculateCartCount()
        {
            var count = 0;
            for (int i = 0; i < Lines.Count;)
            {
                count = ++i;
            }
            return count;
        }
        public IEnumerable<CartLine> CartLines { get => Lines; }

        private CartLine GetCartLine(int productId)
        {
            return Lines.FirstOrDefault(p => p.Product.ProductID == productId);
        }

    }
}
