using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{

    public class ProductSpecificationMap : ClassMap<ProductSpecification>
    {
        public ProductSpecificationMap()
        {


            Id(x => x.Id);
            Map(x => x.SpecificationName);
            Map(x => x.SpecificationValue);
            Map(x => x.SpecificationNote).Length(2147483647).CustomSqlType("nvarchar(MAX)").Not.LazyLoad(); 
            References(x => x.Product);




        }
    }

 
}
