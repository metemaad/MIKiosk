using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    public class Supplier:Entity
    {
        public virtual string Name { get; set; }
        public virtual string Family { get; set; }
        public virtual string Email { get; set; }

        public override string TypeDesc
        {
            get { return "Supplier"; }
        }
    }
}