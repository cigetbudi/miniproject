using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeStore.ViewModel
{
    public class VarianViewModel
    {
        public int Id { get; set; }

        public string VarianCode { get; set; }

        public string VarianName { get; set; }

        public string CategoryCode { get; set; }

        public string ItemCode { get; set; }

        public string ItemName { get; set; }

        public string Country { get; set; }

        public string Strength { get; set; }

        public string PGVG { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }

        public string Unit { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}
