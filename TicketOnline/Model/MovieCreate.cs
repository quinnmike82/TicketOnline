using System.ComponentModel.DataAnnotations;

namespace TicketOnline.Model
{
    public class MovieCreate
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Genre { get; set; }
        public string ReleaseDate { get; set; }
        public string RunningTime { get; set; }
    }
}
