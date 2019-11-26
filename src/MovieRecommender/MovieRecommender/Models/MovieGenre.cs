using System.Collections.Generic;

namespace MovieRecommender.Models
{
    public class MovieGenre : BaseModel
    {
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}