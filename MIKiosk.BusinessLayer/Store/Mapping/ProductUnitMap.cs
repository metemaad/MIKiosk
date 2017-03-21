using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class ProductUnitMap : ClassMap<ProductUnit>
    {
        public ProductUnitMap()
        {


            Id(x => x.Id);
            Map(x => x.UnitName);
            



        }
    }
   
}
