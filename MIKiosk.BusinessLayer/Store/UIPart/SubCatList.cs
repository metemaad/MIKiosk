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
    public partial class SubCatList : UiPart
    {
        public SubCatList()
        {
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            EntityFormService.New<SubCategory>(true, true);
            UpdateData("");
        }
        private void UpdateData(string s)
        {
            var l = DataAccess.NhSession.Query<SubCategory>().ToList();

            var k = l.Where(x =>   x.Category==((SubCategory)ObjectInstance).Category && x.SubCategoryName.Contains(s)).ToList();

            baseGridView1.InitilizeGrid(typeof(SubCategory));
            baseGridView1.DataSource = k;
            var categoryImage =((SubCategory) ObjectInstance).Category.CategoryImage;
            if (categoryImage != null)
                pictureBox1.Image = categoryImage;
            label2.Text = ((SubCategory)ObjectInstance).Category.CategoryName;
        }

        private void SubCatList_Load(object sender, EventArgs e)
        {
            UpdateData("");
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            var tmp = (SubCategory)baseGridView1.SelectedRows[0].DataBoundItem;
            EntityFormService.Edit(tmp);
            UpdateData("");
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            DialogResult o = MessageBox.Show("Attention", "Do you Like to Remove This " + this.Text + "?", MessageBoxButtons.YesNo);
            if (o == DialogResult.Yes)
            {

                var tmp = (SubCategory)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Delete(tmp);
                UpdateData("");
            }
        }
    }
}
