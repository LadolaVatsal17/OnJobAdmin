using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEntity.AdminModel
{
    public class Industry
    {
        [Required(ErrorMessage = "Industry Name Is Required.")]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Not valid Industry Name")]
        public string industry_name { get; set; }
        public int ind_id { get; set; }
        public int Is_active { get; set; }
    }
}
