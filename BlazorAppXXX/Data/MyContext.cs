using BlazorAppXXX.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppXXX.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) { }


        public DbSet<Employee> Employees { get; set; }
    }
}
