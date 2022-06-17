using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using W2KMUXDAL.Data.Models;

#nullable disable

namespace W2KMUXDAL.Data
{
    public partial class W2KMUXContext : DbContext
    {
        public W2KMUXContext()
        {
        }

        public W2KMUXContext(DbContextOptions<W2KMUXContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ppv> Ppvs { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamHistory> TeamHistory { get; set; }
        public virtual DbSet<Superstar> Superstars { get; set; }
        public virtual DbSet<Championship> Championships { get; set; }
        public virtual DbSet<ChampionshipType> ChampionshipTypes { get; set; }

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //                optionsBuilder.UseSqlServer("Server=DESKTOP-ANLL8KM\\SQLEXPRESS;Database=W2KMUX;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Ppv>(entity =>
            {
                entity.ToTable("PPV");

                entity.Property(e => e.PPVId)
                    .HasColumnName("PPVId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PPVName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("PPVName");

                entity.Property(e => e.PPVOrder).HasColumnName("PPVOrder");

                entity.HasOne(d => d.Show)
                    .WithMany(p => p.Ppvs)
                    .HasForeignKey(d => d.ShowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PPV_PPV");
            });

            modelBuilder.Entity<Show>(entity =>
            {
                entity.ToTable("Show");

                entity.Property(e => e.ShowId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.ShowName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("Team");

                entity.Property(e => e.TeamId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.TeamName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TeamHistory>(entity =>
            {
                entity.ToTable("TeamHistory");

                entity.Property(e => e.TeamHistoryId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Superstar>(entity =>
            {
                entity.ToTable("Superstar");

                entity.Property(e => e.SuperstarId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.SuperstarName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Championship>(entity =>
            {
                entity.ToTable("Championship");
            });

            modelBuilder.Entity<ChampionshipType>(entity =>
            {
                entity.ToTable("ChampionshipType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
