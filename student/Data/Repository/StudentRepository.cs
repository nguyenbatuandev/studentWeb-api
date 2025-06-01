
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using student.DTO;

namespace student.Data.Repository
{
    public class StudentRepository : CollegeRepository<Students>, IStudentRepostitory 
    {
        private readonly ClollegeDBContext _dbContext;
        public StudentRepository(ClollegeDBContext dBContext) : base(dBContext)
        {
            _dbContext = dBContext;
        }

        public Task<List<Students>> GetStudentsByFeeStatus(int feeStatus)
        {
            throw new NotImplementedException();
        }
    }
}
