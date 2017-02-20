using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Exit
    {
        [Key, Column(Order = 0)]
        public int ID { get; set; }

        [Key, Column(Order = 1)]
        public string CR { get; set; }
        [Key, Column(Order = 2)]
        public int SDate { get; set; }


        public string Reason { get; set; }
        public DateTime ExitDate { get; set; }

        public virtual Student Student { get; set; }

    }
}
