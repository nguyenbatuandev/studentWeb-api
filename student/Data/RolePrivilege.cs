namespace student.Data
{
    public class RolePrivilege
    {
        public int Id { get; set; }
        public string rolePrivilege { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public Role Role { get; set; }
        public virtual ICollection<UserRoleMapping> UserRole { get; set; }

    }
}
