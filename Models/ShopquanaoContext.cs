using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebThoiTrang.Models;

public partial class ShopquanaoContext : DbContext
{
    public ShopquanaoContext()
    {
    }

    public ShopquanaoContext(DbContextOptions<ShopquanaoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=Dkvpr\\SQLEXPRESS;initial catalog=shopquanao;integrated security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A69816F392");

            entity.ToTable("Account");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LastLogin).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__RoleId__2B3F6F97");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blogs__54379E308A2BBB59");

            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Descriptions).HasMaxLength(250);
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.SeoDescription).HasMaxLength(500);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Blogs__AccountId__2E1BDC42");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Contact__5C66259B7D1AF1FE");

            entity.ToTable("Contact");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Message).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8D30D02E8");

            entity.Property(e => e.Avatar).HasMaxLength(50);
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED230A1657AC9");

            entity.ToTable("Menu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCFDC2F0FBF");

            entity.Property(e => e.Code).HasMaxLength(15);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .HasConstraintName("FK__Orders__OrderSta__38996AB5");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36C15FC9B32");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Quant__3B75D760");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__3C69FB99");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("PK__OrderSta__BC674CA147B5B030");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDA2DC321B");

            entity.Property(e => e.Alias).HasMaxLength(250);
            entity.Property(e => e.Color).HasMaxLength(250);
            entity.Property(e => e.CreatedBy).HasMaxLength(250);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Detail).HasMaxLength(250);
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.ModifiedBy).HasMaxLength(250);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Size).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);

            entity.HasOne(d => d.CategoryProduct).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryProductId)
                .HasConstraintName("FK__Products__Catego__267ABA7A");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryProductId).HasName("PK__ProductC__FAFA184F5C74A8E9");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Modified).HasColumnType("datetime");
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1ABEDCD1DE");

            entity.ToTable("Role");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
