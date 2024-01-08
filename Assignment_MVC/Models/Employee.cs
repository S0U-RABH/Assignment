using System.ComponentModel.DataAnnotations;

namespace Assignment_MVC.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Hostel { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string ShirtSize { get; set; }
    }
}
