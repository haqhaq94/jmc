using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Session
    {
        [Key]
        [Display(Name="Start Date")]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SstartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime? SEndDate { get; set; }
        [Display(Name = "Session Name")]
        public string SName { get; set; }
        public bool IsActive { get; set; }
    }
}
