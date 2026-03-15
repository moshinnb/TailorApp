using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.DTOs
{
    public class OutfitMeasurementFieldDto
    {
        public Guid Id { get; set; }

        public Guid OutfitId { get; set; }

        public string FieldName { get; set; } = string.Empty; // Chest, Waist
        public MeasurementFieldType FieldType { get; set; }  // 🔥 NEW
        public MeasurementUnit Unit { get; set; } = MeasurementUnit.Inch; // inch / cm

        public int DisplayOrder { get; set; }
    }
}
