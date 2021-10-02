using DotNetRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetRestApi.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base (options)
        {
            
        }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
    }
}