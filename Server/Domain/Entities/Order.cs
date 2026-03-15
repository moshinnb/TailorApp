using Server.Domain.Common;
using Server.Domain.Enums;

namespace Server.Domain.Entities
{
    public class Order : AuditableEntity
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public DateTime? TrialDate { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalAmount { get; set; }
        public decimal AdvanceAmount { get; set; }
        public decimal BalanceAmount { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    }
}