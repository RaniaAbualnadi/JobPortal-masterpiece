//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class JobApplication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobApplication()
        {
            this.ScheduledInterviews = new HashSet<ScheduledInterview>();
        }
    
        public int Id { get; set; }
        public int JobId { get; set; }
        public int ApplicantProfileId { get; set; }
        public System.DateTime ApplicationDate { get; set; }
    
        public virtual JobsDefinition JobsDefinition { get; set; }
        public virtual Profile Profile { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduledInterview> ScheduledInterviews { get; set; }
    }
}
