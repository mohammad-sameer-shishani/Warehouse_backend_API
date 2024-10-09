using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Supplydocument> Supplydocuments { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Warehouse> Warehouses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##Warehouse;PASSWORD=Test321;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##WAREHOUSE")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("ITEMS");

                entity.Property(e => e.Itemid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ITEMID");

                entity.Property(e => e.Itemdescription)
                    .HasColumnType("CLOB")
                    .HasColumnName("ITEMDESCRIPTION");

                entity.Property(e => e.Itemname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ITEMNAME");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.Property(e => e.Warehouseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WAREHOUSEID");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.Warehouseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WAREHOUSE");
            });

            modelBuilder.Entity<Supplydocument>(entity =>
            {
                entity.HasKey(e => e.Documentid)
                    .HasName("SYS_C009017");

                entity.ToTable("SUPPLYDOCUMENTS");

                entity.Property(e => e.Documentid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DOCUMENTID");

                entity.Property(e => e.Createdby)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CREATEDBY");

                entity.Property(e => e.Createddate)
                    .HasPrecision(6)
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Documentname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTNAME");

                entity.Property(e => e.Documentsubject)
                    .HasColumnType("CLOB")
                    .HasColumnName("DOCUMENTSUBJECT");

                entity.Property(e => e.Itemid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ITEMID");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("'Pending' ");

                entity.Property(e => e.Warehouseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("WAREHOUSEID");

                entity.HasOne(d => d.CreatedbyNavigation)
                    .WithMany(p => p.Supplydocuments)
                    .HasForeignKey(d => d.Createdby)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATEDBY_SD");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Supplydocuments)
                    .HasForeignKey(d => d.Itemid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ITEM_SD");

                entity.HasOne(d => d.Warehouse)
                    .WithMany(p => p.Supplydocuments)
                    .HasForeignKey(d => d.Warehouseid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WAREHOUSE_SD");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasIndex(e => e.Username, "SYS_C008999")
                    .IsUnique();

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.Property(e => e.Createddate)
                    .HasPrecision(6)
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Passwordhashed)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORDHASHED");

                entity.Property(e => e.Username)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.Property(e => e.Usertype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERTYPE");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("WAREHOUSES");

                entity.HasIndex(e => e.Warehousename, "WAREHOUSES_UK1")
                    .IsUnique();

                entity.Property(e => e.Warehouseid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("WAREHOUSEID");

                entity.Property(e => e.Createdby)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CREATEDBY");

                entity.Property(e => e.Createddate)
                    .HasPrecision(6)
                    .HasColumnName("CREATEDDATE")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Warehousedescription)
                    .HasColumnType("CLOB")
                    .HasColumnName("WAREHOUSEDESCRIPTION");

                entity.Property(e => e.Warehousename)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("WAREHOUSENAME");

                entity.HasOne(d => d.CreatedbyNavigation)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.Createdby)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREATEDBY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
