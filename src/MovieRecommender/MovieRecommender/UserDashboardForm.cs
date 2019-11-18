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
            this.FormClosed += UserDashboardForm_FormClosed;
            goToDashboard();
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
                var umovie = new UserMovie()
                {
                    Movie = selectedMovie,
                    User = _user,
                    MovieStatus = MovieStatus.Owned
                };
                _user.UserMovies.Add(umovie);
                _db.SaveChanges();
            }
            refreshList();
        }
    }
}
