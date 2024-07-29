using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoSettimanale_29_07__02_08.Models.Entities
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime PlacedAt { get; set; }

        public required User User { get; set; }

        public bool Done { get; set; }

        [Required]
        [StringLength(80)]
        public required string Address { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }

        public List<OrderItem> Items { get; set; } = [];
    }
}
