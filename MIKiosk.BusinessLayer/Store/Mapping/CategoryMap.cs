using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {


            Id(x => x.Id);
            Map(x => x.CategoryId);
            Map(x => x.CategoryName);
            Map(x => x.CategoryByteImage).Length(2147483647).CustomSqlType("varbinary(MAX)");



        }
    }
}
