using System;

namespace JobPortal.Admin.Models
{
    public partial class JobsDefinitionModel
    {
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

    }
}