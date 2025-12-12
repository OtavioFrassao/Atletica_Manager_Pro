using Atletica.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atletica.Domain.Repositories
{
    public interface ICargoRepository
    {
        Task<Cargo> GetByIdAsync(int id);
        Task<IEnumerable<Cargo>> GetAllAsync();
        Task<Cargo> AddAsync(Cargo cargo);
        Task UpdateAsync(Cargo cargo);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
