using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Controls;
using MIKiosk.BusinessLayer.Controls.WinControls;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.Model;
using NHibernate.Linq;

namespace MIKiosk.BusinessLayer.Store.UIPart
{
    public partial class ProductUnitListUI : UiPart
    {
        public ProductUnitListUI()
        {
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            EntityFormService.New<ProductUnit>(true, true);
            UpdateData("");
        }
        private void UpdateData(string s)
        {
            var l = DataAccess.NhSession.Query<ProductUnit>().ToList();

            var k = l.Where(x => x.UnitName.Contains(s)).ToList();

            baseGridView1.InitilizeGrid(typeof(ProductUnit));
            baseGridView1.DataSource = k;
        }
        private void radButton3_Click(object sender, EventArgs e)
        {
            var tmp = (ProductUnit)baseGridView1.SelectedRows[0].DataBoundItem;
            EntityFormService.Edit(tmp);
            UpdateData("");
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            DialogResult o = MessageBox.Show("Attention", "Do you Like to Remove This " + this.Text + "?", MessageBoxButtons.YesNo);
            if (o == DialogResult.Yes)
            {

                var tmp = (ProductUnit)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Delete(tmp);
                UpdateData("");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateData(textBox1.Text);
        }

        private void ProductUnitListUI_Load(object sender, EventArgs e)
        {
            UpdateData("");
        }
    }
}
