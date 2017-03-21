using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    [ObjectView(typeof( UIPart.SubCatList),typeof( UIPart.SubCatFetch))]
    public class SubCategory:Entity ,IConfigurable
    {
        [DisplayName("Sub Category ID")]
        public virtual string SubCategoryId { get; set; }

        [DisplayName("Sub Category Name")]
        public virtual string SubCategoryName { get; set; }

        public virtual Category Category { get; set; }

        public virtual byte[] SubCategoryByteImage { get; set; }

        public virtual Image SubCategoryImage
        {
            get
            {
                _SubCategoryImage = ByteArrayToImage(SubCategoryByteImage);
                return _SubCategoryImage;
            }
            set
            {
                SubCategoryByteImage = ImageToByteArray(value);
                _SubCategoryImage = value;
            }
        }



        private Image _SubCategoryImage;
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


        public override string TypeDesc
        {
            get { return "Sub Category"; }
        }

        public virtual void Configure(Entity container)
        {
            if (container is Category)
                Category= (Category)container;
        }

        public virtual void Configure(Dictionary<string, object> dictionary)
        {
         foreach(var d in dictionary)
         {
             if (d.Key== "Category")
             {
                 Category =(Category) d.Value;
             }
         }

        }
    }
}
