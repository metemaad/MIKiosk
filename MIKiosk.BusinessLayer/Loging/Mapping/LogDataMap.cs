using FluentNHibernate.Mapping;
using MIKiosk.BusinessLayer.Loging.Model;

namespace MIKiosk.BusinessLayer.Loging.Mapping
{    public class LogDataMap : ClassMap<LogData>
    {
    public LogDataMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Txt).Length(4000);
            Map(x => x.ObjectType);
            Map(x => x.LogDate);
            Map(x => x.Guid);

            References(x => x.User).Cascade.SaveUpdate();
        }
    }
}
