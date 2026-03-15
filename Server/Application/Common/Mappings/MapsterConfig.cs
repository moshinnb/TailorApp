using Mapster;
using Server.Application.DTOs;
using Server.Domain.Entities;

namespace Server.Application.Common.Mappings
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Outfit, OutfitDto>.NewConfig();
            TypeAdapterConfig<CreateOutfitDto, Outfit>.NewConfig();
            TypeAdapterConfig<UpdateOutfitDto, Outfit>.NewConfig();
        }
    }
}
