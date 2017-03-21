using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    public class Order : Entity
    {
        private IList<OrderItem> _orderItems;
        public virtual int OrderNo { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual Client Client { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }

        
        public virtual IList<OrderItem> OrderItems
        {
            get { return _orderItems ?? (_orderItems = new List<OrderItem>()); }
            set { _orderItems = value; }
        }

        public virtual void AddOrderItem(OrderItem orderItem)
        {
            var p = OrderItems.Where(x => x.Product == orderItem.Product).ToList();
            if (p.Count() > 0)
            {
                p.First().Quantity = p.First().Quantity + orderItem.Quantity;
            }
            else
            {
                OrderItems.Add(orderItem);


            }


        }

        public virtual List<OrderItem> OrderList()
        {
            var v = new List<OrderItem>();
            if (OrderItems != null)
            {
                v = ((List<OrderItem>)OrderItems);
            }
            return v;

        }
        public virtual DiscountCode DiscountCode { get; set; }

        public override string TypeDesc
        {
            get { return "Order"; }
        }
    }
}
