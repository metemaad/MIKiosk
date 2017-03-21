using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    public class OrderItem:Entity
    {
        public virtual Product Product { get; set; }

        public virtual string ProductDesc
        {
            get { return Product.ProductName; }
        
        }

        public virtual float Quantity { get; set; }

        public virtual string QuantityDesc
        {
            get
            {
                return Quantity.ToString() + " " + Product.ProductUnitDesc;
            }
        }
        

        public override string TypeDesc
        {
            get { return "Order Item"; }
        }
    }
}
