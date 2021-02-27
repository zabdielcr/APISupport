using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Models
{
    public partial class SupportContext : DbContext
    {
        public SupportContext()
        {
        }

        public SupportContext(DbContextOptions<SupportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceSupport> ServiceSupports { get; set; }
        public virtual DbSet<Supporter> Supporters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G315GBO;Initial Catalog=Support;Trusted_Connection=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.HasKey(e => new { e.IdIssue, e.IdSupporter });

                entity.Property(e => e.IdIssue).HasColumnName("idIssue");

                entity.Property(e => e.IdSupporter).HasColumnName("idSupporter");

                entity.HasOne(d => d.IdIssueNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdIssue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignments_Issue");

                entity.HasOne(d => d.IdSupporterNavigation)
                    .WithMany(p => p.Assignments)
                    .HasForeignKey(d => d.IdSupporter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Assignments_Supporter");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("firstName");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("phone");

                entity.Property(e => e.SecondContact)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("secondContact");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("secondName");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportNumber);

                entity.ToTable("Issue");

                entity.Property(e => e.ReportNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("reportNumber");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("classification");

                entity.Property(e => e.IdClient).HasColumnName("idClient");

                entity.Property(e => e.ReportTimestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("reportTimestamp");

                entity.Property(e => e.ResolutionComment)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("resolutionComment");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("status");

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issue_Client");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ServiceSupport>(entity =>
            {
                entity.HasKey(e => new { e.IdSupport, e.IdService });

                entity.ToTable("ServiceSupport");

                entity.Property(e => e.IdSupport).HasColumnName("idSupport");

                entity.Property(e => e.IdService).HasColumnName("idService");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.ServiceSupports)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceSupport_Service");

                entity.HasOne(d => d.IdSupportNavigation)
                    .WithMany(p => p.ServiceSupports)
                    .HasForeignKey(d => d.IdSupport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceSupport_Supporter");
            });

            modelBuilder.Entity<Supporter>(entity =>
            {
                entity.ToTable("Supporter");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("firstName");

                entity.Property(e => e.IdRole).HasColumnName("idRole");

                entity.Property(e => e.IdService).HasColumnName("idService");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("password");

                entity.Property(e => e.SecondName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("secondName");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Supporters)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supporter_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
