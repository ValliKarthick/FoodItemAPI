using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api___Scaffolded.Models
{
    public partial class BookShelfDbContext : DbContext
    {
        public BookShelfDbContext()
        {
        }

        public BookShelfDbContext(DbContextOptions<BookShelfDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookDetail> BookDetails { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-GIVRBI76\\SQLEXPRESS;Database=BookShelfDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDetail>(entity =>
            {
                entity.HasKey(e => e.BookNumber)
                    .HasName("PK_Book.Book Details");

                entity.ToTable("Book Details", "Book");

                entity.Property(e => e.BookNumber).ValueGeneratedNever();

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(25)
                    .HasColumnName("Author Name");

                entity.Property(e => e.BookName).HasColumnName("Book Name");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_Book.__MigrationHistory");

                entity.ToTable("__MigrationHistory", "Book");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
