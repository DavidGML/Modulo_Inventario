using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WS_TexasSales.Models
{
    public partial class texas_salesdbContext : DbContext
    {
        public texas_salesdbContext()
        {
        }

        public texas_salesdbContext(DbContextOptions<texas_salesdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarList> CarList { get; set; }
        public virtual DbSet<CarStok> CarStok { get; set; }
        public virtual DbSet<Trademark> Trademark { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=texas_salesdb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarList>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__car_list__4C9A0DB37F77EA84");

                entity.ToTable("car_list");

                entity.Property(e => e.CarId).HasColumnName("car_id");

                entity.Property(e => e.CarColor)
                    .IsRequired()
                    .HasColumnName("car_color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarDoors).HasColumnName("car_doors");

                entity.Property(e => e.CarHpMotor).HasColumnName("car_hp_motor");

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasColumnName("car_model")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CarTmId).HasColumnName("car_tm_id");

                entity.Property(e => e.CarYear).HasColumnName("car_year");

                entity.HasOne(d => d.CarTm)
                    .WithMany(p => p.CarList)
                    .HasForeignKey(d => d.CarTmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__car_list__car_tm__3C69FB99");
            });

            modelBuilder.Entity<CarStok>(entity =>
            {
                entity.HasKey(e => e.CsId)
                    .HasName("PK__car_stok__138C55F419B0524A");

                entity.ToTable("car_stok");

                entity.Property(e => e.CsId).HasColumnName("cs_id");

                entity.Property(e => e.CsCarId).HasColumnName("cs_car_id");

                entity.Property(e => e.CsInitPrice)
                    .HasColumnName("cs_init_price")
                    .HasColumnType("money");

                entity.HasOne(d => d.CsCar)
                    .WithMany(p => p.CarStok)
                    .HasForeignKey(d => d.CsCarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__car_stok__cs_car__3F466844");
            });

            modelBuilder.Entity<Trademark>(entity =>
            {
                entity.HasKey(e => e.TmId)
                    .HasName("PK__trademar__BED4B67D8EF424E7");

                entity.ToTable("trademark");

                entity.Property(e => e.TmId).HasColumnName("tm_id");

                entity.Property(e => e.TmName)
                    .IsRequired()
                    .HasColumnName("tm_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
