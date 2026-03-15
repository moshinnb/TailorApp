using Server.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Server.Domain.Entities
{
    public class Customer: AuditableEntity
    {
        public Guid Id { get; set; } = new Guid();

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
