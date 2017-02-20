using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class Fee
    {
        [Key, Column(Order = 0)]
        public int FeeMonth { get; set; }
        [Key, Column(Order = 1)]
        public string CR { get; set; }
        [Key, Column(Order = 2)]
        public int SDate { get; set; }
        

        public int Feeid { get; set; }

        public DateTime EntryDate { get; set; }
        public int FeeAmount { get; set; }
        public string VoucherNo { get; set; }
        public bool Sent { get; set; }


        public virtual Student Student { get; set; }

    }
}
