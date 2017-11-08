namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mst_Customer
    {
        public Mst_Customer()
        {
            Trx_Selling = new HashSet<Trx_Selling>();
            Trx_SellingReturn = new HashSet<Trx_SellingReturn>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CostumerName { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<Trx_Selling> Trx_Selling { get; set; }

        public virtual ICollection<Trx_SellingReturn> Trx_SellingReturn { get; set; }
    }
}
