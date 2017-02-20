using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Leave
    {
        [Key, Column(Order = 0)]
        public int leaveID { get; set; }
        public DateTime LeaveFrom { get; set; }
        public DateTime LeaveTo { get; set; }
        public string Reason { get; set; }
        [Key, Column(Order = 1)]
        public int StudentID { get; set; }
        [Key, Column(Order = 2)]
        public int SDate { get; set; }
        public int ttlDays { get; set; }

        public virtual Student Student { get; set; }
        public virtual Session Session { get; set; }
    }
}
