using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeStore.ViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Need to fill")]
        
        [MaxLength(5, ErrorMessage = "Can't be more than 5 charracters")]
        public string SupplierCode { get; set; }

         
        public string SupplierName { get; set; }
         
        public string Address { get; set; }

         [RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers allowed")]
         [MaxLength(12, ErrorMessage = "Can't be more than 12 charracters")]
        
        public string Phone { get; set; }
         
        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}
