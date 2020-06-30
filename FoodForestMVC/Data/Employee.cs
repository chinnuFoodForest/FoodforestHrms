using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace FoodForestMVC.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Dob { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        public DateTime? ResignDate { get; set; }
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; } 
        public int Status { get; set; }  
        public String EmployeeId { get; set; }  
    }
}
