using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Store.Model;

namespace MIKiosk.BusinessLayer.Store.Mapping
{
    public class ClientMap : ClassMap<Client>
    {
        public ClientMap()
        {


            Id(x => x.Id);
            //Map(x => x.);
            //Map(x => x.CategoryName);




        }
    }
}