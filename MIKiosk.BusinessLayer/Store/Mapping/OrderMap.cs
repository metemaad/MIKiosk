using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {


            Id(x => x.Id);
            References(x => x.Client).Not.Nullable();
            References(x => x.DiscountCode).Nullable();
            Map(x => x.OrderNo);
            Map(x => x.OrderDate);

            HasMany(x => x.OrderItems).LazyLoad().Cascade.All();






        }
    }
}