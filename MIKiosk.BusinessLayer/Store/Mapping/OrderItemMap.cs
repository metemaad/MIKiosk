using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class OrderItemMap: ClassMap<OrderItem>
    {
        public OrderItemMap()
        {


            Id(x => x.Id);
            References(x => x.Product).Not.Nullable();
            Map(x => x.Quantity);
            




        }
    }
}