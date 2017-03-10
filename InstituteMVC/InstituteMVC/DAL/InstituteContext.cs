using InstituteMVC.Model;
using InstituteMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InstituteMVC.DAL
{
    public class InstituteContext : DbContext
    {
        public DbSet<BioData> BioData { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Exit> Exit { get; set; }
        public DbSet<Fee> Fee { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Section> Class { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<SectionSubjectMapping> SectionSubjectMapping { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<StudentSubjectMapping> StudentSubjectMapping { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            
        //}

        
    }
}