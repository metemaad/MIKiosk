using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class PriceTableMap : ClassMap<PriceTable>
    {
        public PriceTableMap()
        {


            Id(x => x.Id);
            References(x => x.Currency).Nullable();
            Map(x => x.SDateTime).Not.Nullable();
            Map(x => x.EDateTime).Not.Nullable();
            Map(x => x.Price).Not.Nullable();
            References(x => x.Product).Nullable();




        }
    }

}
