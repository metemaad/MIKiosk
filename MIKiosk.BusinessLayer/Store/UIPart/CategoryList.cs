using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Controls;
using MIKiosk.BusinessLayer.Controls.WinControls;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.Model;
using NHibernate.Linq;

namespace MIKiosk.BusinessLayer.Store.UIPart
{
    public partial class CategoryList : UiPart
    {
        public CategoryList()
        {
            InitializeComponent();
            UpdateData(textBox1.Text);
        }

        private void RadButton2Click(object sender, EventArgs e)
        {
            EntityFormService.New<Category>(true, true);
            UpdateData("");
        }

        private void UpdateData(string s)
        {
            var l = DataAccess.NhSession.Query<Category>().ToList();

            var k = l.Where(x => x.CategoryName.Contains(s) ).ToList();

            baseGridView1.InitilizeGrid(typeof(Category));
            baseGridView1.DataSource = k;
        }

        private void RadButton3Click(object sender, EventArgs e)
        {
            var tmp = (Category)baseGridView1.SelectedRows[0].DataBoundItem;
            EntityFormService.Edit(tmp);
            UpdateData("");
        }

        private void RadButton4Click(object sender, EventArgs e)
        {
            DialogResult o = MessageBox.Show("Attention", "Do you Like to Remove This " + this.Text + "?", MessageBoxButtons.YesNo);
            if (o == DialogResult.Yes)
            {

                var tmp = (Category)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Delete(tmp);
                UpdateData("");
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            EntityFormService.ClearAndAddToExtendedParameters((Category)baseGridView1.SelectedRows[0].DataBoundItem);
            EntityFormService.New<SubCategory>(true, false);


            UpdateData("");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateData(textBox1.Text);
        }
    }
}
