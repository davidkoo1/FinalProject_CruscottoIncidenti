﻿namespace Domain.Entities
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }
    }
}
