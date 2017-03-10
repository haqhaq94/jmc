using InstituteMVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteMVC.ViewModels
{
    public class SectionSubjectVM
    {
        public ClassVM Class { get; set; }
        public SessionVM Sessions { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IList<string> SlctdSubjects { get; set; }
        public SectionSubjectVM()
        {
            Class = new ClassVM();
            Sessions = new SessionVM(); 
        }
    }
}