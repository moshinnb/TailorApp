using Server.Domain.Common;

namespace Server.Domain.Entities
{
    public class Outfit : AuditableEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<OutfitMeasurementField> MeasurementFields { get; set; }
            = new List<OutfitMeasurementField>();
        public Decimal BasePrice { get;  set; }
    }
}
