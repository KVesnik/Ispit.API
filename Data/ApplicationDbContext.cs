using Ispit.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ShoppingItem> ShoppingItems { get; set; }
    }
}
