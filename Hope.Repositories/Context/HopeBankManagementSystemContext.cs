using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Hope.DomainEntities.DBEntities;

#nullable disable

namespace Hope.DomainEntities
{
    public partial class HopeBankManagementSystemContext : DbContext
    {
        public HopeBankManagementSystemContext()
        {
        }

        public HopeBankManagementSystemContext(DbContextOptions<HopeBankManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountOpening> AccountOpenings { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<DailyTransaction> DailyTransactions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<LoanPayment> LoanPayments { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleModule> RoleModules { get; set; }
        public virtual DbSet<RoleUser> RoleUsers { get; set; }
        public virtual DbSet<StocksRate> StocksRates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TalentPC002;Database=HopeBankManagementSystem;Trusted_Connection=True; User Id=sa;password=P@ssw0rd;Integrated Security=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountOpening>(entity =>
            {
                entity.ToTable("AccountOpening", "Services");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Iban)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("IBAN");

                entity.Property(e => e.OpeningDate).HasColumnType("date");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.AccountOpenings)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountOpening_AccountTypes");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.AccountOpenings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountOpening_Clients");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountTypes", "Admin");

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients", "Admin");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NationalId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("NationalID");

                entity.Property(e => e.PassportNumber).HasMaxLength(10);

                entity.Property(e => e.RegisterDate).HasColumnType("datetime");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.NationalityId)
                    .HasConstraintName("FK_Clients_Nationality");
            });

            modelBuilder.Entity<DailyTransaction>(entity =>
            {
                entity.HasKey(e => e.DailyTransactionsId);

                entity.ToTable("DailyTransactions", "Services");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees", "Admin");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdcardPath)
                    .HasMaxLength(100)
                    .HasColumnName("IDCardPath");

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Password).HasMaxLength(20);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Username).HasMaxLength(20);

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.QualificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Qualification");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("ErrorLog", "Admin");

                entity.Property(e => e.ErrorDate).HasColumnType("datetime");

                entity.Property(e => e.ErrorMessage).IsRequired();

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loans", "Services");

                entity.Property(e => e.Curreny)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.LoanSattelmentAmount).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.TaxValue).HasColumnType("decimal(18, 3)");

                entity.Property(e => e.TotalAmountwithInterest).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loans_Clients");

                entity.HasOne(d => d.LoanType)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.LoanTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Loans_LoanTypes");
            });

            modelBuilder.Entity<LoanPayment>(entity =>
            {
                entity.HasKey(e => e.LoanPaymentsId);

                entity.ToTable("LoanPayments", "Services");
            });

            modelBuilder.Entity<LoanType>(entity =>
            {
                entity.ToTable("LoanTypes", "Admin");

                entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MaxLoan).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaxValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module", "Admin");

                entity.Property(e => e.ModuleId).ValueGeneratedNever();

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nationality>(entity =>
            {
                entity.ToTable("Nationality", "Admin");

                entity.Property(e => e.NationalityName)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<Qualification>(entity =>
            {
                entity.ToTable("Qualification", "Admin");

                entity.Property(e => e.QualificationName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles", "Admin");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<RoleModule>(entity =>
            {
                entity.ToTable("RoleModule", "Admin");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.RoleModules)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleModule_Module");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleModules)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleModule_Roles");
            });

            modelBuilder.Entity<RoleUser>(entity =>
            {
                entity.ToTable("RoleUsers", "Admin");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUsers_Employees");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleUsers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUsers_Roles");
            });

            modelBuilder.Entity<StocksRate>(entity =>
            {
                entity.HasKey(e => e.StockRateId);

                entity.ToTable("StocksRates", "Admin");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 3)");

                entity.HasOne(d => d.Nationality)
                    .WithMany(p => p.StocksRates)
                    .HasForeignKey(d => d.NationalityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StocksRates_Nationality");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
