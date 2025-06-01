using student.Data;

namespace student.DTO
{
    public class RolePrivilegeDTO
    {
        public int Id { get; set; }
        public string rolePrivilege { get; set; }
        public string Description { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
