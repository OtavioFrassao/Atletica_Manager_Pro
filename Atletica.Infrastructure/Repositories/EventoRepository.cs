using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;
using Atletica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Atletica.Infrastructure.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly AtleticaDbContext _context;

        public EventoRepository(AtleticaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            return await _context.Eventos
                .Include(e => e.MembroResponsavel)
                .ToListAsync();
        }

        public async Task<Evento?> GetByIdAsync(int id)
        {
            return await _context.Eventos
                .Include(e => e.MembroResponsavel)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Evento evento)
        {
            await _context.Eventos.AddAsync(evento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evento evento)
        {
            _context.Eventos.Update(evento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
