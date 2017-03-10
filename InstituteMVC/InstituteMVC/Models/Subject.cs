using InstituteMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Subject
    {
        [Key]
        public int SbjID { get; set; }
        [Required]
        [Display(Name="Subject Name")]
        public string sbjName { get; set; }

        public virtual ICollection<SectionSubjectMapping> SectionSubjectMapping { get; set; }
    }
}
