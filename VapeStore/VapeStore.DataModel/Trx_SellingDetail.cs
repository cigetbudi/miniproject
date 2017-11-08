namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trx_SellingDetail
    {
        public Trx_SellingDetail()
        {
            Trs_SellingReturnDetail = new HashSet<Trs_SellingReturnDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int? SellingId { get; set; }

        [Required]
        [StringLength(5)]
        public string VarianCode { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal Total { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Mst_Varian Mst_Varian { get; set; }

        public virtual ICollection<Trs_SellingReturnDetail> Trs_SellingReturnDetail { get; set; }

        public virtual Trx_Selling Trx_Selling { get; set; }
    }
}
