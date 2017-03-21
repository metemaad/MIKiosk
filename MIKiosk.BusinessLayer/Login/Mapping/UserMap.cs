using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Login.Model;

namespace MIKiosk.BusinessLayer.Login.Mapping
{
       public class UserMap : ClassMap<User>
    {
           public UserMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.UserName);
            Map(x => x.PasswordHash);
        }
    }
}
