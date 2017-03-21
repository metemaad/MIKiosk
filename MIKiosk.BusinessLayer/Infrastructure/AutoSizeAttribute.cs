using System;
using System.Windows.Forms;

namespace MIKiosk.BusinessLayer.Infrastructure
{
    public class AutoSizeAttribute : Attribute
    {
        public AutoSizeAttribute()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        public AutoSizeAttribute(DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            AutoSizeMode = autoSizeMode;
        }
        public DataGridViewAutoSizeColumnMode AutoSizeMode { get; set; }
    }
}
