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
    public partial class ShowOrder : UserControl
    {
        public event ShowOrderCloseHandler OrderClose;
        public EventArgs e = null;
        public delegate void ShowOrderCloseHandler(Order order, EventArgs e);


        public ShowOrder(Order order )

        {
            _order = order;
            InitializeComponent();
        }
        private Order _order;
        public Order Order
        {
            get
            {
                return _order;
            }
            set
            {

                _order = value;
            }
        }
        private void loaditems()
        {
            radPanel8.Controls.Clear();
            foreach (var item in _order.OrderItems)
            {
                var uiItem = new ShowOrderItems {OrderItem = item, Dock = DockStyle.Top};
                uiItem.orderItemRemove += uiItem_orderItemRemove;
                radPanel8.Controls.Add(uiItem);

            }


        }

        void uiItem_orderItemRemove(OrderItem orderitem, EventArgs e)
        {
            var cr= _order.OrderItems.Where(x => x.Id == orderitem.Id).First();
            if (cr!=null)
            {
                _order.OrderItems.Remove(orderitem);
            }
            loaditems();
        }

        private void ShowOrder_Load(object sender, EventArgs e)
        {

            bindingSource1.DataSource = _order;

            bindingSource2.DataSource = _order.OrderItems;
            loaditems();

            //radGridView1.DataSource=inst
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            if (OrderClose!= null)
            {
                OrderClose(_order, e);
            }

        }
    }
}
