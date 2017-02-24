using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteMVC.ViewModels
{
    public class StudentCreationVM
    {
        [Required]
        [Display(Name="Student Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name="Father Name")]
        public string FathrName { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name="E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Father/Parent Cell No")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Enrollment Date")]
        public DateTime EnDate { get; set; }

        [Required]
        public string RollNo { get; set; }

        public ClassVM Class { get; set; }
        public SessionVM Sessions { get; set; }

        public StudentCreationVM()
        {
            Class = new ClassVM();
        }
    }
}