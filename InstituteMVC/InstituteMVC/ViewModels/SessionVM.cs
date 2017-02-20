using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC.ViewModels
{
    public class SessionVM
    {
        public int SlctdSesstion { get; set; }
        public IEnumerable<SelectListItem> Sessions { get; set; }
    }
}