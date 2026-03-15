using Server.Domain.Entities;

namespace Server.Application.DTOs
{
    public class OutfitDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<OutfitMeasurementFieldDto> MeasurementFields { get; set; }
            = new List<OutfitMeasurementFieldDto>();
        public Decimal BasePrice { get; set; }
    }
}
