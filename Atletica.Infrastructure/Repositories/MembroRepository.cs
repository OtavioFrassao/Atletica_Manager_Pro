using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;
using Atletica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atletica.Infrastructure.Repositories
{
    public class MembroRepository : IMembroRepository
    {
        private readonly AtleticaDbContext _context;

        public MembroRepository(AtleticaDbContext context)
        {
            _context = context;
        }

        public async Task<Membro> GetByIdAsync(int id)
        {
            return await _context.Membros
                .Include(m => m.Cargo)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Membro>> GetAllAsync()
        {
            return await _context.Membros
                .Include(m => m.Cargo)
                .OrderBy(m => m.Nome)
                .ToListAsync();
        }

        public async Task<IEnumerable<Membro>> GetByCargoIdAsync(int cargoId)
        {
            return await _context.Membros
                .Include(m => m.Cargo)
                .Where(m => m.CargoId == cargoId)
                .OrderBy(m => m.Nome)
                .ToListAsync();
        }

        public async Task<Membro> AddAsync(Membro membro)
        {
            await _context.Membros.AddAsync(membro);
            await _context.SaveChangesAsync();
            return membro;
        }

        public async Task UpdateAsync(Membro membro)
        {
            _context.Membros.Update(membro);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var membro = await GetByIdAsync(id);
            if (membro != null)
            {
                _context.Membros.Remove(membro);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Membros.AnyAsync(m => m.Id == id);
        }
    }
}
