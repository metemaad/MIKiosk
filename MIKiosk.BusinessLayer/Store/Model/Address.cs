using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    public class Address:Entity
    {
        public override string TypeDesc
        {
            get { return "Address"; }
        }
    }
}