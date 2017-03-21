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
using NHibernate.Linq;
using Telerik.WinControls.UI;

namespace MIKiosk.KioskI1.Controls
{
    public partial class ShowMenu : UserControl
    {
        public event ProductSelectionHandler ProductSelection;
        public EventArgs e = null;
        public delegate void ProductSelectionHandler(Product product, EventArgs e);
        

        public ShowMenu()
        {
            InitializeComponent();
        }

        private void LoadCategorys()
        {
            radCarousel1.Items.Clear();
            var catList = DataAccess.NhSession.Query<Category>();
            FillCatogoryMenu(catList);

        }


        private void FillCatogoryMenu(IEnumerable<Category> catList)
        {
            foreach (Category category in catList)
            {
                var item = new RadButtonElement();
                item.AccessibleDescription = category.CategoryName;
                item.AccessibleName = category.CategoryName;
                item.Name = category.CategoryName;
                //item.Font = new Font("Times", 20);
                //item.ForeColor = Color.Navy;
                //item.Text = category.CategoryName;
                //item.AutoSize = false;
                //item.Bounds = new Rectangle(0, 0, 400, 300);
                //item.FitToSizeMode = Telerik.WinControls.RadFitToSizeMode.FitToParentBounds;
                item.TextImageRelation = TextImageRelation.ImageAboveText;
                item.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                item.Click += CatClick;
                item.Image = category.CategoryImage;
                radCarousel1.Items.AddRange(item);
            }
        }

        private void CatClick(object sender, EventArgs e)
        {
            var sel = DataAccess.NhSession.Query<SubCategory>().ToList();
            var sels = sel.Where(x => x.Category.CategoryName == ((RadButtonElement)sender).Name).ToList();
            radCarousel1.Items.Clear();
            FillSubCatogoryMenu(sels);


        }

        private void FillSubCatogoryMenu(IEnumerable<SubCategory> subcatList)
        {
            foreach (var item in subcatList.Select(category => new RadButtonElement
            {
                AccessibleDescription = category.SubCategoryName,
                AccessibleName = category.SubCategoryName,
                Name = category.SubCategoryName,
                //Font = new Font("Times", 20),
                //ForeColor = Color.Navy,
                Text = category.SubCategoryName,
                Visibility = Telerik.WinControls.ElementVisibility.Visible,

                 TextImageRelation = TextImageRelation.ImageAboveText,
               
                Image = category.SubCategoryImage,

            }))
            {
                item.Click += SubCatClick;
                //item.Image = global::MIKiosk.KioskI1.Properties.Resources.basket;
                radCarousel1.Items.AddRange(item);
            }
        }


        //private void LoadSubCategory()
        //{
        //    radCarousel1.Items.Clear();
        //    var SubCList = DataAccess.NhSession.Query<SubCategory>();
        //    foreach (var SubCategory in SubCList)
        //    {
        //        var item = new RadButtonElement
        //        {
        //            AccessibleDescription = SubCategory.SubCategoryName,
        //            AccessibleName = SubCategory.SubCategoryName,
        //            Name = SubCategory.SubCategoryName,
        //            Font = new Font("Times", 20),
        //            ForeColor = Color.DarkRed,
        //            Text = SubCategory.SubCategoryName,

        //            Visibility = Telerik.WinControls.ElementVisibility.Visible
        //        };
        //        item.Click += new EventHandler(SubCat_Click);
        //        //item.Image = global::MIKiosk.KioskI1.Properties.Resources.basket;
        //        radCarousel1.Items.AddRange(item);
        //    }
        //}

        private void SubCatClick(object sender, EventArgs e)
        {
            radCarousel1.Items.Clear();
            var sel = DataAccess.NhSession.Query<Product>().ToList();
            var sels = sel.Where(x => x.SubCategory.SubCategoryName == ((RadButtonElement)sender).Name).ToList();
            FillProductMenu(sels);
        }

        private void LoadProducts()
        {
            radCarousel1.Items.Clear();
            var prodList = DataAccess.NhSession.Query<Product>();
            FillProductMenu(prodList);
        }


        private void FillProductMenu(IEnumerable<Product> prodList)
        {
            foreach (var product in prodList)
            {
                var item = new RadButtonElement
                {
                    AccessibleDescription = product.ProductName,
                    AccessibleName = product.ProductName,
                    Name = product.ProductName,
                    //Font = new Font("Times", 20),
                    //ForeColor = Color.DarkGreen,
                    Text = product.ProductName,
               

                    TextImageRelation = TextImageRelation.ImageAboveText,
               
                    Image = product.ProductImage,
                    Visibility = Telerik.WinControls.ElementVisibility.Visible
                };
                item.Click += ItemClick;
                //item.Image = global::MIKiosk.KioskI1.Properties.Resources.basket;
                radCarousel1.Items.AddRange(item);
            }
        }
        void ItemClick(object sender, EventArgs e)
        {
            var sel = DataAccess.NhSession.Query<Product>().ToList();
            var sels = sel.Where(x => x.ProductName == ((RadButtonElement)sender).Name).ToList();
            if (sels.Count > 0)
            {
                if (ProductSelection != null)
                {
                    ProductSelection(sels.First(), e);
                }
            }
            else
            {
              // Product not found
            }
        }

        private void ShowMenu_Load(object sender, EventArgs e)
        {
            LoadCategorys();
        }

        private void radButton3_Click(object sender, EventArgs e)
        {
            LoadCategorys();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
