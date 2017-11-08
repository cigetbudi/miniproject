using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeStore.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        
        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public string CategoryCode { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}
