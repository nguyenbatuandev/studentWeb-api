using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student.Data;
using student.Data.Repository;
using student.DTO;
using student.Models;
using System.Net;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RoleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IColeggeRepository<Role> _roleResponsitory;
        private APIResponse _APIresponse;
        public RoleController(IMapper mapper , IColeggeRepository<Role> roleResponsitory, APIResponse APIresponse)
        {
            _mapper = mapper;
            _roleResponsitory = roleResponsitory;
            _APIresponse = APIresponse;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<APIResponse>> CreateRoleAsync(RoleDTO dto) 
        {
            Role role = _mapper.Map<Role>(dto);
            role.IsDelete = false;
            role.CreateedDate = DateTime.Now;
            role.LastModifiedDate = DateTime.Now;


            var rs = await _roleResponsitory.CreateAsync(role);
            dto.Id = rs.Id;
            _APIresponse.data = dto;
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;

            return Ok(_APIresponse);
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> getRole()
        {
            var r = await _roleResponsitory.GetAllAsync();
            _APIresponse.data = _mapper.Map<List<RoleDTO>>(r);
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;
            return Ok(_APIresponse);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<APIResponse>> getRoleById(int id)
        {
            var r = await _roleResponsitory.GetByIdAsync(x => x.Id == id);
            _APIresponse.data = _mapper.Map<RoleDTO>(r);
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;
            return Ok(_APIresponse);
        }

        [HttpPut]
        public async Task<ActionResult<APIResponse>> UpdateRole([FromBody] RoleDTO roleDTO)
        {

            // Chuyển đổi RoleDTO sang Role
            Role roleToUpdate = _mapper.Map<Role>(roleDTO);

            var updatedRole = await _roleResponsitory.UpdateAsync(r => r.Id == roleDTO.Id, roleToUpdate);
            // Chuyển đổi lại Role sang RoleDTO
            RoleDTO updatedRoleDTO = _mapper.Map<RoleDTO>(updatedRole);

            _APIresponse.data = roleDTO;
            _APIresponse.Status = true;
            _APIresponse.StatusCode = HttpStatusCode.OK;

            return Ok(_APIresponse);
        }

    }
}
