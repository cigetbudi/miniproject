namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mst_Varian
    {
        public Mst_Varian()
        {
            Trs_SellingReturnDetail = new HashSet<Trs_SellingReturnDetail>();
            Trx_PurchasingDetail = new HashSet<Trx_PurchasingDetail>();
            Trx_PurchasingReturnDetail = new HashSet<Trx_PurchasingReturnDetail>();
            Trx_SellingDetail = new HashSet<Trx_SellingDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(5)]
        public string VarianCode { get; set; }

        [Required]
        [StringLength(30)]
        public string VarianName { get; set; }

        [Required]
        [StringLength(5)]
        public string ItemCode { get; set; }

        [StringLength(30)]
        public string Country { get; set; }

        [StringLength(2)]
        public string Strength { get; set; }

        [StringLength(50)]
        public string PGVG { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Mst_Item Mst_Item { get; set; }

        public virtual ICollection<Trs_SellingReturnDetail> Trs_SellingReturnDetail { get; set; }

        public virtual ICollection<Trx_PurchasingDetail> Trx_PurchasingDetail { get; set; }

        public virtual ICollection<Trx_PurchasingReturnDetail> Trx_PurchasingReturnDetail { get; set; }

        public virtual ICollection<Trx_SellingDetail> Trx_SellingDetail { get; set; }
    }
}
