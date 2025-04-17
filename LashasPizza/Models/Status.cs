using Microsoft.EntityFrameworkCore;

namespace LashasPizza.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string status_s { get; set; }
        public string description { get; set; }
    }
}
    