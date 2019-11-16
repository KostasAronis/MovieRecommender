using MovieRecommender.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Entity;
using System.Windows.Forms;

namespace MovieRecommender
{
    public partial class LoginForm : Form
    {
        private MovieDBContext _db;

        public LoginForm(MovieDBContext dbContext)
        {
            _db = dbContext;
            InitializeComponent();
        }
        private string getEmailInput()
        {
            return emailBox.Text;
        }
        private string getPassInput()
        {
            return passwordBox.Text;
        }
        private bool inputEmpty()
        {
            if(String.IsNullOrEmpty(getEmailInput())|| String.IsNullOrEmpty(getPassInput()))
            {
                MessageBox.Show("Email and Password fields are required!");
                return true;
            }
            return false;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (inputEmpty())
                return;
            var email = getEmailInput();
            var pass = getPassInput();
            switch (GetUserStatus(email, pass))
            {
                case UserStatus.NotFound:
                    MessageBox.Show("No user found with the provided email/password combination!");
                    break;
                case UserStatus.ApprovedUser:
                    var user = GetUser(email, pass);
                    var dashboardForm = new UserDashboardForm(_db, user);
                    this.Close();
                    dashboardForm.Show();
                    break;
                case UserStatus.FirstLogin:
                    break;
                case UserStatus.Admin:
                    var adminForm = new AdminForm(_db);
                    this.Close();
                    adminForm.Show();
                    break;
                case UserStatus.NotApproved:
                    MessageBox.Show("Your registration request has not yet been approved by the administrators!");
                    break;
                default:
                    break;
            }
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            if (inputEmpty())
                return;
            var email = getEmailInput();
            if (UserExists(email))
            {
                MessageBox.Show("This email is already in use by a registered user!");
            }
            _db.Users.Add(new User
            {
                Email = email,
                Password = getPassInput(),
                UserStatus = UserStatus.NotApproved                
            });
            _db.SaveChanges();
        }
        private UserStatus GetUserStatus(string email, string password)
        {
            if(_db.Admins.Any(a => a.Email == email && a.Password==password))
            {
                return UserStatus.Admin;
            }
            var user = _db.Users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
            if (user == null)
            {
                return UserStatus.NotFound;
            }
            return user.UserStatus;
        }
        private User GetUser(string email, string password)
        {
            var users = _db.Users
                .Include(u => u.FavoriteGenres)
                .Include(u => u.UserMovies
                    .Select(um => um.Movie)
                )
                .Include(u => u.UserMovies
                    .Select(um => um.Movie.Genres)
                )
                .ToList();
            var user = users
                .Where(u => u.Email == email && u.Password == password)
                .FirstOrDefault();
            if (user != null)
            {
                user.UserMovies.ForEach(um => um.Movie.MovieStatusString = um.MovieStatus.ToString());
            }
            return user;
        }
        private bool UserExists(string email)
        {
            return _db.Users.Any(u => u.Email == email) || _db.Admins.Any(a => a.Email == email);
        }
    }
}
