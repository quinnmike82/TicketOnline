using System.ComponentModel.DataAnnotations;

namespace TicketOnline.Data
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(10000)]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Cast { get; set; }
        [Required]
        public string Genre { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public TimeOnly RunningTime { get; set; }
        //one to many 
        public virtual ICollection<ShowTime>? Showtimes { get; set; }
    }
}
