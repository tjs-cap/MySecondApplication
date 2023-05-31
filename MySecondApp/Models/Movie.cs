using System.ComponentModel.DataAnnotations;

namespace MySecondApp.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(255)]
        [Display(Name ="Movie Title")]
        public string Title { get; set; }
        
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Movie Description")]
        public string Description { get; set; }
        
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set;}

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(3)]
        [Display(Name = "Film Classification")]
        public string Classification { get; set; }

    }
}
