using AppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
base(options){}
        public DbSet<Product> Products {get; set;}

        public DbSet<Book> Books {get; set;}
    }
}