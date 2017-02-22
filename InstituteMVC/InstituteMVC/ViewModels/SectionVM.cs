using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC.ViewModels
{
    public class SectionVM
    {
        public ClassVM Class { get { return new ClassVM(); } }
        
        [Required]
        public string SectionName { get; set; }
        [Required]
        public DateTime? Timing { get; set; }
        public SessionVM Sessions { get; set; }

        public SectionVM()
        {
            Sessions = new SessionVM();
        }
        
        
    }
}