namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Trx_Selling
    {
        public Trx_Selling()
        {
            Trx_SellingDetail = new HashSet<Trx_SellingDetail>();
            Trx_SellingReturn = new HashSet<Trx_SellingReturn>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(5)]
        public string SalesReff { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal MoneyPaid { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Mst_Customer Mst_Customer { get; set; }

        public virtual ICollection<Trx_SellingDetail> Trx_SellingDetail { get; set; }

        public virtual ICollection<Trx_SellingReturn> Trx_SellingReturn { get; set; }
    }
}
