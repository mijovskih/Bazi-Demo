using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bazi_demo.Models
{
    public class Customer
    {
        [Key]
        public string? EMBG { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? IdNumber { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
