using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;
using Atletica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atletica.Infrastructure.Repositories
{
    public class TarefaLimpezaRepository : ITarefaLimpezaRepository
    {
        private readonly AtleticaDbContext _context;

        public TarefaLimpezaRepository(AtleticaDbContext context)
        {
            _context = context;
        }

        public async Task<TarefaLimpeza> GetByIdAsync(int id)
        {
            return await _context.TarefasLimpeza
                .Include(t => t.MembroResponsavel)
                    .ThenInclude(m => m.Cargo)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TarefaLimpeza>> GetAllAsync()
        {
            return await _context.TarefasLimpeza
                .Include(t => t.MembroResponsavel)
                    .ThenInclude(m => m.Cargo)
                .OrderByDescending(t => t.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<TarefaLimpeza>> GetByMembroIdAsync(int membroId)
        {
            return await _context.TarefasLimpeza
                .Include(t => t.MembroResponsavel)
                    .ThenInclude(m => m.Cargo)
                .Where(t => t.MembroResponsavelId == membroId)
                .OrderByDescending(t => t.Data)
                .ToListAsync();
        }

        public async Task<IEnumerable<TarefaLimpeza>> GetByDataAsync(DateTime data)
        {
            var dataInicio = data.Date;
            var dataFim = dataInicio.AddDays(1);
            
            return await _context.TarefasLimpeza
                .Include(t => t.MembroResponsavel)
                    .ThenInclude(m => m.Cargo)
                .Where(t => t.Data >= dataInicio && t.Data < dataFim)
                .ToListAsync();
        }

        public async Task<IEnumerable<TarefaLimpeza>> GetPendentesAsync()
        {
            return await _context.TarefasLimpeza
                .Include(t => t.MembroResponsavel)
                    .ThenInclude(m => m.Cargo)
                .Where(t => !t.Concluido)
                .OrderBy(t => t.Data)
                .ToListAsync();
        }

        public async Task<TarefaLimpeza> AddAsync(TarefaLimpeza tarefa)
        {
            await _context.TarefasLimpeza.AddAsync(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task UpdateAsync(TarefaLimpeza tarefa)
        {
            _context.TarefasLimpeza.Update(tarefa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tarefa = await GetByIdAsync(id);
            if (tarefa != null)
            {
                _context.TarefasLimpeza.Remove(tarefa);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.TarefasLimpeza.AnyAsync(t => t.Id == id);
        }

        public async Task<bool> ExisteTarefaNaDataAsync(DateTime data, int? excludeId = null)
        {
            var dataInicio = data.Date;
            var dataFim = dataInicio.AddDays(1);
            
            var query = _context.TarefasLimpeza
                .Where(t => t.Data >= dataInicio && t.Data < dataFim);
            
            if (excludeId.HasValue)
                query = query.Where(t => t.Id != excludeId.Value);
            
            return await query.AnyAsync();
        }
    }
}
