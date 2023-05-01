﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ThreeLayerArchitecture.ASP.Net.DAL;

public partial class MvcfirstContext : DbContext
{
    public MvcfirstContext()
    {
    }

    public MvcfirstContext(DbContextOptions<MvcfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; database=MVCFirst; Trusted_Connection=true; TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genders__3214EC07C11154FD");

            entity.Property(e => e.TExt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("tEXT");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07C12410A2");

            entity.Property(e => e.AdharNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK__Users__GenderId__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
