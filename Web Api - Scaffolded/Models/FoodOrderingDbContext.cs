using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api___Scaffolded.Models
{
    public partial class FoodOrderingDbContext : DbContext
    {
        public FoodOrderingDbContext()
        {
        }

        public FoodOrderingDbContext(DbContextOptions<FoodOrderingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoodItemDetail> FoodItemDetails { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-GIVRBI76\\SQLEXPRESS;Database=FoodOrderingDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodItemDetail>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CostPerItem).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Cuisine)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FoodId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HomeDelivery)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TotalCost).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Food)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.FoodId)
                    .HasConstraintName("FK__OrderDeta__FoodI__20C1E124");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
