namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mst_Item
    {
        public Mst_Item()
        {
            Mst_Varian = new HashSet<Mst_Varian>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(5)]
        public string ItemCode { get; set; }

        [Required]
        [StringLength(30)]
        public string ItemName { get; set; }

        [Required]
        [StringLength(5)]
        public string CategoryCode { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int Stock { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual Mst_Category Mst_Category { get; set; }

        public virtual ICollection<Mst_Varian> Mst_Varian { get; set; }
    }
}
