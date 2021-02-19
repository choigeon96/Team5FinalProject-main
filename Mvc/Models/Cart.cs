using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class CartLine
    {
        public Product Product { get; set; }
        public int Qty { get; set; }
    }

    public class Cart
    {
        List<CartLine> lines = new List<CartLine>();
        public List<CartLine> Lines
        {
            get { return lines; }
        }

        public void AddItem(Product prod, int qty)
        {
            //이미 추가된 제품이면 수량만 증가, 아니면 제품 list에 추가
            CartLine line = lines.Where<CartLine>(p => p.Product.ProductID == prod.ProductID).FirstOrDefault();

            if (line != null)
            {
                line.Qty = line.Qty + qty;
            }
            else
            {
                lines.Add(new CartLine
                {
                    Product = prod,
                    Qty = qty
                });
            }
        }

        public void RemoveItem(int productID)
        {
            lines.RemoveAll(i => i.Product.ProductID == productID);
        }

        public decimal CalcTotalValue()
        {
            return lines.Sum<CartLine>(p => p.Product.Price * p.Qty);
        }

        public void Clear()
        {
            lines.Clear();
        }
    }
}