using MIKiosk.BusinessLayer.Infrastructure;

namespace MIKiosk.BusinessLayer.Login.Model
{
    public class User : Entity<User>
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public static User Currentuser;


    }
}
