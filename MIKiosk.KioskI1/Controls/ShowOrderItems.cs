using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.KioskI1.Controls
{
    public partial class ShowOrderItems : UserControl
    {
        public event OrderItemRemoveHandler orderItemRemove;
        public EventArgs e = null;
        public delegate void OrderItemRemoveHandler(OrderItem orderitem, EventArgs e);


        private OrderItem _order;
        public OrderItem OrderItem
        {
            get
            {
                return _order;
            }
            set
            {
                

                _order = value;
                bindingSource2.DataSource = _order;
            }
        }
        public ShowOrderItems()
        {
            InitializeComponent();
        }

        private void RadButton1Click(object sender, EventArgs e)
        {
            if (orderItemRemove != null)
            {
                orderItemRemove(_order, e);
            }


        }
    }
}
