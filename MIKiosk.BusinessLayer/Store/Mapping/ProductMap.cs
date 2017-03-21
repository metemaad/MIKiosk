using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            

            Id(x => x.Id);
            Map(x => x.ProductName);
            Map(x => x.ProductId);
            Map(x => x.ProductDescription).Length(2147483647).CustomSqlType("NVarChar(MAX)").Not.LazyLoad();
            Map(x => x.StockHighLevel);
            Map(x => x.StockLowLevel);
            Map(x => x.FixedPrice);
            References(x => x.FixedPricecurrency);
            References(x => x.SubCategory);
            References(x => x.ProductUnit);
            Map(x => x.ProductImageByte).Length(2147483647).CustomSqlType("varbinary(MAX)").Not.LazyLoad();
            HasMany(x => x.ProductSpecifications).Not.LazyLoad().Cascade.All();
            HasMany(x => x.PriceTables).Not.LazyLoad().Cascade.All();
            

        }
    }
    
}
