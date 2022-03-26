//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobPortalWeb.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScheduledInterview
    {
        public int Id { get; set; }
        public int JobApplicationId { get; set; }
        public System.DateTime InvitationDate { get; set; }
        public System.DateTime InterviewDate { get; set; }
        public bool IsAttended { get; set; }
        public int InterviewTypeId { get; set; }
        public bool IsPassed { get; set; }
        public Nullable<double> Score { get; set; }
        public Nullable<bool> ArchivedForLater { get; set; }
        public string InterviewReport { get; set; }
    
        public virtual InterviewType InterviewType { get; set; }
        public virtual JobApplication JobApplication { get; set; }
    }
}
