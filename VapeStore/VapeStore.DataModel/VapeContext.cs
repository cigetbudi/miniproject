namespace VapeStore.DataModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class VapeContext : DbContext
    {
        public VapeContext()
            : base("name=VapeContext")
        {
        }

        public virtual DbSet<Mst_Category> Mst_Category { get; set; }
        public virtual DbSet<Mst_Customer> Mst_Customer { get; set; }
        public virtual DbSet<Mst_Item> Mst_Item { get; set; }
        public virtual DbSet<Mst_Supplier> Mst_Supplier { get; set; }
        public virtual DbSet<Mst_Varian> Mst_Varian { get; set; }
        public virtual DbSet<Trs_SellingReturnDetail> Trs_SellingReturnDetail { get; set; }
        public virtual DbSet<Trx_Purchasing> Trx_Purchasing { get; set; }
        public virtual DbSet<Trx_PurchasingDetail> Trx_PurchasingDetail { get; set; }
        public virtual DbSet<Trx_PurchasingReturn> Trx_PurchasingReturn { get; set; }
        public virtual DbSet<Trx_PurchasingReturnDetail> Trx_PurchasingReturnDetail { get; set; }
        public virtual DbSet<Trx_Selling> Trx_Selling { get; set; }
        public virtual DbSet<Trx_SellingDetail> Trx_SellingDetail { get; set; }
        public virtual DbSet<Trx_SellingReturn> Trx_SellingReturn { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mst_Category>()
                .Property(e => e.CategoryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Category>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Category>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Category>()
                .HasMany(e => e.Mst_Item)
                .WithRequired(e => e.Mst_Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Customer>()
                .Property(e => e.CostumerName)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Customer>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Customer>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Customer>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Customer>()
                .HasMany(e => e.Trx_Selling)
                .WithRequired(e => e.Mst_Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Customer>()
                .HasMany(e => e.Trx_SellingReturn)
                .WithRequired(e => e.Mst_Customer)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Item>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Item>()
                .Property(e => e.ItemName)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Item>()
                .Property(e => e.CategoryCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Item>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Item>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Item>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Item>()
                .HasMany(e => e.Mst_Varian)
                .WithRequired(e => e.Mst_Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Supplier>()
                .Property(e => e.SupplierCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Supplier>()
                .Property(e => e.SupplierName)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Supplier>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Supplier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Supplier>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Supplier>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Supplier>()
                .HasMany(e => e.Trx_Purchasing)
                .WithRequired(e => e.Mst_Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Supplier>()
                .HasMany(e => e.Trx_PurchasingReturn)
                .WithRequired(e => e.Mst_Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.VarianCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.VarianName)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.Strength)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.PGVG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.Size)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mst_Varian>()
                .HasMany(e => e.Trs_SellingReturnDetail)
                .WithRequired(e => e.Mst_Varian)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Varian>()
                .HasMany(e => e.Trx_PurchasingDetail)
                .WithRequired(e => e.Mst_Varian)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Varian>()
                .HasMany(e => e.Trx_PurchasingReturnDetail)
                .WithRequired(e => e.Mst_Varian)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mst_Varian>()
                .HasMany(e => e.Trx_SellingDetail)
                .WithRequired(e => e.Mst_Varian)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trs_SellingReturnDetail>()
                .Property(e => e.VarianCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Trs_SellingReturnDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trs_SellingReturnDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Trs_SellingReturnDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trs_SellingReturnDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trs_SellingReturnDetail>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Purchasing>()
                .Property(e => e.PurchReff)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Purchasing>()
                .Property(e => e.SupplierCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Purchasing>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Purchasing>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Purchasing>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Purchasing>()
                .HasMany(e => e.Trx_PurchasingReturn)
                .WithRequired(e => e.Trx_Purchasing)
                .HasForeignKey(e => e.PurchasingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trx_PurchasingDetail>()
                .Property(e => e.VarianCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trx_PurchasingDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Trx_PurchasingDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trx_PurchasingDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingDetail>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturn>()
                .Property(e => e.NoResiBeli)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturn>()
                .Property(e => e.SupplierCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturn>()
                .Property(e => e.Keterangan)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturn>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturn>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturn>()
                .HasMany(e => e.Trx_PurchasingReturnDetail)
                .WithRequired(e => e.Trx_PurchasingReturn)
                .HasForeignKey(e => e.PurchasingReturnId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trx_PurchasingReturnDetail>()
                .Property(e => e.VarianCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturnDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trx_PurchasingReturnDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Trx_PurchasingReturnDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trx_PurchasingReturnDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_PurchasingReturnDetail>()
                .Property(e => e.Modified)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Selling>()
                .Property(e => e.SalesReff)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Selling>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Selling>()
                .Property(e => e.MoneyPaid)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trx_Selling>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Selling>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_Selling>()
                .HasMany(e => e.Trx_SellingDetail)
                .WithOptional(e => e.Trx_Selling)
                .HasForeignKey(e => e.SellingId);

            modelBuilder.Entity<Trx_Selling>()
                .HasMany(e => e.Trx_SellingReturn)
                .WithRequired(e => e.Trx_Selling)
                .HasForeignKey(e => e.SellingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trx_SellingDetail>()
                .Property(e => e.VarianCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Trx_SellingDetail>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trx_SellingDetail>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Trx_SellingDetail>()
                .Property(e => e.Total)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Trx_SellingDetail>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_SellingDetail>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_SellingDetail>()
                .HasMany(e => e.Trs_SellingReturnDetail)
                .WithRequired(e => e.Trx_SellingDetail)
                .HasForeignKey(e => e.SellingDetailId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Trx_SellingReturn>()
                .Property(e => e.SalesReff)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_SellingReturn>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_SellingReturn>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Trx_SellingReturn>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);
        }
    }
}
