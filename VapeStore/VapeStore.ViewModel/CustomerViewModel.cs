using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeStore.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        
        public string CostumerName { get; set; }
        
        public string Address { get; set; }

       [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
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
