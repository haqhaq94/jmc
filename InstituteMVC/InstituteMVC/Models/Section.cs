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
        public int classId { get; set; }
        public string classNameCode { get; set; }
        public DateTime Timeing { get; set; }
        public int Fee { get; set; }
        public bool IsReady { get; set; }
        public bool Issent { get; set; }
        [Key, Column(Order = 1)]
        public int SDate { get; set; }
        public bool isActive { get; set; }

        public virtual Session Session { get; set; }
        
    }
}
