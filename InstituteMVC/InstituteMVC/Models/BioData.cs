using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstituteMVC.Model
{
    public class BioData
    {
        [Key]
        public int bioID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string Print1 { get; set; }
        public string Print2 { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string FirstName { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public BioData()
        {
            this.Students = new HashSet<Student>();
        }
    }
}
