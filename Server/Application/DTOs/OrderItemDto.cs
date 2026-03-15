using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.DTOs
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
     
        public Guid OutfitId { get; set; }
        //public Outfit Outfit { get; set; } = null!;
        public OrderItemStatus Status { get; set; } = OrderItemStatus.Pending;
        public decimal Price { get; set; }
        public string Notes { get; set; } = string.Empty;

        public ICollection<MeasurementValueDto> Measurements { get; set; }
            = new List<MeasurementValueDto>();
    }
}
