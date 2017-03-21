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
    public partial class CurrencyListUI : UiPart
    {
        public CurrencyListUI()
        {
            InitializeComponent();
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            EntityFormService.New<Currency>(true, true);
            UpdateData("");
        }

        private void UpdateData(string empty)
        {
            var l = DataAccess.NhSession.Query<Currency>().ToList();

            var k = l.Where(x => x.Name.Contains(empty)).ToList();

            baseGridView1.InitilizeGrid(typeof(Currency));
            baseGridView1.DataSource = k;
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            var tmp = (Currency)baseGridView1.SelectedRows[0].DataBoundItem;
            EntityFormService.Edit(tmp);
            UpdateData("");
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            DialogResult o = MessageBox.Show("Attention", "Do you Like to Remove This " + this.Text + "?", MessageBoxButtons.YesNo);
            if (o == DialogResult.Yes)
            {

                var tmp = (Currency)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Delete(tmp);
                UpdateData("");
            }
        }

        private void CurrencyListUI_Load(object sender, EventArgs e)
        {
            UpdateData("");
        }
    }
}
