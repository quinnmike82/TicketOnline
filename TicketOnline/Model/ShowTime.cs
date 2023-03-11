using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketOnline.Data
{
    public class ShowTime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie? Movie { get; set; }
        public int RoomNumberId { get; set; }
        [ForeignKey("RoomNumberId")]
        public virtual Room? Room { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }


    }
}
