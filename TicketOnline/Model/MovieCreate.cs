using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TicketOnline.Data;

namespace TicketOnline.Model
{
    public class MovieCreate
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string GenreId { get; set; }
        public string Language { get; set; }
        public string ReleaseDate { get; set; }
        public string RunTime { get; set; }
        public bool Adult { get; set; }
        public bool Status { get; set; }
        public int Budget { get; set; }
        public int Revenue { get; set; }
        public decimal Vote_average { get; set; }
        public int Vote_count { get; set; }
        public bool Video { get; set; }
        public decimal Popularity { get; set; }
        public string Tagline { get; set; }
        public string HomePage { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public string BackdropPath { get; set; }
        //one to many 
    }
}
