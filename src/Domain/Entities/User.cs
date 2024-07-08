using Domain.Common;

namespace Domain.Entities
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
