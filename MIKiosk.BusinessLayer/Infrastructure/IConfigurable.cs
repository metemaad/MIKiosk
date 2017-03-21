using System.Collections.Generic;

namespace MIKiosk.BusinessLayer.Infrastructure
{
    public interface IConfigurable
    {
        void Configure(Entity container);
        void Configure(Dictionary<string,object> dictionary  );
    }
}