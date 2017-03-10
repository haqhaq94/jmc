using InstituteMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteMVC.Models
{
    public class SectionSubjectMapping
    {
        [Key]
        public int ID { get; set; }
        public int SbjID { get; set; }
        public string classId { get; set; }
        public Nullable<short> SDate { get; set; }

        public virtual Subject Subject{ get; set; }
        public virtual Section Section { get; set; }
    }
}