using System;
namespace IFLiveShows.Models
{
    public class Live
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Venue { get; set; }
        public string TicketUrl { get; set; }
        public string ImageUrl { get; set; }
        public string MapsUrl { get; set; }
        public Live()
        {
        }
    }
}
