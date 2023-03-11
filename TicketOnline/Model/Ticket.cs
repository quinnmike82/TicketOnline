using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace TicketOnline.Data
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        public readonly SqlMoney Price = 70000;
        [Required]
        public int SeatId { get; set; }
        public virtual Seat? Seat { get; set; }
    }
}
