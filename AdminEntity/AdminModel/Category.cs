using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEntity.AdminModel
{
    public class Category
    {
        [Required(ErrorMessage = "Category name is required.")]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Not valid Category Name")]
        public string cat_name { get; set; }
        public int cat_id { get; set; }
        
        public int Is_active { get; set; }
    }
}
