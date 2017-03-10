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
        public ClassVM Class { get; set; }
        public int SlctdClassVal { get; set; }
        [Required(ErrorMessage="Name is required")]
        [Display(Name="Section Name")]
        public string SectionName { get; set; }
        [Required(ErrorMessage="Timing is required")]
        public System.TimeSpan? Timing { get; set; }
        public SessionVM Sessions { get; set; }

        public SectionVM()
        {
            Sessions = new SessionVM();
            Class =  new ClassVM();
        }
        
        
    }
}