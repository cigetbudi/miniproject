namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trx_PurchasingReturn
    {
        public Trx_PurchasingReturn()
        {
            Trx_PurchasingReturnDetail = new HashSet<Trx_PurchasingReturnDetail>();
        }

        public int Id { get; set; }

        public int PurchasingId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Tanggal { get; set; }

        [Required]
        [StringLength(5)]
        public string NoResiBeli { get; set; }

        [Required]
        [StringLength(5)]
        public string SupplierCode { get; set; }

        [Required]
        [StringLength(50)]
        public string Keterangan { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Mst_Supplier Mst_Supplier { get; set; }

        public virtual Trx_Purchasing Trx_Purchasing { get; set; }

        public virtual ICollection<Trx_PurchasingReturnDetail> Trx_PurchasingReturnDetail { get; set; }
    }
}
