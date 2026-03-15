using Microsoft.EntityFrameworkCore;
using Server.Domain.Entities;
using Server.Infrastructure.Data;
using Server.Infrastructure.Interfaces;

namespace Server.Infrastructure.Repositories
{
    public class OutfitRepository : IOutfitRepository
    {
        private readonly ApplicationDbContext _context;
        public OutfitRepository(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
                
        }
        public async Task AddAsync(Outfit outfit)
        {
            await _context.Outfits.AddAsync(outfit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Outfits.FindAsync(id);
            if (entity != null)
            {
                //_context.Outfits.Remove(entity);
                entity.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public IQueryable<Outfit> GetAllAsync()
        {
            return _context.Outfits;
        }

        public async Task<Outfit?> GetByIdAsync(Guid id)
        {
            return await _context.Outfits
               .Include(x => x.MeasurementFields)
               .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Outfit outfit)
        {
            _context.Outfits.Update(outfit);
            await _context.SaveChangesAsync();
        }
    }
}
