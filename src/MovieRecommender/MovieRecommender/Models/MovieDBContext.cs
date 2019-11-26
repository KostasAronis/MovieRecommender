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
                Price = 48.23
            };
            context.Movies.Add(harryPotter);
            harryPotter.Genres.Add(fantasy);
            harryPotter.Genres.Add(action);

            var deadpool = new Movie()
            {
                Title = "Deadpool",
                Description = "A wisecracking mercenary gets experimented on and becomes immortal but ugly, and sets out to track down the man who ruined his looks.",
                Director = "Tim Miller",
                Genres = new List<MovieGenre>(),
                Price = 48.23
            };
            deadpool.Genres.Add(comedy);
            context.Movies.Add(deadpool);

            var lotr1 = new Movie()
            {
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Description = "A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.",
                Director = "Peter Jackson",
                Genres = new List<MovieGenre>(),
                Price = 30
            };
            lotr1.Genres.Add(fantasy);
            context.Movies.Add(lotr1);

            var lotr2 = new Movie()
            {
                Title = "The Lord of the Rings: The Two Towers",
                Description = "While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron's new ally, Saruman, and his hordes of Isengard.",
                Director = "Peter Jackson",
                Genres = new List<MovieGenre>(),
                Price = 30
            };
            lotr2.Genres.Add(fantasy);
            context.Movies.Add(lotr2);
            var lotr3 = new Movie()
            {
                Title = "The Lord of the Rings: The Return of the King",
                Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                Director = "Peter Jackson",
                Genres = new List<MovieGenre>(),
                Price = 30
            };
            lotr3.Genres.Add(fantasy);
            context.Movies.Add(lotr3);
            var theLovelyBones = new Movie()
            {
                Title = "The Lovely Bones",
                Description = "Centers on a young girl who has been murdered and watches over her family - and her killer - from purgatory. She must weigh her desire for vengeance against her desire for her family to heal.",
                Director = "Peter Jackson",
                Genres = new List<MovieGenre>(),
                Price = 20
            };
            theLovelyBones.Genres.Add(drama);
            context.Movies.Add(theLovelyBones);

            var dieHard = new Movie()
            {
                Title = "Die Hard",
                Description = "An NYPD officer tries to save his wife and several others taken hostage by German terrorists during a Christmas party at the Nakatomi Plaza in Los Angeles.",
                Director = "John McTiernan",
                Genres = new List<MovieGenre>(),
                Price = 22.59
            };
            dieHard.Genres.Add(action);
            context.Movies.Add(dieHard);

            var killbill1 = new Movie()
            {
                Title = "Kill Bill: Vol. 1",
                Description = "After awakening from a four-year coma, a former assassin wreaks vengeance on the team of assassins who betrayed her.",
                Director = "Quentin Tarantino",
                Genres = new List<MovieGenre>(),
                Price = 22.59
            };
            killbill1.Genres.Add(action);
            context.Movies.Add(killbill1);

            var killbill2 = new Movie()
            {
                Title = "Kill Bill: Vol. 2",
                Description = "The Bride continues her quest of vengeance against her former boss and lover Bill, the reclusive bouncer Budd, and the treacherous, one-eyed Elle.",
                Director = "Quentin Tarantino",
                Genres = new List<MovieGenre>(),
                Price = 20.59
            };
            killbill1.Genres.Add(action);
            context.Movies.Add(killbill1);
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
