using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SaleInvoiceMasterDetail.Models
{
    public partial class TestInvoiceDBContext : DbContext
    {
        public TestInvoiceDBContext()
        {
        }

        public TestInvoiceDBContext(DbContextOptions<TestInvoiceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SaleInvoiceDetail> SaleInvoiceDetails { get; set; }
        public virtual DbSet<SaleInvoiceMaster> SaleInvoiceMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ODL8MOH;Database=TestInvoiceDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

            modelBuilder.Entity<SaleInvoiceDetail>(entity =>
            {
                entity.HasKey(e => e.InvDetailId)
                    .HasName("PK__SaleInvo__DF27B471A39818B5");

                entity.ToTable("SaleInvoiceDetail");

                entity.Property(e => e.InvDetailId).HasColumnName("invDetailID");

                entity.Property(e => e.InvId).HasColumnName("invID");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("itemName");

                entity.Property(e => e.ItemQty).HasColumnName("itemQty");

                entity.HasOne(d => d.Inv)
                    .WithMany(p => p.SaleInvoiceDetails)
                    .HasForeignKey(d => d.InvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SaleInvoi__invID__267ABA7A");
            });

            modelBuilder.Entity<SaleInvoiceMaster>(entity =>
            {
                entity.HasKey(e => e.InvId)
                    .HasName("PK__SaleInvo__10325520190617ED");

                entity.ToTable("SaleInvoiceMaster");

                entity.Property(e => e.InvId).HasColumnName("invID");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customerName");

                entity.Property(e => e.InvDate)
                    .HasColumnType("date")
                    .HasColumnName("invDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
