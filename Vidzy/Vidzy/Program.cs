namespace Vidzy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new VidzyDbContext())
            {
                var actionGenre = new Genre { Id = 3, Name = "Action2" };
                var fantasyGenre = new Genre { Id = 4, Name = "Fantasy2" };

                var LOTR = new Video { Name = "LOTR", ReleaseDate = new DateTime(2002, 01, 15), Genres = fantasyGenre };
                var Matrix = new Video { Name = "Matric", ReleaseDate = new DateTime(1999, 02, 02), Genres = actionGenre };
                var LOTR2 = new Video { Name = "LOTR2", ReleaseDate = new DateTime(2004, 06, 12), Genres = fantasyGenre };

                context.Genres.AddRange(actionGenre, fantasyGenre);
                context.Videos.AddRange(LOTR, Matrix, LOTR2);

                context.SaveChanges();



            }
        }
    }
}
