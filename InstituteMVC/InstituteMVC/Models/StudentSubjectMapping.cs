using InstituteMVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InstituteMVC.Models
{
    public class StudentSubjectMapping
    {
        [Key]
        public int ID { get; set; }
        public int SbjID { get; set; }
        public string CR { get; set; }
        public int SDate { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Student Student { get; set; }
    }
}