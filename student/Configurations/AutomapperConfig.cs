using AutoMapper;
using student.Data;
using student.DTO;

namespace student.Configurations
{
    public class AutomapperConfig :Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Students,StudentDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RolePrivilege, RolePrivilegeDTO>().ReverseMap();
        }
    }
}
