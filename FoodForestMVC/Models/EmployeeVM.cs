
using FoodForestMVC.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FoodForestMVC.Models
{
    public enum EmployeeStatus
    {
       
        Active =1,
        Resigned = 2,
        Terminated=3
    }
    public class EmployeeVM
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "*")] 
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
        public EmployeeVM()
        { 
            ImagePath = "~/AppFiles/EmployeePhoto/Default.png"; 
        }
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "*")]
        public DateTime? Dob { get; set; } 

       
        [Display(Name = "Hire Date")]
        [Required(ErrorMessage = "*")]
        public DateTime JoinDate { get; set; }
        [Display(Name = "Resigned Date")]
        
        public DateTime? ResignDate { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")] 
        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }
        [Required(ErrorMessage = "*")]
        public int Status { get; set; }
        [Display(Name ="Employee Id")]
        [Required(ErrorMessage ="*")]
        public String EmployeeId { get; set; } 
        public string MiddleName { get; set; }
    }

}
