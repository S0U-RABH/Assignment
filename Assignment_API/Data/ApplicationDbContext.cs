using Assignment_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmpID = 1,
                    FirstName = "Akash",
                    LastName = "Roy",
                    Company = "TTS",
                    Designation = "Something",
                    Degree = "B.Tech",
                    Department = "EE",
                    Hostel = "Boys Hostel",
                    Gender = "Male",
                    Country = "India",
                    City = "Kolkata",
                    ShirtSize = "42"
                },
                new Employee
                {
                    EmpID = 2,
                    FirstName = "Aman",
                    LastName = "verma",
                    Company = "TTs",
                    Designation = "Something",
                    Degree = "B.Tech",
                    Department = "CSE",
                    Hostel = "Boys Hostel",
                    Gender = "Male",
                    Country = "India",
                    City = "Delhi",
                    ShirtSize = "40"
                }
                );
        }


    }
}
