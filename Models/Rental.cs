using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComicSystemAPI.Models
{
    public class Rental
    {
        [Key]
        public int RentalID { get; set; }

        public int CustomerID { get; set; }
        
        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        public Customer Customer { get; set; }

        public List<RentalDetail> RentalDetails { get; set; }
    }
}
