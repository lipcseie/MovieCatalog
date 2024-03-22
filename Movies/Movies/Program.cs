using Microsoft.EntityFrameworkCore;
using Movies.Context;
using Movies.Models;

namespace Vidzy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new MovieLibraryDbContext())
            {


                // *** Retrieve all videos from the database. ***

                var allVideos = context.Movies.ToList();

               Console.WriteLine("All videos:");
                foreach( var v in allVideos)
                {
                    Console.WriteLine(v.Name);
                }

                // *** Retrieve all videos released after a specific date. ***

                var after2000 = context.Movies
                    .Where(v => v.ReleaseDate > new DateTime(2000,1,1));

                Console.WriteLine("\nMovies after 2000: ");

                foreach ( var v in after2000)
                {
                    if(v != null)
                    {
                        Console.WriteLine(v.Name);
                    }
                }

                // *** Retrieve all videos with a particular classification. ***

                var platinum = context.Movies
                    .Where(v => v.Classification == Classification.Platinum);


                Console.WriteLine("\nPlatinum: ");
                foreach ( var v in platinum)
                {
                    if(v != null)
                    {
                        Console.WriteLine($"{v.Name}, {Classification.Platinum}");
                    }
                }

                // *** Retrieve all videos with their associated genres. ***

                var videosWithGenres = context.Movies
                    .Include(v => v.Genres).ToList();
                   
                Console.WriteLine("\nRetrieve all videos with their associated genres");

                foreach(var video in videosWithGenres)
                {
                    if(video != null && video.Genres != null)
                    {
                        Console.WriteLine($"Video: {video.Name}");
                        Console.WriteLine("Genre: ");
                        Console.WriteLine(video.Genres.Name);
                    }
                }

                // *** Retrieve all genres along with the count of videos in each genre. ***


                // *** Add data ***


                var genre = context.Genres.Single(g => g.Id == 2);

                var video5 = new Movie
                {
                    Name = "Shrek 4",
                    ReleaseDate = DateTime.Parse("2010-04-22"),
                    Genres = genre,
                    // GenreId = 2,
                    Classification = Classification.Silver
                };


                // context.Videos.Add(video5);

                // *** Modify data **

                var video6 = context.Movies.Find(4); // Single(v => v.Id == 4)
                video6.Name = "New Name 2";
                video6.GenreId = 2;

                 
                // *** Remove data ***

                var video7 = context.Movies.Find(12);
                context.Movies.Remove(video7);

                context.SaveChanges();

            }
        }
    }
}
