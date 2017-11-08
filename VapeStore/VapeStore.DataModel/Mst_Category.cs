namespace VapeStore.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mst_Category
    {
        public Mst_Category()
        {
            Mst_Item = new HashSet<Mst_Item>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(5)]
        public string CategoryCode { get; set; }

        [Required]
        [StringLength(30)]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public virtual ICollection<Mst_Item> Mst_Item { get; set; }
    }
}
