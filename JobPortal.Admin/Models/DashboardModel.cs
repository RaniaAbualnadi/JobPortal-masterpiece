using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortal.Admin.Models
{
    public class DashboardModel
    {
        public int JobsCount { get; set; }
        public int AppliedToJobsCount { get; set; }
        public int NumberOfUsers { get; set; } 
        public List<JobsDefinitionModel> JobsList { get; set; }
        public List<JobApplicationModel> JobApplications { get; set; }
        public List<ProfileModel> ProfileList { get; set; }

    }


}