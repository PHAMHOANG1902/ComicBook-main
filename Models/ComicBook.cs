using System.ComponentModel.DataAnnotations;

namespace ComicSystemAPI.Models
{
    public class ComicBook
    {
        [Key]
        public int ComicBookID { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Author { get; set; }

        [Range(0, 999999)]
        public decimal PricePerDay { get; set; }
    }
}
