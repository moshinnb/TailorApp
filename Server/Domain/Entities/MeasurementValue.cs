using Server.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entities
{
    public class MeasurementValue:AuditableEntity
    {
       
        public Guid Id { get; set; }

        public Guid OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; } = null!;

        public Guid OutfitMeasurementFieldId { get; set; }
        public OutfitMeasurementField Field { get; set; } = null!;

        // Universal value storage
        public string Value { get; set; } = string.Empty;
    }
}