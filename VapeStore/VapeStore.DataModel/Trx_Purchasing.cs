namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trx_Purchasing
    {
        public Trx_Purchasing()
        {
            Trx_PurchasingReturn = new HashSet<Trx_PurchasingReturn>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(5)]
        public string PurchReff { get; set; }

        [Required]
        [StringLength(5)]
        public string SupplierCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Mst_Supplier Mst_Supplier { get; set; }

        public virtual ICollection<Trx_PurchasingReturn> Trx_PurchasingReturn { get; set; }
    }
}
