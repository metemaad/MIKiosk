using System.ComponentModel;
using System.Drawing;
using System.IO;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.UIPart;


namespace MIKiosk.BusinessLayer.Store.Model
{

    [ObjectView(typeof(CategoryList), typeof(CategoryFetch))]
    public class Category : Entity
    {

        [DisplayName("Category ID")]
        public virtual string CategoryId { get; set; }

        [DisplayName("Category Name")]
        public virtual string CategoryName { get; set; }


        public virtual byte[] CategoryByteImage { get; set; }

        public virtual Image CategoryImage
        {
            get
            {
                _CategoryImage = ByteArrayToImage(CategoryByteImage);
                return _CategoryImage;
            }
            set
            {
                CategoryByteImage = ImageToByteArray(value);
                _CategoryImage = value;
            }
        }



        private Image _CategoryImage;
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
            get { return "Category"; }
        }
    }
}
