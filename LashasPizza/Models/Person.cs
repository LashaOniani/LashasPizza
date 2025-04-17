using System.ComponentModel.DataAnnotations.Schema;

namespace LashasPizza.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        [ForeignKey("status")]
        public int StatusId { get; set; }
    }
}
