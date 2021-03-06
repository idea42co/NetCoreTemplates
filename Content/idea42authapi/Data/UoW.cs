using System.Threading.Tasks;
using WebApplicationBasic.Data.Contracts;
using WebApplicationBasic.Data.DbContexts;
using WebApplicationBasic.Models.Entities;

namespace WebApplicationBasic.Data
{
    public class UoW : IUoW
    {
        private ApplicationDbContext _dbContext;

        public UoW(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public object GetDBContext()
        {
            return _dbContext;
        }
    }
}