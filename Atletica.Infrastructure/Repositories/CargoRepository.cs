using Atletica.Domain.Entities;
using Atletica.Domain.Repositories;
using Atletica.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atletica.Infrastructure.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly AtleticaDbContext _context;

        public CargoRepository(AtleticaDbContext context)
        {
            _context = context;
        }

        public async Task<Cargo> GetByIdAsync(int id)
        {
            return await _context.Cargos
                .Include(c => c.Membros)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return await _context.Cargos
                .Include(c => c.Membros)
                .OrderBy(c => c.Nome)
                .ToListAsync();
        }

        public async Task<Cargo> AddAsync(Cargo cargo)
        {
            await _context.Cargos.AddAsync(cargo);
            await _context.SaveChangesAsync();
            return cargo;
        }

        public async Task UpdateAsync(Cargo cargo)
        {
            _context.Cargos.Update(cargo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cargo = await GetByIdAsync(id);
            if (cargo != null)
            {
                _context.Cargos.Remove(cargo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Cargos.AnyAsync(c => c.Id == id);
        }
    }
}
