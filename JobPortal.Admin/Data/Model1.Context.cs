﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortal.Admin.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EmploymentGateEntities : DbContext
    {
        public EmploymentGateEntities()
            : base("name=EmploymentGateEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CVEducation> CVEducations { get; set; }
        public virtual DbSet<CvJob> CvJobs { get; set; }
        public virtual DbSet<CVSkill> CVSkills { get; set; }
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<EmailNotification> EmailNotifications { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<InterviewType> InterviewTypes { get; set; }
        public virtual DbSet<JobApplication> JobApplications { get; set; }
        public virtual DbSet<JobsDefinition> JobsDefinitions { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ScheduledInterview> ScheduledInterviews { get; set; }
    }
}