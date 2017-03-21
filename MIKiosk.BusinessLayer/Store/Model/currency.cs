using System.ComponentModel;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.UIPart;

namespace MIKiosk.BusinessLayer.Store.Model
{
    [ObjectView(typeof(CurrencyListUI), typeof(CurrencyFetchUI))]
    public class Currency:Entity
    {
        public virtual int Order { get; set; }
           [DisplayName("Name")]
        public virtual string Name { get; set; }
           [DisplayName("Symbol")]
        public virtual string Symbol { get; set; }
           [DisplayName("Rate to Base")]
        public virtual float RateToBaseCurrency { get; set; }

        public override string TypeDesc
        {
            get { return "currency"; }
        }

        
    }
    
}