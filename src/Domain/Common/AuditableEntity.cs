namespace Domain.Common
{
    public class AuditableEntity : Entity<int>
    {
        public int? CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
