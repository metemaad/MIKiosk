using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class SubCategoryMap : ClassMap<SubCategory>
    {
        public SubCategoryMap()
        {


            Id(x => x.Id);
            Map(x => x.SubCategoryId);
            Map(x => x.SubCategoryName);
            References(x => x.Category);
            Map(x => x.SubCategoryByteImage).Length(2147483647).CustomSqlType("varbinary(MAX)");


        }
    }
   
}
