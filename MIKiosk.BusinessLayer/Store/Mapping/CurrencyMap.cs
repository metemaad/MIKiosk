using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap()
        {


            Id(x => x.Id);
            Map(x => x.RateToBaseCurrency);
            Map(x => x.Name);
            Map(x => x.Symbol);
            



        }
    }
    
}
