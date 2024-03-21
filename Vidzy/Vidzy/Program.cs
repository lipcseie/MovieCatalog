using Microsoft.EntityFrameworkCore;

namespace Vidzy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new VidzyDbContext())
            {
                //var actionGenre = new Genre { Id = 1, Name = "Action" };
                //var fantasyGenre = new Genre { Id = 2, Name = "Fantasy" };
                //var comedyGenre = new Genre { Id = 3, Name = "Comedy" };

                //var video1 = new Video { Name = "The Matrix", ReleaseDate = DateTime.Parse("1999-03-31"), Genres = actionGenre, Classification =  Classification.Gold };
                //var video2 = new Video { Name = "Inception", ReleaseDate = DateTime.Parse("2010-07-16"), Genres = actionGenre, Classification = Classification.Silver };
                //var video3 = new Video { Name = "The Lord of the Rings: The Fellowship of the Ring", ReleaseDate = DateTime.Parse("2001-12-19"), Genres = fantasyGenre, Classification = Classification.Platinum };
                //var video4 = new Video { Name = "Shrek", ReleaseDate = DateTime.Parse("2001-04-22"), Genres = comedyGenre, Classification = Classification.Silver };

                //context.Genres.AddRange(actionGenre, fantasyGenre, comedyGenre);
                //context.Videos.AddRange(video1, video2, video3, video4);

                //context.SaveChanges();

                // *** Retrieve all videos from the database. ***

                var allVideos = context.Videos.ToList();

               Console.WriteLine("All videos:");
                foreach( var v in allVideos)
                {
                    Console.WriteLine(v.Name);
                }

                // *** Retrieve all videos released after a specific date. ***

                var after2000 = context.Videos
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

                var platinum = context.Videos
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

                var videosWithGenres = context.Videos
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


                // Add data

                var video5 = new Video 
                { Name = "Shrek 2",
                  ReleaseDate = DateTime.Parse("2003-04-22"), 
                  GenreId = 2, 
                  Classification = Classification.Silver 
                };

                context.Videos.Add(video5);

                context.SaveChanges();



            }
        }
    }
}
