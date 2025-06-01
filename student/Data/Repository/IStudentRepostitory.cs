using student.DTO;

namespace student.Data.Repository
{
    public interface IStudentRepostitory : IColeggeRepository<Students>
    {
        Task<List<Students>> GetStudentsByFeeStatus(int feeStatus);
    }
}
