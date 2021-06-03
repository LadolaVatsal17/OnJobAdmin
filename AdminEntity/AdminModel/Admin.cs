using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminEntity.AdminModel
{
    public class Admin
    {
        //Admin_id
        public int Admin_id { get; set; }

        //Email
        [Required(ErrorMessage = "Email Is Required.")]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+))@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+))\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        //Password
        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "Password Is Required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }


        //Mobile Number
        [Required(ErrorMessage = "Mobile Number Is Required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public long Mobileno { get; set; }

        //New Password
        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "New Password Is Required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string NewPassword { get; set; }

        //Conform Password
        [DataType(DataType.Password)]
        //[Required(ErrorMessage = "Conform Password Is Required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string ConformPassword { get; set; }

        public List<Company> lstCompany { get; set; }
        
        public List<Users> lstUsers { get; set; }

        public List<JobPost> lstjobpost { get; set; }

        public List<Category> lstCategory { get; set; }
        public List<State> lstState { get; set; }
        public List<City> lstCity { get; set; }
        public List<Industry> lstIndustry { get; set; }

        public int all_users { get; set; }
        public int all_active { get; set; }
        public int all_deactive { get; set; }
        public int all_company { get; set; }
        public int all_active_cmp { get; set; }
        public int all_deactive_cmp { get; set; }
    }
}