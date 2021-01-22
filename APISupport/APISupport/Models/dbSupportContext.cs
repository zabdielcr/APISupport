using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APISupport.Models
{
    public partial class dbSupportContext : DbContext
    {
        public dbSupportContext()
        {
        }

        public dbSupportContext(DbContextOptions<dbSupportContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Issue> Issues { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Supervisor> Supervisors { get; set; }
        public virtual DbSet<Supporter> Supporters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-G315GBO;Initial Catalog=dbSupport;Trusted_Connection=Yes");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => e.ReportNumber);

                entity.ToTable("Issue");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.IdSupporter)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.ReportTimestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.ResolutionComment)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdSupporterNavigation)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.IdSupporter)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Issue_Supporter");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(e => e.IdNotes);

                entity.ToTable("Note");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NoteTimestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.IdIssueNavigation)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.IdIssue)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Note_Issue");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.ToTable("Service");

                entity.Property(e => e.IdSupporter).HasMaxLength(40);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.IdIssueNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.IdIssue)
                    .HasConstraintName("FK_Service_Issue");

                entity.HasOne(d => d.IdSupporterNavigation)
                    .WithMany(p => p.Services)
                    .HasForeignKey(d => d.IdSupporter)
                    .HasConstraintName("FK_Service_Supporter");
            });

            modelBuilder.Entity<Supervisor>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("Supervisor");

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.FirtsSurname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SecondSurname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Supporter>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("Supporter");

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.FirstSurname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.IdSupervisor)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SecondSurname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdSupervisorNavigation)
                    .WithMany(p => p.Supporters)
                    .HasForeignKey(d => d.IdSupervisor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supporter_Supervisor");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
