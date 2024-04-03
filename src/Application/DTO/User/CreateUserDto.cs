namespace Application.DTO.User
{
    public class CreateUserDto
    {
        public int CreatedBy { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsEnabled { get; set; }
        public List<int> RolesId { get; set; }
    }
}
