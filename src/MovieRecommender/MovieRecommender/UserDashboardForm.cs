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

        public UserDashboardForm(MovieDBContext db, User user)
        {
            InitializeComponent();
            _db = db;
            _user = user;
            this.FormClosed += UserDashboardForm_FormClosed;
            Movies = getDashboardMovies();
            movieListView.SetObjects(Movies);
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
            return movies;
        }
        private List<Movie> getOwnedMovies()
        {
            var movies = _user.UserMovies.Select(um => um.Movie).ToList();
            return movies;
        }
        private List<Movie> getSuggestedMovies()
        {
            var userMovies = _user.UserMovies.Select(um => um.Movie).ToList();
            var movies = _db.Movies
                .Include(m => m.Genres)
                .ToList();
             var selectedMovies = movies.Where(m =>
                    !userMovies.Select(mov=>mov.Id).Contains(m.Id) &&
                    m.Genres.Intersect(_user.FavoriteGenres).Any()
                ).ToList();
            return selectedMovies;
        }

        private void UserDashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dashboardButton_Click(object sender, EventArgs e)
        {
            viewLabel.Text = "Dashboard";
            Movies = getDashboardMovies();
            movieListView.SetObjects(Movies);
        }

        private void ownedButton_Click(object sender, EventArgs e)
        {
            viewLabel.Text = "Owned";
            Movies = getOwnedMovies();
            movieListView.SetObjects(Movies);
        }

        private void suggestionsButton_Click(object sender, EventArgs e)
        {
            viewLabel.Text = "Suggested";
            Movies = getSuggestedMovies();
            movieListView.SetObjects(Movies);
        }

        private void movieListView_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var selectedMovie = (Movie)e.Item.RowObject;                
            if (e.Column == descriptionColumn)
            {
                MessageBox.Show(selectedMovie.Description);
                return;
            }
        }
    }
}
