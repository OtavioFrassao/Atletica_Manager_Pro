using System.Collections.Generic;
using System.Threading.Tasks;
using Atletica.Domain.Entities;

namespace Atletica.Domain.Repositories
{
    public interface IEventoRepository
    {
        Task<IEnumerable<Evento>> GetAllAsync();
        Task<Evento?> GetByIdAsync(int id);
        Task AddAsync(Evento evento);
        Task UpdateAsync(Evento evento);
        Task DeleteAsync(int id);
    }
}
