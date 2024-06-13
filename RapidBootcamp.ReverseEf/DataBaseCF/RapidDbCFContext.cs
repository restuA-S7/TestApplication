﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace RapidBootcamp.ReverseEf.DataBaseCF;

public partial class RapidDbCFContext : DbContext
{
    //public RapidDbCFContext(DbContextOptions<RapidDbCFContext> options)
    //    : base(options)
    //{
    //}

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderHeader> OrderHeaders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.Address).IsRequired();
            entity.Property(e => e.City).IsRequired();
            entity.Property(e => e.CustomerName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.PhoneNumber).IsRequired();
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasIndex(e => e.OrderHeaderId, "IX_OrderDetails_OrderHeaderId");

            entity.HasIndex(e => e.ProductId, "IX_OrderDetails_ProductId");

            entity.Property(e => e.OrderHeaderId).IsRequired();
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OrderHeader).WithMany(p => p.OrderDetails).HasForeignKey(d => d.OrderHeaderId);

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails).HasForeignKey(d => d.ProductId);
        });

        modelBuilder.Entity<OrderHeader>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_OrderHeaders_CustomerId");

            entity.HasOne(d => d.Customer).WithMany(p => p.OrderHeaders).HasForeignKey(d => d.CustomerId);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName).IsRequired();

            entity.HasOne(d => d.Category).WithMany(p => p.Products).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);


    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.\\;Database=RapidCodeFirstDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}