using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    public class DiscountCode:Entity
    {
        public virtual string discountCode { get; set; }

        public virtual bool IsUsed { get; set; }
        public virtual Client Client { get; set; }

        public override string TypeDesc
        {
            get { return "DiscountCode"; }
        }
    }
}