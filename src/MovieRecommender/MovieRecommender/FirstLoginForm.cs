using MovieRecommender.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRecommender
{
    public partial class FirstLoginForm : Form
    {
        private User _user;
        private MovieDBContext _db;
        private List<MovieGenre> genres;
        public FirstLoginForm(MovieDBContext db, User user)
        {
            _db = db;
            _user = user;
            genres = _db.MovieGenres.ToList();
            InitializeComponent();
            this.FormClosed += FirstLoginForm_FormClosed;
            favoriteGenresSelect.Items.AddRange(genres.Select(g => g.Name).ToArray());
        }

        private void FirstLoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private List<string> getFavoriteGenres()
        {
            List<string> favoriteGenres = new List<string>();
            foreach (var item in favoriteGenresSelect.CheckedItems)
            {
                favoriteGenres.Add(item.ToString());
            }
            return favoriteGenres;
        }
        private string getGender()
        {
            var gender = genderDropdown.SelectedItem?.ToString() ?? "Other";
            return gender;
        }
        DateTime zeroTime = new DateTime(1, 1, 1);
        private int getAge()
        {
            var now = DateTime.Now;
            var selected = dobPicker.SelectionRange.Start;
            var span = now - selected;
            int years = (zeroTime + span).Year - 1;
            return years;
        }
        private bool invalidInput(int age, string gender, List<string> selectedGenres)
        {
            return age < 0 || String.IsNullOrEmpty(gender) || selectedGenres == null || selectedGenres.Count == 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var age = getAge();
            var gender = getGender();
            var selectedGenres = getFavoriteGenres();
            if (invalidInput(age,gender,selectedGenres))
            {
                MessageBox.Show("Please fill all required fields!");
                return;
            }
            _user.Age = age;
            _user.Gender = gender;
            _user.FavoriteGenres = genres.Where(g => selectedGenres.Contains(g.Name)).ToList();
            _user.UserStatus = UserStatus.ApprovedUser;
            _db.SaveChanges();
            var dashboardForm = new UserDashboardForm(_db, _user);
            this.Hide();
            dashboardForm.Show();
        }
    }
}
