using Atletica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atletica.Domain.Repositories
{
    public interface ITarefaLimpezaRepository
    {
        Task<TarefaLimpeza> GetByIdAsync(int id);
        Task<IEnumerable<TarefaLimpeza>> GetAllAsync();
        Task<IEnumerable<TarefaLimpeza>> GetByMembroIdAsync(int membroId);
        Task<IEnumerable<TarefaLimpeza>> GetByDataAsync(DateTime data);
        Task<IEnumerable<TarefaLimpeza>> GetPendentesAsync();
        Task<TarefaLimpeza> AddAsync(TarefaLimpeza tarefa);
        Task UpdateAsync(TarefaLimpeza tarefa);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> ExisteTarefaNaDataAsync(DateTime data, int? excludeId = null);
    }
}
