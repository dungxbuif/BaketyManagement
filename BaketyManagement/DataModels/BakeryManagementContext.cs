using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BaketyManagement.DataModels
{
    public partial class BakeryManagementContext : DbContext
    {
        public BakeryManagementContext()
        {
        }
        private static BakeryManagementContext instance;

        public static BakeryManagementContext Instance
        {
            get
            {
                if (instance == null) instance = new BakeryManagementContext();
                return instance;
            }
            private set => instance = value;
        }
        public BakeryManagementContext(DbContextOptions<BakeryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<BilDetail> BilDetails { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Cake> Cakes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<Import> Imports { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialStore> MaterialStores { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeDetail> RecipeDetails { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<staff> staff { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DUNGXBUIF;Initial Catalog=BakeryManagement;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__Account__66DCF95D54A9ECAB");

                entity.ToTable("Account");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.IdStaff).HasColumnName("idStaff");

                entity.Property(e => e.Pass)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("pass");

                entity.Property(e => e.TypeAccount).HasColumnName("typeAccount");
            });

            modelBuilder.Entity<BilDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdBill, e.IdCake })
                    .HasName("PK__BilDetai__6E4549A8A71D58FF");

                entity.ToTable("BilDetail");

                entity.Property(e => e.IdBill).HasColumnName("idBill");

                entity.Property(e => e.IdCake).HasColumnName("idCake");

                entity.Property(e => e.AmountOrder).HasColumnName("amountOrder");

                entity.HasOne(d => d.IdBillNavigation)
                    .WithMany(p => p.BilDetails)
                    .HasForeignKey(d => d.IdBill)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BilDetail__idBil__4222D4EF");

                entity.HasOne(d => d.IdCakeNavigation)
                    .WithMany(p => p.BilDetails)
                    .HasForeignKey(d => d.IdCake)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BilDetail__idCak__412EB0B6");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill)
                    .HasName("PK__Bill__E6F933987AECB15C");

                entity.ToTable("Bill");

                entity.Property(e => e.IdBill)
                    .ValueGeneratedNever()
                    .HasColumnName("idBill");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.ExportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("exportDate");

                entity.Property(e => e.IdStaff).HasColumnName("idStaff");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdStaff)
                    .HasConstraintName("FK__Bill__idStaff__3F466844");
            });

            modelBuilder.Entity<Cake>(entity =>
            {
                entity.HasKey(e => e.IdCake)
                    .HasName("PK__Cake__8BC7A30921C5E9A7");

                entity.ToTable("Cake");

                entity.Property(e => e.IdCake)
                    .ValueGeneratedNever()
                    .HasColumnName("idCake");

                entity.Property(e => e.ExpCake)
                    .HasColumnType("date")
                    .HasColumnName("expCake");

                entity.Property(e => e.IdRecipe).HasColumnName("idRecipe");

                entity.Property(e => e.MfgCake)
                    .HasColumnType("date")
                    .HasColumnName("mfgCake");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("size");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__79D361B6CC94DBE1");

                entity.ToTable("Category");

                entity.Property(e => e.IdCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("idCategory");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameCategory");
            });

            modelBuilder.Entity<Export>(entity =>
            {
                entity.HasKey(e => e.IdExport)
                    .HasName("PK__Export__3BF05D28371E7B92");

                entity.ToTable("Export");

                entity.Property(e => e.IdExport)
                    .ValueGeneratedNever()
                    .HasColumnName("idExport");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.IdRecipe).HasColumnName("idRecipe");
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.HasKey(e => e.IdImport)
                    .HasName("PK__Import__798A20AFAE4A2E7B");

                entity.ToTable("Import");

                entity.Property(e => e.IdImport)
                    .ValueGeneratedNever()
                    .HasColumnName("idImport");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK__Material__6AC7E3EB4A3D51FB");

                entity.ToTable("Material");

                entity.Property(e => e.IdMaterial)
                    .ValueGeneratedNever()
                    .HasColumnName("idMaterial");

                entity.Property(e => e.IdSupplier).HasColumnName("idSupplier");

                entity.Property(e => e.NameMaterial)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameMaterial");

                entity.Property(e => e.Unit)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("unit");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("FK__Material__idSupp__440B1D61");
            });

            modelBuilder.Entity<MaterialStore>(entity =>
            {
                entity.HasKey(e => e.IdMaterialStore)
                    .HasName("PK__Material__72E1DCB082000E2A");

                entity.ToTable("MaterialStore");

                entity.Property(e => e.IdMaterialStore)
                    .ValueGeneratedNever()
                    .HasColumnName("idMaterialStore");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.IdRecipe)
                    .HasName("PK__Recipe__7BA2E083D6CA64D9");

                entity.ToTable("Recipe");

                entity.Property(e => e.IdRecipe)
                    .ValueGeneratedNever()
                    .HasColumnName("idRecipe");

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.NameCake)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameCake");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Recipe__idCatego__4316F928");
            });

            modelBuilder.Entity<RecipeDetail>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdRecipe })
                    .HasName("PK__RecipeDe__4D7DCDE3D93EFEDE");

                entity.ToTable("RecipeDetail");

                entity.Property(e => e.IdMaterial).HasColumnName("idMaterial");

                entity.Property(e => e.IdRecipe).HasColumnName("idRecipe");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.IdSalary)
                    .HasName("PK__Salary__BDC602979ECF7606");

                entity.ToTable("Salary");

                entity.Property(e => e.IdSalary)
                    .ValueGeneratedNever()
                    .HasColumnName("idSalary");

                entity.Property(e => e.HoursOverTime).HasColumnName("hoursOverTime");

                entity.Property(e => e.IdStaff).HasColumnName("idStaff");

                entity.Property(e => e.LastTimeKeeped)
                    .HasColumnType("date")
                    .HasColumnName("lastTimeKeeped");

                entity.Property(e => e.Rewards).HasColumnName("rewards");

                entity.Property(e => e.SalaryDate).HasColumnName("salaryDate");

                entity.Property(e => e.SalaryOverTime).HasColumnName("salaryOverTime");

                entity.Property(e => e.SalaryTime)
                    .HasColumnType("date")
                    .HasColumnName("salaryTime");

                entity.Property(e => e.TimeKeeped)
                    .HasColumnType("date")
                    .HasColumnName("timeKeeped");

                entity.Property(e => e.WorkDay).HasColumnName("workDay");

                entity.HasOne(d => d.IdStaffNavigation)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.IdStaff)
                    .HasConstraintName("FK__Salary__idStaff__403A8C7D");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.IdSupplier)
                    .HasName("PK__Supplier__696F9A7700B5454B");

                entity.ToTable("Supplier");

                entity.Property(e => e.IdSupplier)
                    .ValueGeneratedNever()
                    .HasColumnName("idSupplier");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.NameSupplier)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameSupplier");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.IdStaff)
                    .HasName("PK__Staff__98C886A93848E2C4");

                entity.ToTable("Staff");

                entity.Property(e => e.IdStaff)
                    .ValueGeneratedNever()
                    .HasColumnName("idStaff");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.NameStaff)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nameStaff");

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
