using MovieRecommender.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRecommender
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var connString = ConfigurationManager
                .ConnectionStrings["MovieDB"]
                .ConnectionString;
            MovieDBContext movieDB = new MovieDBContext(connString);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var loginForm = new LoginForm(movieDB);
            loginForm.Show();
            Application.Run();
        }
    }
}
