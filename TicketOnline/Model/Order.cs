using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlTypes;

namespace TicketOnline.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer? Customer { get; set; }
        [DataType(DataType.Currency)]
        public decimal Total { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        //one to many
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
