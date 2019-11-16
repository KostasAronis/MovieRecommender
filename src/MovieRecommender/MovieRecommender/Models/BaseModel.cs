using System.ComponentModel.DataAnnotations;

namespace MovieRecommender.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}