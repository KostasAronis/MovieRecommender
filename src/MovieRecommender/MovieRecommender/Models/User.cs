using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Models
{
    public class User : BaseModel
    {
        public User()
        {
            this.UserMovies = new List<UserMovie>();
            this.FavoriteGenres = new List<MovieGenre>();
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserStatus UserStatus { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<MovieGenre> FavoriteGenres { get; set; }
        public List<UserMovie> UserMovies { get; set; }

        [NotMapped]
        public string StatusText { get => UserStatus.ToString(); }
        [NotMapped]
        public string StatusActionText { get => UserStatus == UserStatus.NotApproved ? "Approve" : "Delete"; }
    }
    public enum UserStatus
    {
        NotFound = 0,
        NotApproved = 1,
        FirstLogin = 2,
        ApprovedUser = 3,
        Admin = 4
    }
    public static class UserStatusExtensions
    {
        //public static string ToFriendlyString(this UserStatus status)
    }
}
