using System;
using System.ComponentModel.DataAnnotations;

namespace ComicSystemAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}
