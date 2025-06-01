using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student.Data.Repository;
using student.Data;
using student.Models;
using student.DTO;
using System.Net;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePrivilegeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IColeggeRepository<RolePrivilege> _role;
        private APIResponse _APIresponse;
        public RolePrivilegeController(IMapper mapper, IColeggeRepository<RolePrivilege> role, APIResponse APIresponse)
        {
            _mapper = mapper;
            _role = role;
            _APIresponse = APIresponse;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<APIResponse>> CreateRoleAsync(RolePrivilegeDTO dto)
        {
            RolePrivilege role = _mapper.Map<RolePrivilege>(dto);
            role.IsDelete = false;
            role.CreateedDate = DateTime.Now;
            role.LastModifiedDate = DateTime.Now;


            var rs = await _role.CreateAsync(role);
            dto.Id = rs.Id;
            _APIresponse.data = dto;
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;

            return Ok(_APIresponse);
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> getRole()
        {
            var r = await _role.GetAllAsync();
            _APIresponse.data = _mapper.Map<List<RolePrivilege>>(r);
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;
            return Ok(_APIresponse);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<APIResponse>> getRoleById(int id)
        {
            var r = await _role.GetByIdAsync(x => x.Id == id);
            _APIresponse.data = _mapper.Map<RolePrivilege>(r);
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;
            return Ok(_APIresponse);
        }

        [HttpPut]
        public async Task<ActionResult<APIResponse>> UpdateRole([FromBody] RolePrivilegeDTO roleDTO)
        {

            // Chuyển đổi RoleDTO sang Role
            RolePrivilege roleToUpdate = _mapper.Map<RolePrivilege>(roleDTO);

            var updatedRole = await _role.UpdateAsync(r => r.Id == roleDTO.Id, roleToUpdate);
            // Chuyển đổi lại Role sang RoleDTO
            RolePrivilegeDTO updatedRoleDTO = _mapper.Map<RolePrivilegeDTO>(updatedRole);

            _APIresponse.data = roleDTO;
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;

            return Ok(_APIresponse);
        }
    }
}
