using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Vidzy
{
    public class VidzyDbContext: DbContext
    {
      public DbSet<Video> Videos { get; set; }

      public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\DESKTOP-I445CNP\\SQLEXPRESS;Database=Vidzy;Trusted_Connection=True;");
        }
    }
}
