using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeStore.ViewModel
{
    public class ItemViewModel
    {
        public int Id { get; set; }

       [DisplayName("Item Code")]
        public string ItemCode { get; set; }

        [DisplayName("Item Name")]
        public string ItemName { get; set; }

        [DisplayName("Category Name")]
        public string CategoryCode { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }

        [DisplayName("Status")]
        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}
