using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace verstatest.Models
{
    [Owned]
    public class Address
    {        
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Details { get; set; }        
        public Address() { Region = ""; City = ""; Details = ""; }
    }
}
