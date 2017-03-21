using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Store.Model
{
    public class Client:Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual Address Address { get; set; }
        public virtual PhoneNumber PhoneNumber{ get; set; }

        public override string TypeDesc
        {
            get { return "Client"; }
        }
    }
}