using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Test
    {
        [Key, Column(Order = 2)]
        public int SDate { get; set; }
        [Key, Column(Order = 1)]
        public string CR { get; set; }
        [Key, Column(Order = 0)]
        public string TestType { get; set; }
        public DateTime TestDate { get; set; }
        public int TotalMarks { get; set; }
        public float ObtainedMarks { get; set; }
        public bool isPass { get; set; }
        [Key, Column(Order = 3)]
        public int SbjId { get; set; }
        public int TestId { get; set; }
        [Key, Column(Order = 4)]
        public int TtypeNo { get; set; }
        public int Percentage { get; set; }

        public virtual Student Student { get; set; }
        public virtual Session Session { get; set; }
        public virtual Subject Subject { get; set; }

    }
}
