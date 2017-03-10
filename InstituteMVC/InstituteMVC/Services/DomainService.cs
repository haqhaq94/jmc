using InstituteMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstituteMVC.Services
{
    public  class DomainService
    {
        
        public static int getStudentID(int Sdate,string classId)
        {
            InstituteContext db = new InstituteContext();
            var id = from cls in db.Class.Where(cs => cs.classId.ToString().Substring(0, 2) == classId && cs.SDate == Sdate)
                     select cls.classId;
            return 0;
                
        }
    }
}