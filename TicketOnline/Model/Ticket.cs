using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace TicketOnline.Data
{
    public class Ticket
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }
        public readonly SqlMoney Price = 70000;
        [Required]
        public string SeatId { get; set; }
        public virtual Seat? Seat { get; set; }
    }
}
