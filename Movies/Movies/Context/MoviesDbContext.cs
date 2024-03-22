using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Movies.Models;
using System.Linq;


namespace Movies.Context
{
    public class MovieLibraryDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<MovieDirector> MovieDirectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-I445CNP\\SQLEXPRESS;Database=MovieLibrary;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>()
                        .HasMany(g => g.Movies)
                        .WithOne(v => v.Genres);


            modelBuilder.Entity<Movie>()
                .Property(v => v.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Movie>()
                .HasMany(t => t.Tags)
                .WithMany(v => v.Movies)
                .UsingEntity(j => j.ToTable("VideoTags"));

            // composite primary keys 
            modelBuilder.Entity<MovieDirector>()
                .HasKey(md => new { md.MovieId, md.DirectorId });

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Movie)
                .WithMany(m => m.MovieDirectors)
                .HasForeignKey(md => md.DirectorId);

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Director)
                .WithMany(d => d.MovieDirectors)
                .HasForeignKey(md => md.DirectorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
