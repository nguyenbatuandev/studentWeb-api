namespace student.Data
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public virtual ICollection<RolePrivilege> RolePrivilege { get; set;}
        public virtual ICollection<UserRoleMapping> UserRoleMapping { get; set; }

    }
}
