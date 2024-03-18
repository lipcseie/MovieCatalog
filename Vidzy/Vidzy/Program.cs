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

                var allVideos = context.Videos.ToList();

               Console.WriteLine("All videos: ");
                foreach( var v in allVideos)
                {
                    Console.WriteLine(v.Name);
                }

            }
        }
    }
}
