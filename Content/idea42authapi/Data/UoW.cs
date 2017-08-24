using System.Threading.Tasks;
using WebApplicationBasic.Data.Contracts;
using WebApplicationBasic.Data.DbContexts;
using WebApplicationBasic.Models.Entities;

namespace WebApplicationBasic.Data
{
    public class UoW : IUoW
    {
        private WowbaggersDbContext _dbContext;

        public UoW(WowbaggersDbContext dbContext)
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