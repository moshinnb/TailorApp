using Server.Domain.Common;
using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class OrderItem : AuditableEntity
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid OutfitId { get; set; }
        public Outfit Outfit { get; set; } = null!;
        public OrderItemStatus  Status{ get; set; } = OrderItemStatus.Pending;
        public decimal Price { get; set; }
        public string Notes { get; set; } = string.Empty;

        public ICollection<MeasurementValue> Measurements { get; set; }
            = new List<MeasurementValue>();
    }
}