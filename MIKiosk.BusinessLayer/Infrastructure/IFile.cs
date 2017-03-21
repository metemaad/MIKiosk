using System;
using System.Windows.Media.Imaging;

namespace MIKiosk.BusinessLayer.InfraStructure
{
    interface IFile
    {
        BitmapImage LoadImage(String guidstr);
        Guid SaveImage(string fileAddress, BitmapImage data);
    }
}
