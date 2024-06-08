using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Newrest.ExportKeeper.Repositories;

public partial class RecruitementPlaformContext : DbContext
{
    public RecruitementPlaformContext()
    {
    }

    public RecruitementPlaformContext(DbContextOptions<RecruitementPlaformContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobAppliement> JobAppliements { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RecruitementPlaform;Data Source=DALI;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Blogs_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Blogs).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Documents_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Documents).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasIndex(e => e.PosterId, "IX_Jobs_PosterId");

            entity.HasOne(d => d.Poster).WithMany(p => p.Jobs).HasForeignKey(d => d.PosterId);
        });

        modelBuilder.Entity<JobAppliement>(entity =>
        {
            entity.HasIndex(e => e.DocumentId, "IX_JobAppliements_DocumentId");

            entity.HasIndex(e => e.JobId, "IX_JobAppliements_JobId");

            entity.HasIndex(e => e.UserId, "IX_JobAppliements_UserId");

            entity.HasOne(d => d.Document).WithMany(p => p.JobAppliements).HasForeignKey(d => d.DocumentId);

            entity.HasOne(d => d.Job).WithMany(p => p.JobAppliements).HasForeignKey(d => d.JobId);

            entity.HasOne(d => d.User).WithMany(p => p.JobAppliements)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_Users_roleId");

            entity.Property(e => e.RoleId).HasColumnName("roleId");

            entity.HasOne(d => d.Role).WithMany(p => p.Users).HasForeignKey(d => d.RoleId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
