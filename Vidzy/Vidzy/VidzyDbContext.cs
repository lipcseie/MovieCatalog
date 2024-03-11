using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;


namespace Vidzy
{
    public class VidzyDbContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }

        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I445CNP\\SQLEXPRESS;Database=Vidzy;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>()
                        .HasMany(g => g.Videos)
                        .WithOne(v => v.Genres);

            modelBuilder.Entity<Genre>().HasData(

                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Fantasy" }

                );

            base.OnModelCreating(modelBuilder); 
        }

    }
}
