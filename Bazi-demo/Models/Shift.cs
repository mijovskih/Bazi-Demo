using System.ComponentModel.DataAnnotations;

namespace Bazi_demo.Models
{
    public class Shift
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
