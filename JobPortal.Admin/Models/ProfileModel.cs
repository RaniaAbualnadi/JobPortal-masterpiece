

using System;

namespace JobPortal.Admin.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public System.DateTime Birthdate { get; set; }
        public int GenderId { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string MobileNumber { get; set; }
        public string FullAddress { get; set; }
        public string CoverLetter { get; set; }


    }


}