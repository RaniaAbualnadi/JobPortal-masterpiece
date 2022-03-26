using System;

namespace JobPortal.Admin.Models
{
    public class JobApplicationModel
    {
        public string JobTitle { get; set; }
        public string UserName { get; set; }
        public DateTime ApplyDate { get; set; }
        public int JobAppliactionId { get; set; }
        public int JobId { get; set; }
    }
}