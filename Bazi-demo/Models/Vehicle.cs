using System.ComponentModel.DataAnnotations;

namespace Bazi_demo.Models
{
    public class Vehicle
    {
        [Key]
        public string? VIN {  get; set; }
        public string? RegistrationNumber { get; set; }
        public string? Brand { get; set; }
        public string? FuelType { get; set; }
        public string? TransmissionType { get; set; }
        public int NumberDoors { get; set; }
        public int NumberSeats { get; set; }
        public int Mileage { get; set; }
        public bool IsRented { get; set; }
        public VehicleType? Type { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
