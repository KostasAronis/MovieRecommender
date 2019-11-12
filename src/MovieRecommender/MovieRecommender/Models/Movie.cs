using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Models
{
    public class Movie : BaseModel
    {
        public string Title { get; set; }
        public MovieGenre Genre { get; set; }
        public Director Director { get; set; }
        public string Description { get; set; }
        public Double Price { get; set; }
    }
}
