using System;
using System.Linq;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Infrastructure;
using NHibernate.Linq;
using MIKiosk.BusinessLayer.Controls;
using MIKiosk.BusinessLayer.Store.Model;
using MIKiosk.BusinessLayer.Controls.WinControls;

namespace MIKiosk.BusinessLayer.Store.UIPart
{
    public partial class ProductsList : UiPart
    {
        public ProductsList()
        {
            InitializeComponent();
            UpdateData(textBox1.Text);
        }

        private void RadButton2Click(object sender, EventArgs e)
        {
            EntityFormService.New<Product>(true, true);
            UpdateData("");
        }

        private void UpdateData(string s)
        {
            var l = DataAccess.NhSession.Query<Product>().ToList();
            
            var k = l.Where(x => x.ProductName.Contains(s) || x.ProductDescription.Contains(s)).ToList();

            baseGridView1.InitilizeGrid(typeof(Product));
            baseGridView1.DataSource = k;
        }

        private void RadButton4Click(object sender, EventArgs e)
        {
            DialogResult o = MessageBox.Show("Do you Like to Remove This Product?", "Attention", MessageBoxButtons.YesNo);
            if (o == DialogResult.Yes)
            {

                var tmp = (Product)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Delete(tmp);
                UpdateData("");
            }
        }

        private void RadButton3Click(object sender, EventArgs e)
        {
            var tmp = (Product)baseGridView1.SelectedRows[0].DataBoundItem;
            EntityFormService.Edit(tmp);
            UpdateData("");
        }
    }
}
