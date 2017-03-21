using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class DiscountCodeMap: ClassMap<DiscountCode>
    {
        public DiscountCodeMap()
        {


            Id(x => x.Id);
            References(x => x.Client).Nullable();
            Map(x => x.discountCode);
            Map(x => x.IsUsed);




        }
    }
}