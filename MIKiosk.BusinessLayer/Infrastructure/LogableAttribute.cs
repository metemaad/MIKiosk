using System;

namespace MIKiosk.BusinessLayer.Infrastructure
{
    public class LogableAttribute : Attribute
    {
        public LogableAttribute()
        {
            LogableMode = false;
        }
        public LogableAttribute(bool logable)
        {
            LogableMode = logable;
        }
        public bool LogableMode { get; set; }
    }
    
}
