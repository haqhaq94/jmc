using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Student
    {

        public int bioID { get; set; }
        [Key, Column(Order = 1)]
        public string CR { get; set; }
        [Key, Column(Order = 2)]
        public int SDate { get; set; }

        public string ClassID { get; set; }
        public string InnerRollNo { get; set; }
        public bool IsActive { get; set; }
        public bool FeeStatus { get; set; }
        public bool AttStatus { get; set; }
        public Nullable<System.DateTime> EnrolDate { get; set; }
        public bool OnLeave { get; set; }

        public virtual BioData BioData { get; set; }
        
        public Student()
        {
            EnrolDate = DateTime.Now;
        }
    }
}
