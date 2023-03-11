using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace TicketOnline.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required]
        public string Image { get; set; }
        //one to many
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
