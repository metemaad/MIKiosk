using System.ComponentModel;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.UIPart;

namespace MIKiosk.BusinessLayer.Store.Model
{
    [ObjectView(typeof(ProductUnitListUI), typeof(ProductUntiFetchUI))]
    public class ProductUnit:Entity
    {
        [DisplayName("Product Unit Name")]
        public virtual string UnitName { get; set; }

        public override string TypeDesc
        {
            get { return "Product Unit"; }
        }
    }
}