using Server.Domain.Entities;
using Server.Domain.Enums;

namespace Server.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;

        public Guid CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? TrialDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public ICollection<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
