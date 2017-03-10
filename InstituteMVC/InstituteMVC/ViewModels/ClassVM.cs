using InstituteMVC.InfraStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC.ViewModels
{
    public class ClassVM
    {
     
        [Required(ErrorMessage="Please Select Class")]
        [Display(Name = "Select Class")]
        public string SlctdClassVal { get; set; }

        public bool DisplaySection { get; set; }

        public IEnumerable<SelectListItem> ClassList
        {
            get
            {
                List<SelectListItem> classes = new List<SelectListItem>();
                classes.Add(new SelectListItem() { Text = "01", Value = "01" });
                classes.Add(new SelectListItem() { Text = "02", Value = "02" });
                classes.Add(new SelectListItem() { Text = "03", Value = "03" });
                classes.Add(new SelectListItem() { Text = "04", Value = "04" });
                classes.Add(new SelectListItem() { Text = "05", Value = "05" });
                classes.Add(new SelectListItem() { Text = "06", Value = "06" });
                classes.Add(new SelectListItem() { Text = "07", Value = "07" });
                classes.Add(new SelectListItem() { Text = "08", Value = "08" });
                classes.Add(new SelectListItem() { Text = "09", Value = "09" });
                classes.Add(new SelectListItem() { Text = "10", Value = "10" });
                classes.Add(new SelectListItem() { Text = "11", Value = "11" });
                classes.Add(new SelectListItem() { Text = "12", Value = "12" });
                classes.Add(new SelectListItem() { Text = "13", Value = "13" });
                classes.Add(new SelectListItem() { Text = "14", Value = "14" });
                classes.Add(new SelectListItem() { Text = "15", Value = "15" });
                classes.Add(new SelectListItem() { Text = "16", Value = "16" });
                //return defualtVal.Concat(classes);
                return classes;
            }
        }

        [ConditionalRequiredAttribute("DisplaySection==true")]
        [Display(Name = "Select Section")]
        public string SlctdSection { get; set; }

        public IEnumerable<SelectListItem> Sections
        {
            get;
            set;
        }



        //private IEnumerable<SelectListItem> defualtVal
        //{

        //    get
        //    {

        //        return Enumerable.Repeat(new SelectListItem { Value = "-1", Text = "Please Select Class" }, count: 1);
        //    }

        //}


    }
}