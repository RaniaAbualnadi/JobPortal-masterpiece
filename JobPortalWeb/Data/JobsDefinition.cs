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
    
    public partial class JobsDefinition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobsDefinition()
        {
            this.JobApplications = new HashSet<JobApplication>();
        }
    
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public Nullable<System.DateTime> StartPublishDate { get; set; }
        public Nullable<System.DateTime> EndPublishDate { get; set; }
        public Nullable<int> MinDegreeId { get; set; }
        public string Major { get; set; }
        public Nullable<int> MinYearsOfExperance { get; set; }
        public string JobRequirement { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Degree Degree { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}
