using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIKiosk.BusinessLayer;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.Model;
using MIKiosk.KioskI1.Controls;
using NHibernate.Linq;
using Telerik.WinControls.UI;

namespace MIKiosk.KioskI1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            order = new Order();
            if (order.OrderItems != null) order.OrderItems.Clear();
            loaing();
        }

        private void loaing()
        {
            var menu = new ShowMenu();
            
            
            radPanel1.Controls.Clear();
            menu.Dock = DockStyle.Fill;
            menu.ProductSelection += MenuProductSelection;
            radPanel1.Controls.Add(menu);
        }

        void MenuProductSelection(Product product, EventArgs e)
        {
            radPanel1.Controls.Clear();
            var prod = new ShowProduct();
            prod.ObjectInstance = product;
            prod.Dock = DockStyle.Fill;
            prod.ProductClose += ProdProductClose;
            prod.ProductAddtobasket += ProdProductAddtobasket;
            radPanel1.Controls.Add(prod);
        }

        private Order order;
        void ProdProductAddtobasket(OrderItem item, EventArgs e)
        {
            
            order.AddOrderItem(item);
            //update basket
            //radLabel1.Text = order.OrderItems.Count.ToString();

            radPanel1.Controls.Clear();
            var menu = new ShowOrder(order);
            radPanel1.Controls.Clear();
            menu.Dock = DockStyle.Fill;
            menu.OrderClose += MenuOrderClose;

            radPanel1.Controls.Add(menu);
        }

        void MenuOrderClose(Order o, EventArgs e)
        {
            loaing();
        }

        void ProdProductClose(OrderItem product, EventArgs e)
        {
            radPanel1.Controls.Clear();
            var menu = new ShowMenu();
            radPanel1.Controls.Clear();
            menu.Dock = DockStyle.Fill;
            menu.ProductSelection += MenuProductSelection;
            
            radPanel1.Controls.Add(menu);
            
        }

        
    }
}
