using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEntity.AdminModel
{
    public class City
    {
        public int City_id { get; set; }

        [Required(ErrorMessage = "City Name Is Required.")]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Not valid City Name")]
        public string City_name { get; set; }
        
        public int Is_active { get; set; }
        public int State_id { get; set; }

        public string State_name { get; set; }
    }
}
