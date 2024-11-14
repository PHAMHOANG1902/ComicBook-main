using System.ComponentModel.DataAnnotations;

namespace ComicSystemAPI.Models
{
    public class RentalDetail
    {
        [Key]
        public int RentalDetailID { get; set; }

        public int RentalID { get; set; }

        public int ComicBookID { get; set; }

        public int Quantity { get; set; }

        [Range(0, 999999)]
        public decimal PricePerDay { get; set; }

        public Rental Rental { get; set; }

        public ComicBook ComicBook { get; set; }
    }
}
