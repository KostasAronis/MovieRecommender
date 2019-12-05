using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovieRecommender.Models;
using System.Data.Entity;

namespace MovieRecommender
{
    public partial class UserDashboardForm : Form
    {
        private MovieDBContext _db;
        private User _user;
        public List<Movie> Movies;
        string currentView;

        public UserDashboardForm(MovieDBContext db, User user)
        {
            InitializeComponent();
            _db = db;
            _user = user;
            if (_user.Age > 60)
            {
                SetAllControlsFont(this.Controls, 4);
            }
            this.FormClosed += UserDashboardForm_FormClosed;
            goToDashboard();
        }
        public void SetAllControlsFont(Control.ControlCollection ctrls, int sizeChange)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl.Controls != null)
                    SetAllControlsFont(ctrl.Controls, sizeChange);

                ctrl.Font = new Font(ctrl.Font.FontFamily, ctrl.Font.Size + sizeChange);

            }
        }
        private void ConvertMoviesToRows(List<Movie> movies)
        {
            movies.ForEach(movie =>
            {
                var userMovie = _user.UserMovies
                    .Where(um => um.Movie.Id == movie.Id)
                    .FirstOrDefault();
                if (userMovie != null)
                {
                    movie.MovieStatusString = userMovie.MovieStatus.ToString();
                }
                else
                {
                    movie.MovieStatusString = MovieStatus.NotOwned.ToString();
                }
            });
        }
        private List<Movie> getDashboardMovies()
        {
            var movies = _db.Movies.Include( m => m.Genres ).ToList();
            movies.ForEach(movie =>
            {
                var userMovie = _user.UserMovies
                    .Where(um => um.Movie.Id == movie.Id)
                    .FirstOrDefault();
                if (userMovie != null)
                {
                    movie.MovieStatusString = userMovie.MovieStatus.ToString();
                }
                else
                {
                    movie.MovieStatusString = MovieStatus.NotOwned.ToString();
                }
            });
            ConvertMoviesToRows(movies);
            return movies;
        }
        private List<Movie> getOwnedMovies()
        {
            var movies = _user.UserMovies.Select(um => um.Movie).ToList();
            ConvertMoviesToRows(movies);
            return movies;
        }

        private List<Movie> getSuggestedMovies()
        {
            var userMovies = _user.UserMovies.Select(um => um.Movie).ToList();
            var movies = _db.Movies
                .Include(m => m.Genres)
                .ToList();
            var likedMovies = userMovies.Where(um => um.MovieStatusString == MovieStatus.Liked.ToString());
            var favoriteGenres = _user.FavoriteGenres;
            var favoriteDirectors = likedMovies.Select(um => um.Director).Distinct();
            var usersWithMovies = _db.Users
                .Include(u => u.UserMovies
                    .Select(um => um.Movie)
                )
                .Include(u => u.UserMovies
                    .Select(um => um.Movie.Genres)
                )
                .ToList();
            var usersThatLikedTheSameMovies = usersWithMovies
                .Where(u => u.UserMovies
                    .Any(um => 
                        um.MovieStatus == MovieStatus.Liked &&
                        likedMovies.Any(lm => lm.Id == um.Movie.Id)
                    )
                );
            var otherMoviesThoseUsersLike = usersThatLikedTheSameMovies
                .SelectMany(u => u.UserMovies
                    .Where(umm => !userMovies
                        .Select(um => um.Id)
                        .Contains(umm.Id)
                    ).Select(m => m.Movie)
                );

            var selectedMovies = movies.Where(m =>
                (
                    !userMovies.Select(mov => mov.Id).Contains(m.Id)
                )
                &&
                (
                    m.Genres.Intersect(favoriteGenres).Any() || // movies of his favorite genres
                    favoriteDirectors.Contains(m.Director) || //movies of his favorite director
                    otherMoviesThoseUsersLike.Select(mov => mov.Id).Contains(m.Id) // movies other people that like the same movies as this user like
                )
            ).ToList();
            ConvertMoviesToRows(selectedMovies);
            return selectedMovies;
        }

        private void UserDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void dashboardButton_Click(object sender, EventArgs e)
        {
            goToDashboard();
        }
        private void ownedButton_Click(object sender, EventArgs e)
        {
            goToOwned();
        }
        private void suggestionsButton_Click(object sender, EventArgs e)
        {
            goToSuggestions();
        }
        private void goToDashboard()
        {
            viewLabel.Text = "Dashboard";
            Movies = getDashboardMovies();
            movieListView.SetObjects(Movies);
            currentView = "Dashboard";
        }
        private void goToSuggestions()
        {
            viewLabel.Text = "Suggested";
            Movies = getSuggestedMovies();
            movieListView.SetObjects(Movies);
            currentView = "Suggested";
        }
        private void goToOwned()
        {
            viewLabel.Text = "Owned";
            Movies = getOwnedMovies();
            movieListView.SetObjects(Movies);
            currentView = "Owned";
        }
        private void refreshList()
        {
            switch (currentView)
            {
                case "Dashboard":
                    goToDashboard();
                    break;
                case "Owned":
                    goToOwned();
                    break;
                case "Suggested":
                    goToSuggestions();
                    break;
            }
        }
        private void movieListView_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var selectedMovie = (Movie)e.Item.RowObject;
            if (e.Column == descriptionColumn)
            {
                MessageBox.Show(selectedMovie.Description);
                return;
            }
            if (e.Column == likeColumn)
            {
                var umovie = _user.UserMovies.Where(um => um.Movie.Id == selectedMovie.Id).FirstOrDefault();
                if (umovie != null)
                {
                    if(umovie.MovieStatus == MovieStatus.Owned)
                    {
                        umovie.MovieStatus = MovieStatus.Liked;
                    }
                    else
                    {
                        umovie.MovieStatus = MovieStatus.Owned;
                    }
                    _db.SaveChanges();
                }
            }
            if (e.Column == dislikeColumn)
            {
                var umovie = _user.UserMovies.Where(um => um.Movie.Id == selectedMovie.Id).FirstOrDefault();
                if (umovie != null)
                {
                    if (umovie.MovieStatus == MovieStatus.Owned)
                    {
                        umovie.MovieStatus = MovieStatus.Disliked;
                    }
                    else
                    {
                        umovie.MovieStatus = MovieStatus.Owned;
                    }
                    _db.SaveChanges();
                }
            }
            if (e.Column == purchaseColumn)
            {

                var creditCardNo = UserDashboardForm.ShowDialog("Insert credit card No.", "Purchase " + selectedMovie.Title);
                if (String.IsNullOrEmpty(creditCardNo) || creditCardNo.Length != 19)
                {
                    MessageBox.Show("Invalid card number!");
                }
                else
                {
                    var umovie = new UserMovie()
                    {
                        Movie = selectedMovie,
                        User = _user,
                        MovieStatus = MovieStatus.Owned
                    };
                    _user.UserMovies.Add(umovie);
                    _db.SaveChanges();
                }
            }
            refreshList();
        }
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            //TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            MaskedTextBox textBox = new MaskedTextBox() { Left = 50, Top = 50, Width = 400 };
            textBox.Mask = "0000-0000-0000-0000";
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
