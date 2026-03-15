using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Server.Application.DTOs;
using Server.Infrastructure.Interfaces;

namespace Server.Application.Services
{
    public class OutfitService
    {
        private readonly IOutfitRepository _repository;
        private readonly IMapper _mapper;

        public OutfitService(IOutfitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<OutfitDto>> GetAllAsync()
        {
            var outfits =  _repository.GetAllAsync();
             var data=await outfits.Include(o => o.MeasurementFields).ToListAsync();
            return _mapper.Map<List<OutfitDto>>(data);
        }
        



    }
}
