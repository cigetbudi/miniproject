namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mst_Supplier
    {
        public Mst_Supplier()
        {
            Trx_Purchasing = new HashSet<Trx_Purchasing>();
            Trx_PurchasingReturn = new HashSet<Trx_PurchasingReturn>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(5)]
        public string SupplierCode { get; set; }

        [Required]
        [StringLength(30)]
        public string SupplierName { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<Trx_Purchasing> Trx_Purchasing { get; set; }

        public virtual ICollection<Trx_PurchasingReturn> Trx_PurchasingReturn { get; set; }
    }
}
