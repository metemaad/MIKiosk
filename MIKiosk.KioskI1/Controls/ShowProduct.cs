using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.KioskI1.Controls
{
    public partial class ShowProduct : UserControl
    {

        public event ProductCloseHandler ProductClose;
        public EventArgs e = null;
        public delegate void ProductCloseHandler(OrderItem product, EventArgs e);

        public event ProductAddtoBasketHandler ProductAddtobasket;
        public delegate void ProductAddtoBasketHandler(OrderItem product, EventArgs e);


        public ShowProduct()
        {
            InitializeComponent();
            _orderItem = new OrderItem();
        }
        private object _objectInstance;
        public object ObjectInstance
        {
            get
            {
                return _objectInstance;
            }
            set
            {
                bindingSource1.DataSource = value;
                _objectInstance = value;
            }
        }
        public virtual IEnumerable<string> UiValidate()
        {
            return new List<string>();
        }
        public virtual void OnSave()
        {
            DataAccess.Flush();
        }
        public virtual void OnCurrentChanged(object oldInstance, object newInstance)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            

        }

        

        private OrderItem _orderItem;
        public OrderItem OrderItem
        {
            get
            {
                return _orderItem;
            }
            set
            {
                
                _orderItem = value;
            }
        }
        

        private void radButton2_Click(object sender, EventArgs e)
        {

        }

        private void radButton1_Click_2(object sender, EventArgs e)
        {//eventexit
            //OrderItem.Product = null;
            _orderItem.Quantity = 0;
            if (ProductClose != null)
            {
                ProductClose(_orderItem, e);
            }

        }

        private void radButton2_Click_1(object sender, EventArgs e)
        {
            _orderItem.Product = (Product)ObjectInstance;
            _orderItem.Quantity = 1;

            if (ProductAddtobasket != null)
            {
                ProductAddtobasket(_orderItem, e);
            }

        }

    }
}
