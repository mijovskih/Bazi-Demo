using System.ComponentModel.DataAnnotations;

namespace Bazi_demo.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public string? Status { get; set; }
        public int AmountAdvance { get; set; }
        public int AmountLeft { get; set; }
        public int NumberInstallments { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public string? CustomerEMBG { get; set; }
        public Customer? Customer { get; set; }
    }
}
