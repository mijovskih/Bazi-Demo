using System.ComponentModel.DataAnnotations;

namespace Bazi_demo.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
