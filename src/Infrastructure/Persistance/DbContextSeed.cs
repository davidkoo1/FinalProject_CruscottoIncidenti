using Domain.Entities;

namespace Infrastructure.Persistance
{
    public static class DbContextSeed
    {
        #region Roles
        public static readonly Role AdminRole = new Role { Id = 1, Name = "Admin", Description = "Administrator" };
        public static readonly Role OperatorRole = new Role { Id = 2, Name = "Operator", Description = "Operator simple" };
        public static readonly Role UserRole = new Role { Id = 3, Name = "User", Description = "User simple" };
        #endregion

        #region User
        public static readonly User Admin = new User
        {
            Id = 1,
            UserName = "Crme145",
            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
            FullName = "David Alexandr",
            Email = "alexander.david@gmail.com",
            IsEnabled = true,
        };
        #endregion

        #region UserRole
        public static readonly UserRole RoleAdmin = new UserRole { UserId = Admin.Id, RoleId = AdminRole.Id };
        #endregion
    }
}
