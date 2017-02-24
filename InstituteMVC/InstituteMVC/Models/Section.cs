using InstituteMVC.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Section
    {
        [Key, Column(Order = 0)]
        public string classId { get; set; }
        [Key, Column(Order = 1)]
        public int SDate { get; set; }

        public string classNameCode { get; set; }
        public System.TimeSpan Timeing { get; set; }
        public int Fee { get; set; }
        public bool IsReady { get; set; }
        public bool Issent { get; set; }
        
        public bool isActive { get; set; }

        public virtual Session Session { get; set; }

        public void setSectionId(int SDate,string SlctdClass)
        {
           
        }
    }
}
