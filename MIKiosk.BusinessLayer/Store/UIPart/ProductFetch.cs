using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using MIKiosk.BusinessLayer.Controls;
using MIKiosk.BusinessLayer.InfraStructure;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.Model;
using MIKiosk.BusinessLayer.Controls.WinControls;
using NHibernate.Linq;

namespace MIKiosk.BusinessLayer.Store.UIPart
{
    public partial class ProductFetch : UiPart
    {
        public ProductFetch()
        {
            InitializeComponent();
        }


        private byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public override void OnCurrentChanged(object oldInstance, object newInstance)
        {
            //if (((Personel)ObjectInstance).SubYegan == null)
            //    ((Personel)this.ObjectInstance).Oldv = null;
            //else
            //{
            //    ((Personel)this.ObjectInstance).Oldv = ((Personel)this.ObjectInstance).Clone();
            //}
            LoadSubcat();
            LoadprodUnit();
            LoadCurrency();
            UpdateDataPricetable("");
            UpdateDataspec("");
            base.OnCurrentChanged(oldInstance, newInstance);

        }
        private void LoadSubcat()
        {


            comboBox2.DataSource = SubCategory.LoadAll<SubCategory>().OrderBy(x => x.SubCategoryName).ToList();
            comboBox2.DisplayMember = "SubCategoryName";
            comboBox2.ValueMember = "SubCategoryId";
            if (((Product)ObjectInstance).SubCategory== null)
                ((Product)ObjectInstance).SubCategory = (SubCategory)comboBox2.SelectedItem;
            else
            {
                comboBox2.SelectedItem = ((Product)ObjectInstance).SubCategory;
            }



        }

        private void LoadCurrency()
        {


            comboBox3.DataSource = Currency.LoadAll<Currency>().OrderBy(x => x.Order).ToList();
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "Name";
            if (((Product)ObjectInstance).FixedPricecurrency == null)
                ((Product)ObjectInstance).FixedPricecurrency = (Currency)comboBox3.SelectedItem;
            else
            {
                comboBox3.SelectedItem = ((Product)ObjectInstance).FixedPricecurrency;
            }



        }

        private void LoadprodUnit()
        {


            comboBox1.DataSource = ProductUnit.LoadAll<ProductUnit>().OrderBy(x => x.UnitName).ToList();
            comboBox1.DisplayMember = "UnitName";
            comboBox1.ValueMember = "Id";
            
            if (((Product)ObjectInstance).ProductUnit== null)

                ((Product)ObjectInstance).ProductUnit = (ProductUnit)comboBox1.SelectedItem;
                
            else
            {
                comboBox1.SelectedItem = ((Product)ObjectInstance).ProductUnit;
            }


            

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, object> { };
            EntityFormService.New<ProductUnit>(false, false, dic);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            var dic = new Dictionary<string, object> { };
            EntityFormService.New<Category>(false, false, dic);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                ((Product)ObjectInstance).ProductImageByte = ImageToByteArray(Image.FromFile(openFileDialog1.FileName));
                pictureBox1.Image = ByteArrayToImage(((Product)ObjectInstance).ProductImageByte);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Product
            var a=new Dictionary<string, object> {{"Product", ObjectInstance}};
            EntityFormService.New<ProductSpecification>(false, true,a);
            UpdateDataspec("");
        }

        private void UpdateDataspec(string s)
        {
            
            var k = ((Product) ObjectInstance).ProductSpecifications.ToList();

            baseGridView1.InitilizeGrid(typeof(ProductSpecification));
            baseGridView1.DataSource = k;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var tmp = (ProductSpecification)baseGridView1.SelectedRows[0].DataBoundItem;
            EntityFormService.Edit(tmp);
            UpdateDataspec("");
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult o = MessageBox.Show("Do you Like to Remove This Product?", "Attention", MessageBoxButtons.YesNo);
            if (o == DialogResult.Yes)
            {

                var tmp = (ProductSpecification)baseGridView1.SelectedRows[0].DataBoundItem;
                EntityFormService.Delete(tmp);
                UpdateDataspec("");
            }
        }

        private void ProductFetch_Load(object sender, EventArgs e)
        {
            UpdateDataspec("");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //Product
            var a = new Dictionary<string, object> { { "Product", ObjectInstance } };
           EntityFormService.New<PriceTable>(true, true, a);
            ((Product) ObjectInstance).Persist();

            UpdateDataPricetable("");
        }

        private void UpdateDataPricetable(string empty)
        {
            var k = ((Product)ObjectInstance).PriceTables;

            baseGridView2.InitilizeGrid(typeof(PriceTable));
            baseGridView2.DataSource = k;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            var tmp = (PriceTable)baseGridView2.SelectedRows[0].DataBoundItem;
            EntityFormService.Edit(tmp);
            UpdateDataPricetable("");
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            DialogResult o = MessageBox.Show("Do you Like to Remove This rule?", "Attention", MessageBoxButtons.YesNo);
            if (o == DialogResult.Yes)
            {

                var tmp = (PriceTable)baseGridView2.SelectedRows[0].DataBoundItem;

                ((Product) ObjectInstance).PriceTables.Remove(tmp);
                ((Product) ObjectInstance).Persist();
                UpdateDataPricetable("");
            }
        }
    }
}
