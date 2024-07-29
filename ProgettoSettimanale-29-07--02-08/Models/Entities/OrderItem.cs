using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgettoSettimanale_29_07__02_08.Models.Entities
{
    public class OrderItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required Product Product { get; set; }

        public required Order Order { get; set; }

        public int Quantity { get; set; }
    }
}