namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trx_SellingReturn
    {
        public int Id { get; set; }

        public int SellingId { get; set; }

        public int CustomerId { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(5)]
        public string SalesReff { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Mst_Customer Mst_Customer { get; set; }

        public virtual Trx_Selling Trx_Selling { get; set; }
    }
}
