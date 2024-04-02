namespace Application.DTO.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }

        public List<string> UserRoles { get; set; } = new List<string>();
    }
}
