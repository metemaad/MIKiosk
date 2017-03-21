using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Controls.WinControls;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.UIPart
{
    public partial class ProdPriceTableRuleUI : UiPart
    {
        private void LoadCurrency()
        {


            comboBox1.DataSource = Currency.LoadAll<Currency>().OrderBy(x => x.Order).ToList();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
            if (((PriceTable)ObjectInstance).Currency== null)
                ((PriceTable)ObjectInstance).Currency= (Currency)comboBox1.SelectedItem;
            else
            {
                comboBox1.SelectedItem = ((PriceTable)ObjectInstance).Currency;
            }



        }
        public ProdPriceTableRuleUI()
        {
            InitializeComponent();
        }

        private void ProdPriceTableRuleUI_Load(object sender, EventArgs e)
        {
            LoadCurrency();

        }
    }
}
