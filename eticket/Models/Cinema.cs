using System.ComponentModel.DataAnnotations;

namespace Eticket.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo")]
        public string logo { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        //Relationship
        public List<Movie> Movie { get; set; }


    }
}
