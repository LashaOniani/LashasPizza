using LashasPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace LashasPizza.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Pizza> Pizzas { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Orders> Orderss { get; set; } = null!;
    }
}
