using System.ComponentModel.DataAnnotations;

namespace Server.Application.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string? Address { get; set; }

    }
}
