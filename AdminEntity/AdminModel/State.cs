using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEntity.AdminModel
{ 
    public class State
    {
        [Required(ErrorMessage = "State name is required.")]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Not valid State Name")]
        public string State_name { get; set; }
        public int State_id { get; set; }
        public int Is_active { get; set; }

    }
}
