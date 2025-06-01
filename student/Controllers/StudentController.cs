using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using student.Data;
using student.Data.Repository;
using student.DTO;
using student.Models;
using System.Net;

namespace student.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepostitory _studentRepostitory;
        private  APIResponse _apiresponse;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IMapper mapper, IStudentRepostitory studentRepostitory, APIResponse aPIResponse, ILogger<StudentController> logger)
        {
            _logger = logger;
            _mapper = mapper;
            _studentRepostitory = studentRepostitory;
            _apiresponse = aPIResponse;
        }


        [Route("All" , Name = "GetAllStudent")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDTO>>> GetStudent()
        {
            _logger.LogTrace("Hello tui nef");
            var students = await _studentRepostitory.GetAllAsync();
            _apiresponse.data = _mapper.Map<List<Students>>(students);
            _apiresponse.Status = true;
            _apiresponse.StatusCode = HttpStatusCode.OK;
            return Ok(_apiresponse);
        }


        [Route("{id:int}", Name = "GetAllStudentById")]
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetStudentById(int id)
        {
            var s =await _studentRepostitory.GetByIdAsync(x => x.Id == id);
            _apiresponse.data = _mapper.Map<Students>(s);
            _apiresponse.Status = true;
            _apiresponse.StatusCode = HttpStatusCode.OK;
            return Ok(_apiresponse);
        }

        [HttpPost]

        public async Task<ActionResult<StudentDTO>> addStudent([FromBody]StudentDTO student)
        {

            var s = _mapper.Map<Students>(student);
            _apiresponse.data = await _studentRepostitory.CreateAsync(s);
            _apiresponse.Status = true;
            _apiresponse.StatusCode = HttpStatusCode.OK;
            return Ok(_apiresponse);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateStudentAsync([FromBody] StudentDTO studentDto)
        {
           
            var updatedStudent = _mapper.Map<Students>(studentDto);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _studentRepostitory.DeleteAsync(x => x.Id == id);

            return NoContent();
        }
    }
}
