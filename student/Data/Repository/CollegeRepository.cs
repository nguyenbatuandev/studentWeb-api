
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace student.Data.Repository
{
    public class CollegeRepository<T> : IColeggeRepository<T> where T : class
    {
        private readonly ClollegeDBContext _dbContext;
        private DbSet<T> _dbSet;

        public CollegeRepository(ClollegeDBContext clollegeDB) 
        {
            _dbContext = clollegeDB;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<T> CreateAsync(T dbRecord)
        {
             await _dbSet.AddAsync(dbRecord);
             await _dbContext.SaveChangesAsync();
            return dbRecord;
        }

        public async Task<T> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var student = await _dbSet.FirstOrDefaultAsync(filter);
          
            _dbSet.Remove(student);
            await _dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }



        public async Task<T> UpdateAsync(Expression<Func<T, bool>> filter, T updatedRecord)
        {
            var existingRecord = await _dbSet.FirstOrDefaultAsync(filter);

            _dbSet.Entry(existingRecord).CurrentValues.SetValues(updatedRecord);


            await _dbContext.SaveChangesAsync();
            return existingRecord;
        }

    }
}
