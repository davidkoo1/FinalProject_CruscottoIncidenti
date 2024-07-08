using Domain.Common;

namespace Domain.Entities
{
    public class Role : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
