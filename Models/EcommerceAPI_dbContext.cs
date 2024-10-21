using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EcommerceAPI.Models
{
    public partial class EcommerceAPI_dbContext : DbContext
    {
        public EcommerceAPI_dbContext()
        {
        }

        public EcommerceAPI_dbContext(DbContextOptions<EcommerceAPI_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; } = null!;
        public virtual DbSet<Order> Order { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("RP9l1vntZPKNJ4ny1zh4Tyc0MwH/R4mfbRTIGt5qYsXeyscYK9MZlkJQuubGC2ienL5E+XW03b/8u7bZ+3dHOXZmppWQHZFVF5w2M3M3jyWRChL48S6vwd0w0h11Wyk3cnv7wrNjNJwB4YaQ0mzJaY/6cmTREijPdqOvukuSaJcTmy9+JvzWfitMxnd7jbyY8DXC/tQrpESOU+Sgpi10k9rD6yqE9nk8uiFhpgPgLCk58qP1kLt2x69yYC8z9Depn4exQeEJQtBAoFDwue+lqosv9242x5ObJyiJBoZOespadjkqvDgfQ2SaTn0FPCtXbAZVoYMXklb5Y+RpHFPQgHq9mkaoYpai40m9Bls847EFhlE6GC5wFyO16bQk4P9AA0gxwZ+iTw5VEr2n3E29Ugt2xEU4DL/+iUH1FehX2rY=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<EcommerceAPI.Models.Product>? Product { get; set; }

        public DbSet<EcommerceAPI.Models.Category>? Category { get; set; }

        public DbSet<EcommerceAPI.Models.User>? User { get; set; }
    }
}
