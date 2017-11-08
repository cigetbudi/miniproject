﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VapeStore.ViewModel
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        public string SupplierCode { get; set; }


        public string SupplierName { get; set; }

        public string Address { get; set; }


        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        public string ModifiedBy { get; set; }
    }
}