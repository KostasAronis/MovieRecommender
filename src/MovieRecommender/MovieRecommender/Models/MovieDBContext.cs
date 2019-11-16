using MySql.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base()
        {
            Database.SetInitializer(new MovieDbInitializer());
        }

        public MovieDBContext(string connString)
            : base(connString)
        {
            Database.SetInitializer(new MovieDbInitializer());
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        
    }
    public class MovieDbInitializer : DropCreateDatabaseIfModelChanges<MovieDBContext>
    {
        protected override void Seed(MovieDBContext context)
        {
            context.Admins.Add(new Admin()
            {
                Email = "admin@a.com",
                Password = "admin"
            });
            var action = new MovieGenre()
            {
                Name = "Action"
            };
            var drama = new MovieGenre()
            {
                Name = "Drama"
            };
            var comedy = new MovieGenre()
            {
                Name = "Comedy"
            };
            var fantasy = new MovieGenre()
            {
                Name = "Fantasy"
            };
            context.MovieGenres.AddRange(new List<MovieGenre>()
            {
                action, comedy, drama
            });
            context.SaveChanges();
            var harryPotter = new Movie()
            {
                Title = "Harry Potter and the Sorcerer's Stone",
                Description = "An orphaned boy enrolls in a school of wizardry, where he learns the truth about himself, his family and the terrible evil that haunts the magical world.",
                Director = "Chris Columbus",
                Genres = new List<MovieGenre>(),
                Price = 22.59
            };
            harryPotter.Genres.Add(fantasy);
            harryPotter.Genres.Add(action);
            var dieHard = new Movie()
            {
                Title = "Die Hard",
                Description = "An NYPD officer tries to save his wife and several others taken hostage by German terrorists during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                Director = "John McTiernan",
                Genres = new List<MovieGenre>(),
                Price = 22.59
            };
            dieHard.Genres.Add(action);
            context.Movies.AddRange(new List<Movie>()
            {
                harryPotter, dieHard
            });
            context.SaveChanges();
            var approved = new User()
            {
                Age = 28,
                Email = "user@a.com",
                Password = "user",
                Gender = "Male",
                UserStatus = UserStatus.ApprovedUser,
                FavoriteGenres = new List<MovieGenre>()
            };
            approved.FavoriteGenres.Add(action);
            var notApproved = new User()
            {
                Age = 28,
                Email = "not@a.com",
                Password = "not",
                Gender = "Male",
                UserStatus = UserStatus.NotApproved,
                FavoriteGenres = new List<MovieGenre>()
            };
            var firstLogin = new User()
            {
                Age = 28,
                Email = "first@a.com",
                Password = "first",
                Gender = "Male",
                UserStatus = UserStatus.FirstLogin,
                FavoriteGenres = new List<MovieGenre>()
            };
            approved.UserMovies.Add(new UserMovie()
            {
                User = approved,
                Movie = harryPotter,
                MovieStatus = MovieStatus.Owned
            });
            context.Users.AddRange(new List<User>()
            {
                approved, notApproved, firstLogin
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
