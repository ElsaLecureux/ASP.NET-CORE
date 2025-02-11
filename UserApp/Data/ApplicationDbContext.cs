using Microsoft.EntityFrameworkCore;
using Models;

namespace Data {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):
base(options){}
        public DbSet<User> Users {get; set;}

        public DbSet<UserProfile> UserProfiles {get; set;}
    }
}