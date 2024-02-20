using Bazi_demo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bazi_demo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<VehicleType>? VehicleTypes { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Manager>? Managers { get; set; }
        public DbSet<Shift>? Shifts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Bazi_demo.Models.Payment>? Payment { get; set; }
    }
}