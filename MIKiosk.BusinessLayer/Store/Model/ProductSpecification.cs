using System.Collections.Generic;
using System.ComponentModel;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.UIPart;

namespace MIKiosk.BusinessLayer.Store.Model
{
    [ObjectView(typeof(ProdSpecFetchUI), typeof(ProdSpecFetchUI))]
    public class ProductSpecification:Entity,IConfigurable
    {
         [DisplayName("Title")]
        public virtual string SpecificationName { get; set; }
        [DisplayName("Value")]
        public virtual string SpecificationValue { get; set; }
        [DisplayName("Note")]
        public virtual string SpecificationNote { get; set; }

        
        public virtual string ProductName
        {
            get { return Product.ProductName; }
        }

        public virtual Product Product { get; set; }
        public override string TypeDesc
        {
            get { return "ProductSpecification"; }
        }

        public virtual void Configure(Entity container)
        {
            
        }

        public virtual void Configure(Dictionary<string, object> dictionary)
        {
            foreach (var o in dictionary)
            {
                if (o.Key=="Product")
                {
                    Product = (Product)o.Value;
                }
            }

        }
    }
}