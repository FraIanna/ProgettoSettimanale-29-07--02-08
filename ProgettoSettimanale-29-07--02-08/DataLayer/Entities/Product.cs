using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoSettimanale_29_07__02_08.DataLayer.Entities
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display (Name = "Nome Prodotto")]
        public required string Name { get; set; }

        [Range(0, 100)]
        [Display (Name = "Prezzo")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Foto")]
        public required string PhotoUrl { get; set; }

        [Range(0, 60)]
        [Display(Name = "Tempo di consegna")]
        public int DeliveryTime { get; set; }

        public List<Ingredient> Ingredients { get; set; } = [];

        public List<OrderItem> OrderedItems { get; set; } = [];
    }
}