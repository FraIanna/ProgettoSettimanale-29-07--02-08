using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProgettoSettimanale_29_07__02_08.DataLayer.Entities
{
    [Index(nameof(Name), IsUnique = true)]
    public class Ingredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        public List<Product> Products { get; set; } = [];
    }
}
