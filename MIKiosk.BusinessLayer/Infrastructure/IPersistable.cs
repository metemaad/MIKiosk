using System.Collections.Generic;

namespace MIKiosk.BusinessLayer.Infrastructure
{
    public interface IPersistable
    {
        bool Persist();
        bool Delete();
        IList<string> Validate();
    }
}