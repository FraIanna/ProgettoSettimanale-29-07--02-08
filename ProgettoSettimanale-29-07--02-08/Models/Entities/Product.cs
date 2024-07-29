using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoSettimanale_29_07__02_08.Models.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Range(0, 100)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(128)]
        public required byte[] Photo { get; set; }

        [Range(0,60)]
        public int DeliveryTime { get; set; }

        public List<Ingredient> Ingredients { get; set; } = [];

        public List<OrderItem> OrderedItems { get; set; } = [];
    }
}