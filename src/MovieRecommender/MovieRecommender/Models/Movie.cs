using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Models
{
    public class Movie : BaseModel
    {
        public string Title { get; set; }
        public List<MovieGenre> Genres { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
        [NotMapped]
        public string MovieStatusString { get; set; }

        [NotMapped]
        public string GenreString { get => String.Join(", ", Genres.Select(g => g.Name).ToArray()); }


        [NotMapped]
        public string DescriptionButtonText { get => "View"; }

        [NotMapped]
        public string LikeButtonText { get => 
            MovieStatusString == MovieStatus.Liked.ToString() ||
            MovieStatusString == MovieStatus.NotOwned.ToString() 
            ? null 
            : "Like"; 
        }
        [NotMapped]
        public string DislikeButtonText { get => 
            MovieStatusString == MovieStatus.Disliked.ToString() ||
            MovieStatusString == MovieStatus.NotOwned.ToString()
            ? null 
            : "Dislike"; 
        }
        [NotMapped]
        public string PurchaseButtonText { get =>
            MovieStatusString == MovieStatus.NotOwned.ToString()
            ? "Purchase"
            : null;
        }
    }
}
