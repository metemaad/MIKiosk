using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MIKiosk.BusinessLayer.Infrastructure;
using MIKiosk.BusinessLayer.Store.UIPart;
using NHibernate.Linq;

namespace MIKiosk.BusinessLayer.Store.Model
{
    [ObjectView(typeof(ProdPriceTableRuleUI), typeof(ProdPriceTableRuleUI))]
    public class PriceTable:Entity,IConfigurable
    {
        public virtual Product Product { get; set; }
        [DisplayName("From")]

        public virtual DateTime SDateTime { get; set; }
        [DisplayName("To")]
        public virtual DateTime EDateTime { get; set; }
        [DisplayName("Price")]
        public virtual float Price { get; set; }
        [DisplayName("Currency")]
        public virtual string PriceCurrencyName
        {
            get { return Currency.Name; }
        }
        public virtual Currency Currency { get; set; }

        public virtual string ProductName { get { return Product.ProductName; } }




        public virtual float Currentprice
        {
            get
            {
                if (Product != null)
                {
                    var c =LoadAll<PriceTable>().Where(x => x.Product.Id == Product.Id).OrderBy(
                            x => x.SDateTime).ToList();

                    var b = c.Where(x => x.SDateTime <= DateTime.Now && x.EDateTime >= DateTime.Now).ToList();
                    return b.Count > 0 ? b.First().Price : 0;
                }
                else
                {
                    return 0;
                }
            }
        }
        public virtual Currency Currentpricecurrency
        {
            get
            {

                if (Product != null)
                {
                    var c =
                        PriceTable.LoadAll<PriceTable>().Where(x => x.Product.Id == this.Product.Id).OrderBy(
                            x => x.SDateTime).ToList();

                    var b = c.Where(x => x.SDateTime <= DateTime.Now && x.EDateTime >= DateTime.Now).ToList();
                    return b.Count > 0 ? b.First().Currency : null;
                }
                else
                {
                    return null;
                }
            }
        }

        public override string TypeDesc
        {
            get { return "PriceTable"; }
        }

        public virtual void Configure(Entity container)
        {
            
        }

        public virtual void Configure(Dictionary<string, object> dictionary)
        {
            foreach (var o in dictionary.Where(o => o.Key == "Product"))
            {
                Product = (Product) o.Value;
            }
        }
    }
}