using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    public class PhoneNumber:Entity
    {
        public override string TypeDesc
        {
            get { return "PhoneNumber"; }
        }
    }
}