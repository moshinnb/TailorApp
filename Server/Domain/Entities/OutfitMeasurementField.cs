using Server.Domain.Common;
using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class OutfitMeasurementField : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid OutfitId { get; set; }
        public Outfit Outfit { get; set; } = null!;

        public string FieldName { get; set; } = string.Empty; // Chest, Waist
        public MeasurementFieldType FieldType { get; set; }  // 🔥 NEW
        public MeasurementUnit Unit { get; set; } = MeasurementUnit.Inch; // inch / cm

        public int DisplayOrder { get; set; }
    }
}