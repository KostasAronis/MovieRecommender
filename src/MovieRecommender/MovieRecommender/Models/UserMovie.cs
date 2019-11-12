using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Models
{
    public class UserMovie
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MovieId { get; set; }
        public MovieStatus MovieStatus { get; set; }
    }
    public enum MovieStatus
    {
        NotOwned = 0,
        Owned = 1,
        Disliked = 2,
        Liked = 3
    }
}
