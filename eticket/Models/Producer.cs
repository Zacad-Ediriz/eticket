using System.ComponentModel.DataAnnotations;

namespace Eticket.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "FullName")]
        public string Fullname { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        //Relationship
        public List<Movie> Movie { get; set; }
    }
}
