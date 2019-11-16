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
    public partial class AdminForm : Form
    {
        public List<User> Users { get; set; }

        private MovieDBContext _db;

        public AdminForm(MovieDBContext db)
        {
            InitializeComponent();
            Users = db.Users.ToList();
            _db = db;
            objectListView1.SetObjects(Users);
            this.FormClosed += AdminForm_FormClosed;
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void objectListView1_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            if (e.Column == actionsCol)
            {
                var selectedUser = (User)e.Item.RowObject;
                switch (selectedUser.StatusActionText)
                {
                    case "Delete":
                        _db.Users.Remove(selectedUser);
                        _db.SaveChanges();
                        Users = _db.Users.ToList();
                        break;
                    case "Approve":
                        var dbUser = _db.Users.Find(selectedUser.Id);
                        dbUser.UserStatus = UserStatus.FirstLogin;
                        _db.SaveChanges();
                        Users = _db.Users.ToList();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
