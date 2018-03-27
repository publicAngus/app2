using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace app2.DB.Models
{
    public partial class jumpmanjiContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersItems> UsersItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=beetles;Password=abc123!;Database=jumpmanji;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.IntVal).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UsersItems>(entity =>
            {
                entity.ToTable("usersItems");

                entity.Property(e => e.Id).HasColumnType("bigint(20)");

                entity.Property(e => e.ItemName).HasMaxLength(100);

                entity.Property(e => e.Userid).HasColumnType("bigint(20)");
            });
        }
    }
}
