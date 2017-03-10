using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteMVC.ViewModels
{
    public class StudentCreationVM
    {
        public string CR { get; set; }
        public int SDate { get; set; }

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
        public string EnDate { get; set; }

        [Required]
        public string RollNo { get; set; }

        public ClassVM Class { get; set; }
        public SessionVM Sessions { get; set; }

        [Required]
        [Display(Name = "Subjects")]
        public IList<string> SlctdSubjects { get; set; }




        public StudentCreationVM()
        {
            Class = new ClassVM();
            Class.DisplaySection = true;
        }
    }
}