using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
       public int EmployeeId {  get; set; }
        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(20, ErrorMessage = "Full Name max length is 20 characters")]
        public string EmpName {  get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid Email address")]

        public string Email { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Date of Joining is required")]
        [DataType(DataType.Date)]
        public DateTime Dateofjoin {  get; set; }
        public bool IsActive { get; set; }

    }
}
