using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.UIPart;
using NHibernate.Linq;


namespace MIKiosk.BusinessLayer.Store.Model
{
    [ObjectView(typeof(ProductsList), typeof(ProductFetch))]
    public class Product : Entity
    {
        [DisplayName("Product Name")]
        public virtual string ProductName { get; set; }

        [DisplayName("Product ID ")]
        public virtual string ProductId { get; set; }

        [DisplayName("Product Description ")]
        public virtual string ProductDescription { get; set; }

        
        public virtual ProductUnit ProductUnit { get; set; }

        [DisplayName("Product Unit")]
        public virtual string ProductUnitDesc { get { return ProductUnit != null ? ProductUnit.UnitName : string.Empty; }
        }

        

        public virtual byte[] ProductImageByte { get; set; }

        public virtual IList<PriceTable> PriceTables { get; set; }

        [DisplayName("Product Price ")]
        
        public virtual float Price
        {
            get
            {
                var count = PriceTables.Count;
                var pt = new PriceTable {Product = this};

                return count > 0 ? pt.Currentprice : FixedPrice;
            }
        }


        public virtual Currency Currency
        {
            get
            {
                var count = PriceTables.Count;
                var pt = new PriceTable { Product = this };


                return count > 0 ? pt.Currentpricecurrency: FixedPricecurrency;
            }
        }
         public virtual float InStockCount
        {
            get
            {
                var Price = DataAccess.NhSession.Query<PriceTable>();
              


                
                return 0;
            }
        }

        public virtual Image ProductImage
        {
            get
            {
                _ProdImage = ByteArrayToImage(ProductImageByte);
                return _ProdImage;
            }
            set
            {
                ProductImageByte = ImageToByteArray(value);
                _ProdImage = value;
            }
        }



        private Image _ProdImage;
        private byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            try
            {
                var ms = new MemoryStream(byteArrayIn);
                var returnImage = Image.FromStream(ms);
                return returnImage;
            }catch(Exception exception)
            {
                
                return null;
            }
        }

        public virtual int StockLowLevel { get; set; }
        public virtual int StockHighLevel { get; set; }

        public virtual float FixedPrice { get; set; }
        public virtual Currency FixedPricecurrency { get; set; }

        private IList<ProductSpecification> _productSpecifications;
        public virtual IList<ProductSpecification> ProductSpecifications
        {

            get { return _productSpecifications ?? (_productSpecifications = new List<ProductSpecification>()); }
            set { _productSpecifications = value; }
        }



        public virtual SubCategory SubCategory { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }


        [DisplayName("Product Category Description ")]
        public virtual string SubCategoryDesc
        {
            get { return SubCategory !=null  ?  SubCategory.SubCategoryName : string.Empty; }
        }
        
        
        public override string TypeDesc
        {
            get { return "Product"; }
        }

    }
}
