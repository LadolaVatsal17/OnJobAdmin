using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdminEntity.AdminModel
{
    public class JobPost
    {
       
        public int job_id { get; set; }
        public int cmp_id { get; set; }

        //job title
        [Required(ErrorMessage = "Job Title is required.")]
        public string job_title { get; set; }
        //job_type
        [Required(ErrorMessage = "Job Type is required.")]
        public string job_type { get; set; }

        //Category
        [Required(ErrorMessage = "Category is required.")]
        public int category_id { get; set; }

        //indus type
        [Required(ErrorMessage = "Industry Type is required.")]
        public int industry_id { get; set; }
        //Total_position
        [Required(ErrorMessage = "Position is Requires required.")]
        public int total_position { get; set; }
        //Working Experience
        [Required(ErrorMessage = "Working Experience is Requires required.")]
        public string working_experience { get; set; }
        //Salary_min
        [Required(ErrorMessage = "Minimum Salary is Requires required.")]
        public int salary_min { get; set; }
        //Salary_max
        [Required(ErrorMessage = "Maxmim Salary is Requires required.")]
        public int salary_max { get; set; }
        //Skills
        [Required(ErrorMessage = "Skills is Requires required.")]
        public string skill { get; set; }
        //Job_desc
        [Required(ErrorMessage = "Job Description is Requires required.")]
        public string job_description { get; set; }
        //Emp_type
        [Required(ErrorMessage = "Employee Type is Requires required.")]
        public string emp_type { get; set; }
        //Education
        [Required(ErrorMessage = "Education is Requires required.")]
        public string qualification_req { get; set; }
        //Expire Date
        [Required(ErrorMessage = "Expiry Date is required.")]
        public DateTime Expiry_date { get; set; }
       
        //State
        [Required(ErrorMessage = "State is required.")]
        public int state_id { get; set; }

        //City
        [Required(ErrorMessage = "City is required.")]
        public int city_id { get; set; }

        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime Date = DateTime.Now.Date;

        public int Is_active { get; set; }


        public string Company_name { get; set; }

        public string cat_name { get; set; }

        public string industry_name { get; set; }
        public string State_name { get; set; }

        public string City_name { get; set; }
    }
}
