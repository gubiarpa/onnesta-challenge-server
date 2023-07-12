using Microsoft.EntityFrameworkCore;

namespace gubiarpa.onnesta.api.Models.Context
{
    public partial class JobSeekerContext : DbContext
    {
        public JobSeekerContext()
        {
        }

        public JobSeekerContext(DbContextOptions<JobSeekerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Applicant> Applicants { get; set; } = null!;
        public virtual DbSet<Applying> Applyings { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Employer> Employers { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobType> JobTypes { get; set; } = null!;
        public virtual DbSet<Keyword> Keywords { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<WorkplaceType> WorkplaceTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=JobSeeker;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.HasKey(e => e.Idapplicant);

                entity.ToTable("Applicant");

                entity.Property(e => e.Idapplicant)
                    .HasColumnName("IDApplicant")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.DocumentNumber).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.FullName).HasMaxLength(500);

                entity.Property(e => e.IddocumentType).HasColumnName("IDDocumentType");

                entity.HasOne(d => d.IddocumentTypeNavigation)
                    .WithMany(p => p.Applicants)
                    .HasForeignKey(d => d.IddocumentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applicant_DocumentType");
            });

            modelBuilder.Entity<Applying>(entity =>
            {
                entity.HasKey(e => e.Idapplying);

                entity.ToTable("Applying");

                entity.Property(e => e.Idapplying)
                    .HasColumnName("IDApplying")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idapplicant).HasColumnName("IDApplicant");

                entity.Property(e => e.Idjob).HasColumnName("IDJob");

                entity.HasOne(d => d.IdapplicantNavigation)
                    .WithMany(p => p.Applyings)
                    .HasForeignKey(d => d.Idapplicant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applying_Applicant");

                entity.HasOne(d => d.IdjobNavigation)
                    .WithMany(p => p.Applyings)
                    .HasForeignKey(d => d.Idjob)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Applying_Job");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.IddocumentType);

                entity.ToTable("DocumentType");

                entity.Property(e => e.IddocumentType)
                    .HasColumnName("IDDocumentType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.HasKey(e => e.Idemployer);

                entity.ToTable("Employer");

                entity.Property(e => e.Idemployer)
                    .HasColumnName("IDEmployer")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Ruc)
                    .HasMaxLength(11)
                    .HasColumnName("RUC")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasKey(e => e.Idjob)
                    .HasName("PK_Oferta");

                entity.ToTable("Job");

                entity.Property(e => e.Idjob)
                    .HasColumnName("IDJob")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Idemployer).HasColumnName("IDEmployer");

                entity.Property(e => e.IdjobType).HasColumnName("IDJobType");

                entity.Property(e => e.Idstatus).HasColumnName("IDStatus");

                entity.Property(e => e.IdworkplaceType).HasColumnName("IDWorkplaceType");

                entity.Property(e => e.JobTitle).HasMaxLength(150);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.HasOne(d => d.IdemployerNavigation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.Idemployer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Employer");

                entity.HasOne(d => d.IdjobTypeNavigation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.IdjobType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_JobType");

                entity.HasOne(d => d.IdstatusNavigation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.Idstatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Status");

                entity.HasOne(d => d.IdworkplaceTypeNavigation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.IdworkplaceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_WorkplaceType");

                entity.HasMany(d => d.Idkeywords)
                    .WithMany(p => p.Idjobs)
                    .UsingEntity<Dictionary<string, object>>(
                        "JobKeyword",
                        l => l.HasOne<Keyword>().WithMany().HasForeignKey("Idkeyword").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_JobKeyword_Keyword"),
                        r => r.HasOne<Job>().WithMany().HasForeignKey("Idjob").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_JobKeyword_Job"),
                        j =>
                        {
                            j.HasKey("Idjob", "Idkeyword").HasName("PK_JobKeyword_1");

                            j.ToTable("JobKeyword");

                            j.IndexerProperty<Guid>("Idjob").HasColumnName("IDJob");

                            j.IndexerProperty<Guid>("Idkeyword").HasColumnName("IDKeyword");
                        });
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.HasKey(e => e.IdjobType);

                entity.ToTable("JobType");

                entity.Property(e => e.IdjobType)
                    .HasColumnName("IDJobType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.HasKey(e => e.Idkeyword)
                    .HasName("PK_JobKeyword");

                entity.ToTable("Keyword");

                entity.Property(e => e.Idkeyword)
                    .HasColumnName("IDKeyword")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.HasKey(e => e.Idstatus);

                entity.ToTable("Status");

                entity.Property(e => e.Idstatus)
                    .HasColumnName("IDStatus")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            modelBuilder.Entity<WorkplaceType>(entity =>
            {
                entity.HasKey(e => e.IdworkplaceType);

                entity.ToTable("WorkplaceType");

                entity.Property(e => e.IdworkplaceType)
                    .HasColumnName("IDWorkplaceType")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
