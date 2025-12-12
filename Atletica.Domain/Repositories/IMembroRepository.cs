using Atletica.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atletica.Domain.Repositories
{
    public interface IMembroRepository
    {
        Task<Membro> GetByIdAsync(int id);
        Task<IEnumerable<Membro>> GetAllAsync();
        Task<IEnumerable<Membro>> GetByCargoIdAsync(int cargoId);
        Task<Membro> AddAsync(Membro membro);
        Task UpdateAsync(Membro membro);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
