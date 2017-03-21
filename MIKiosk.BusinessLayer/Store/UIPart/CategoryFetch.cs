using System.Drawing;
using System.IO;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Controls;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.UIPart
{
    public partial class CategoryFetch
    {
        public byte[] ImageToByteArray(Image imageIn)
        {
            var ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            var ms = new MemoryStream(byteArrayIn);
            var returnImage = Image.FromStream(ms);
            return returnImage;
        }
        public CategoryFetch()
        {
            InitializeComponent();
        
        }

        private void LoadImage()
        {
             
            if (ObjectInstance!=null)
            {
                var categoryByteImage = ((Category) ObjectInstance).CategoryByteImage;
                if (categoryByteImage != null)
                    pictureBox1.Image=ByteArrayToImage(categoryByteImage);
            }
        }

        private void Button1Click(object sender, System.EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {


                ((Category)ObjectInstance).CategoryByteImage = ImageToByteArray(Image.FromFile(openFileDialog1.FileName));
                pictureBox1.Image = ByteArrayToImage(((Category)ObjectInstance).CategoryByteImage);
            }
        }

        private void CategoryFetch_Load(object sender, System.EventArgs e)
        {
            LoadImage();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
                        
        }
    }
    
}
