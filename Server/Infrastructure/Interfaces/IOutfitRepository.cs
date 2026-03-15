using Server.Domain.Entities;

namespace Server.Infrastructure.Interfaces
{
    public interface IOutfitRepository
    {
        IQueryable<Outfit> GetAllAsync();
        Task<Outfit?> GetByIdAsync(Guid id);
        Task AddAsync(Outfit outfit);
        Task UpdateAsync(Outfit outfit);
        Task DeleteAsync(Guid id);
    }
}
