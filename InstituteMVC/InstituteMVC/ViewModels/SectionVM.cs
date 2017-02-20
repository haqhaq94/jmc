using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC.ViewModels
{
    public class SectionVM
    {
        public ClassVM Class { get { return new ClassVM(); } }
        public string SectionName { get; set; }
        public DateTime Timing { get; set; }
        public SessionVM Sessions { get; set; }
    }
}