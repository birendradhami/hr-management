using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hr_management.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Full Name")]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public Gender Gender { get; set; }

        [Required]
        [DisplayName("Join Date")]
        [DataType(DataType.Date)]
        public DateTime JoinDate { get; set; }

        public Designation? Designation { get; set; }

        [DisplayName("Designation")]
        public int DesignationId { get; set; }

        public Department? Department { get; set; }

        [DisplayName("Department")]
        public int DepartmentId { get; set; }

    }
}
