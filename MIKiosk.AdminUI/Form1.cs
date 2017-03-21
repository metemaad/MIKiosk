using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Controls;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.AdminUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CategoryToolStripMenuItemClick(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, object> { };
            EntityFormService.New<Category>(false, false, dic);

        }

        private void ProductToolStripMenuItemClick(object sender, EventArgs e)
        {

            var dic = new Dictionary<string, object> { { "ProductName", "ProductName" } };
            EntityFormService.New<Product>(false, false, dic);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataAccess.UpdateDatabase();
        }

        private void unitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, object> { { "ProductName", "ProductName" } };
            EntityFormService.New<ProductUnit>(false, false, dic);
        }

        private void currecyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, object> { { "ProductName", "ProductName" } };
            EntityFormService.New<Currency>(false, false, dic);

        }
    }
}
