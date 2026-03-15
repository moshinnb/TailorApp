using Server.Domain.Entities;

namespace Server.Application.DTOs
{
    public class MeasurementValueDto
    {
        public Guid Id { get; set; }

        public Guid OrderItemId { get; set; }

        public Guid OutfitMeasurementFieldId { get; set; }
        //public OutfitMeasurementField Field { get; set; } = null!;
        // msy be feild name required

        // Universal value storage
        public string Value { get; set; } = string.Empty;
    }
}
