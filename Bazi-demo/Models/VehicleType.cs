using System.ComponentModel.DataAnnotations;

namespace Bazi_demo.Models
{
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? VehicleVIN { get; set; }
        public Vehicle? Vehicle { get; set; }
    }
}
