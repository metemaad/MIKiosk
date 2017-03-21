using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MIKiosk.BusinessLayer.Controls.WinControls;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.UIPart
{
    public partial class SubCatFetch : UiPart
    {
        public SubCatFetch()
        {
            InitializeComponent();
        }
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {


                ((SubCategory)ObjectInstance).SubCategoryByteImage = ImageToByteArray(Image.FromFile(openFileDialog1.FileName));
                pictureBox1.Image = ByteArrayToImage(((SubCategory)ObjectInstance).SubCategoryByteImage);
            }
        }
        private void LoadImage()
        {

            if (ObjectInstance != null)
            {
                var categoryByteImage = ((SubCategory)ObjectInstance).SubCategoryByteImage;
                if (categoryByteImage != null)
                    pictureBox1.Image = ByteArrayToImage(categoryByteImage);
            }
        }

        private void SubCatFetch_Load(object sender, EventArgs e)
        {
LoadImage();
        }
    }
}
