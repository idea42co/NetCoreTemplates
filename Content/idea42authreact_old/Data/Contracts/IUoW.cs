using System.Threading.Tasks;
using WebApplicationBasic.Models.Entities;

namespace WebApplicationBasic.Data.Contracts{
    public interface IUoW{
        object GetDBContext();
        void Commit();
        Task CommitAsync();
        void Dispose();
    }
}