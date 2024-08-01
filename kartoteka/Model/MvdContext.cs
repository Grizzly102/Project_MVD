using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kartoteka.Model;

public partial class MvdContext : DbContext
{
    public MvdContext()
    {
    }

    public MvdContext(DbContextOptions<MvdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<Criminal> Criminals { get; set; }

    public virtual DbSet<CriminaleInCase> CriminaleInCases { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employer> Employers { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseLazyLoadingProxies().UseMySql("server=localhost;user=root;password=qwerty;database=mvd;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.ArticleId).HasName("PRIMARY");

            entity.ToTable("article");

            entity.Property(e => e.ArticleId)
                .ValueGeneratedNever()
                .HasColumnName("Article_Id");
            entity.Property(e => e.ArticleDescription)
                .HasMaxLength(250)
                .HasColumnName("Article_Description");
        });

        modelBuilder.Entity<Case>(entity =>
        {
            entity.HasKey(e => e.CaseId).HasName("PRIMARY");

            entity.ToTable("case");

            entity.HasIndex(e => e.CaseConduct, "Employer_idx");

            entity.Property(e => e.CaseId)
                .ValueGeneratedNever()
                .HasColumnName("Case_Id");
            entity.Property(e => e.CaseConduct).HasColumnName("Case_Conduct");
            entity.Property(e => e.CaseOpeningDate).HasColumnName("Case_Opening_Date");
            entity.Property(e => e.CrimeArticle).HasColumnName("Crime_Article");
            entity.Property(e => e.CrimeDate).HasColumnName("Crime_Date");
            entity.Property(e => e.CrimeScence)
                .HasMaxLength(45)
                .HasColumnName("Crime_Scence");
            entity.Property(e => e.CrimeWeight)
                .HasMaxLength(45)
                .HasColumnName("Crime_Weight");
            entity.Property(e => e.Discription)
                .HasMaxLength(100)
                .HasColumnName("DIscription");

            entity.HasOne(d => d.CaseConductNavigation).WithMany(p => p.Cases)
                .HasForeignKey(d => d.CaseConduct)
                .HasConstraintName("Employer");
        });

        modelBuilder.Entity<Criminal>(entity =>
        {
            entity.HasKey(e => e.PassportNuberSerias).HasName("PRIMARY");

            entity.ToTable("criminal");

            entity.Property(e => e.PassportNuberSerias)
                .ValueGeneratedNever()
                .HasColumnName("Passport_Nuber_Serias");
            entity.Property(e => e.BirthDate).HasColumnName("Birth_Date");
            entity.Property(e => e.BirthPlace)
                .HasMaxLength(45)
                .HasColumnName("Birth_Place");
            entity.Property(e => e.CriminalName)
                .HasMaxLength(100)
                .HasColumnName("Criminal_Name");
            entity.Property(e => e.EyeColor)
                .HasMaxLength(45)
                .HasColumnName("Eye_Color");
            entity.Property(e => e.HairColor)
                .HasMaxLength(45)
                .HasColumnName("Hair_Color");
            entity.Property(e => e.LastResidencePlace)
                .HasMaxLength(45)
                .HasColumnName("Last_Residence_Place");
            entity.Property(e => e.Photo).HasMaxLength(45);
            entity.Property(e => e.SpecialSigns)
                .HasMaxLength(150)
                .HasColumnName("Special_Signs");
        });

        modelBuilder.Entity<CriminaleInCase>(entity =>
        {
            entity.HasKey(e => e.CiCNumber).HasName("PRIMARY");

            entity.ToTable("criminale_in_case");

            entity.HasIndex(e => e.CaseId, "Case_idx");

            entity.HasIndex(e => e.PassportNuberSerias, "Num_idx");

            entity.Property(e => e.CiCNumber)
                .ValueGeneratedNever()
                .HasColumnName("CiC_Number");
            entity.Property(e => e.CaseId).HasColumnName("Case_Id");
            entity.Property(e => e.CaseStatus)
                .HasMaxLength(45)
                .HasColumnName("Case_Status");
            entity.Property(e => e.PassportNuberSerias).HasColumnName("Passport_Nuber_Serias");

            entity.HasOne(d => d.Case).WithMany(p => p.CriminaleInCases)
                .HasForeignKey(d => d.CaseId)
                .HasConstraintName("Case");

            entity.HasOne(d => d.PassportNuberSeriasNavigation).WithMany(p => p.CriminaleInCases)
                .HasForeignKey(d => d.PassportNuberSerias)
                .HasConstraintName("Pass");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("Department_Id");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(45)
                .HasColumnName("Department_Name");
        });

        modelBuilder.Entity<Employer>(entity =>
        {
            entity.HasKey(e => e.TokenNumber).HasName("PRIMARY");

            entity.ToTable("employer");

            entity.HasIndex(e => e.DepartmentNumber, "Dep_idx");

            entity.HasIndex(e => e.TitleNumber, "Title_idx");

            entity.Property(e => e.TokenNumber)
                .ValueGeneratedNever()
                .HasColumnName("Token_Number");
            entity.Property(e => e.DepartmentNumber).HasColumnName("Department_Number");
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(100)
                .HasColumnName("Employee_Name");
            entity.Property(e => e.Login).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
            entity.Property(e => e.PolicePhoto)
                .HasMaxLength(45)
                .HasColumnName("Police_Photo");
            entity.Property(e => e.TitleNumber).HasColumnName("Title_Number");

            entity.HasOne(d => d.DepartmentNumberNavigation).WithMany(p => p.Employers)
                .HasForeignKey(d => d.DepartmentNumber)
                .HasConstraintName("Dep");

            entity.HasOne(d => d.TitleNumberNavigation).WithMany(p => p.Employers)
                .HasForeignKey(d => d.TitleNumber)
                .HasConstraintName("Title");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("PRIMARY");

            entity.ToTable("title");

            entity.Property(e => e.TitleId)
                .ValueGeneratedNever()
                .HasColumnName("Title_Id");
            entity.Property(e => e.TitleName)
                .HasMaxLength(45)
                .HasColumnName("Title_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
