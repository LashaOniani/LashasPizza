using System.ComponentModel.DataAnnotations.Schema;

namespace LashasPizza.Models
{
    public class Orders
    {
        public int Id { get; set; }
        [ForeignKey("person")]
        public int CustomerId { get; set; }
        [ForeignKey("pizza")]
        public int PizzaId { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
