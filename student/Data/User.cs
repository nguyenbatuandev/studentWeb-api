namespace student.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public int UserTypeId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateedDate { get; set; }
        public DateTime LastModifiedDate { get; set;}
        public virtual UserType UserType { get; set; }
        public virtual ICollection<UserRoleMapping> UserRoleMapping { get; set;}


    }
}
