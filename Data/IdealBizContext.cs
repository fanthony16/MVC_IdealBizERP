using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace IdealBizUI.Data
{
    public partial class IdealBizContext : DbContext
    {
        public IdealBizContext()
        {
        }
        public IConfiguration configuration { get; set; }
        public IdealBizContext(DbContextOptions<IdealBizContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DimCurrency> DimCurrencies { get; set; }
        public virtual DbSet<DimDate> DimDates { get; set; }
        public virtual DbSet<FactCurrencyRate> FactCurrencyRates { get; set; }
        public virtual DbSet<LodgmentLine> LodgmentLines { get; set; }
        public virtual DbSet<OrderInfo> OrderInfos { get; set; }
        public virtual DbSet<Ssislog> Ssislogs { get; set; }
        public virtual DbSet<TblAccountChart> TblAccountCharts { get; set; }
        public virtual DbSet<TblAccountGroup> TblAccountGroups { get; set; }
        public virtual DbSet<TblCategory> TblCategories { get; set; }
        public virtual DbSet<TblClosingBalance> TblClosingBalances { get; set; }
        public virtual DbSet<TblCompany> TblCompanies { get; set; }
        public virtual DbSet<TblCustomer> TblCustomers { get; set; }
        public virtual DbSet<TblEmployee> TblEmployees { get; set; }
        public virtual DbSet<TblEmployeeActivity> TblEmployeeActivities { get; set; }
        public virtual DbSet<TblExpense> TblExpenses { get; set; }
        public virtual DbSet<TblGlentry> TblGlentries { get; set; }
        public virtual DbSet<TblInventoryEntry> TblInventoryEntries { get; set; }
        public virtual DbSet<TblInventoryItem> TblInventoryItems { get; set; }
        public virtual DbSet<TblInventoryRequisition> TblInventoryRequisitions { get; set; }
        public virtual DbSet<TblItem> TblItems { get; set; }
        public virtual DbSet<TblJournalDetail> TblJournalDetails { get; set; }
        public virtual DbSet<TblJournalMaster> TblJournalMasters { get; set; }
        public virtual DbSet<TblMedicalCategory> TblMedicalCategories { get; set; }
        public virtual DbSet<TblMedicalSubCategory> TblMedicalSubCategories { get; set; }
        public virtual DbSet<TblMedicalTestType> TblMedicalTestTypes { get; set; }
        public virtual DbSet<TblOnlineOrder> TblOnlineOrders { get; set; }
        public virtual DbSet<TblOrder> TblOrders { get; set; }
        public virtual DbSet<TblOrderItem> TblOrderItems { get; set; }
        public virtual DbSet<TblOrderPayment> TblOrderPayments { get; set; }
        public virtual DbSet<TblPaymentRequest> TblPaymentRequests { get; set; }
        public virtual DbSet<TblPl> TblPls { get; set; }
        public virtual DbSet<TblPostPeriod> TblPostPeriods { get; set; }
        public virtual DbSet<TblProductionItem> TblProductionItems { get; set; }
        public virtual DbSet<TblProductionMaterial> TblProductionMaterials { get; set; }
        public virtual DbSet<TblPurchaseRequest> TblPurchaseRequests { get; set; }
        public virtual DbSet<TblReciept> TblReciepts { get; set; }
        public virtual DbSet<TblStaffGrade> TblStaffGrades { get; set; }
        public virtual DbSet<TblStaffLevel> TblStaffLevels { get; set; }
        public virtual DbSet<TblSubAccount> TblSubAccounts { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }
        public virtual DbSet<TblUserAccess> TblUserAccesses { get; set; }
        public virtual DbSet<TblUserGroup> TblUserGroups { get; set; }
        public virtual DbSet<TblVendor> TblVendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                //optionsBuilder.UseSqlServer("Data Source=DML01;Initial Catalog=IdealBiz;User ID=sa;Password=staiwo16;Connect Timeout=30");


                optionsBuilder.UseSqlServer(this.configuration.GetConnectionString("DefaultConnectionString"));


            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DimCurrency>(entity =>
            {
                entity.HasKey(e => e.CurrencyKey);

                entity.ToTable("DimCurrency");

                entity.Property(e => e.CurrencyKey)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyAlternateKey)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DimDate>(entity =>
            {
                entity.HasKey(e => e.DateKey);

                entity.ToTable("DimDate");

                entity.Property(e => e.DateKey).HasColumnType("datetime");

                entity.Property(e => e.FullDateAlternateKey).HasColumnType("datetime");
            });

            modelBuilder.Entity<FactCurrencyRate>(entity =>
            {
                entity.HasKey(e => e.RowId)
                    .HasName("PK_FactCurrencyRate_1");

                entity.ToTable("FactCurrencyRate");

                entity.Property(e => e.RowId).HasColumnName("rowID");

                entity.Property(e => e.AverageRate).HasColumnType("decimal(18, 8)");

                entity.Property(e => e.CurrencyKey)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DateKey).HasColumnType("datetime");

                entity.Property(e => e.EndOfDayRate).HasColumnType("decimal(18, 8)");
            });

            modelBuilder.Entity<LodgmentLine>(entity =>
            {
                entity.HasKey(e => e.CashId);

                entity.ToTable("Lodgment Lines");

                entity.Property(e => e.CashId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CashID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ContributionPosted).HasColumnName("Contribution Posted");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderInfo>(entity =>
            {
                entity.HasKey(e => e.SubscriptionId)
                    .HasName("PK__OrderInf__9A2B24BD8756F2AE");

                entity.ToTable("OrderInfo");

                entity.Property(e => e.SubscriptionId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubscriptionID");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Order)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Ssislog>(entity =>
            {
                entity.ToTable("SSISLog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FileName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fileName");

                entity.Property(e => e.IntRecordCount).HasColumnName("intRecordCount");
            });

            modelBuilder.Entity<TblAccountChart>(entity =>
            {
                entity.HasKey(e => e.TxtAccountNumber);

                entity.ToTable("tblAccountChart");

                entity.Property(e => e.TxtAccountNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtAccountNumber");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccountGroup).HasColumnName("intAccountGroup");

                entity.Property(e => e.IntRecId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intRecID");

                entity.Property(e => e.IsPosting).HasColumnName("isPosting");

                entity.Property(e => e.TxtAccountName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txtAccountName");

                entity.HasOne(d => d.IntAccountGroupNavigation)
                    .WithMany(p => p.TblAccountCharts)
                    .HasForeignKey(d => d.IntAccountGroup)
                    .HasConstraintName("FK_tblAccountChart_tblAccountGroup");
            });

            modelBuilder.Entity<TblAccountGroup>(entity =>
            {
                entity.HasKey(e => e.IntAccountGroup);

                entity.ToTable("tblAccountGroup");

                entity.Property(e => e.IntAccountGroup).HasColumnName("intAccountGroup");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TxtAccountGroupName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txtAccountGroupName");
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.IntCategory);

                entity.ToTable("tblCategory");

                entity.Property(e => e.IntCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("intCategory");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated");

                entity.Property(e => e.IntCompany).HasColumnName("intCompany");

                entity.Property(e => e.TxtCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCategoryName");

                entity.Property(e => e.TxtLedgerAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtLedgerAccount");
            });

            modelBuilder.Entity<TblClosingBalance>(entity =>
            {
                entity.HasKey(e => new { e.TxtAccountCode, e.TxtPostPeriod });

                entity.ToTable("tblClosingBalance");

                entity.Property(e => e.TxtAccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtAccountCode");

                entity.Property(e => e.TxtPostPeriod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("txtPostPeriod");

                entity.Property(e => e.DteClosed)
                    .HasColumnType("datetime")
                    .HasColumnName("dteClosed");

                entity.Property(e => e.IntRecordId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intRecordID");

                entity.Property(e => e.NumCredit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numCredit");

                entity.Property(e => e.NumDebit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numDebit");

                entity.Property(e => e.TxtCloseBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCloseBy");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.TxtCompanyName);

                entity.ToTable("tblCompany");

                entity.HasIndex(e => e.IntCompany, "IX_tblCompany")
                    .IsUnique();

                entity.Property(e => e.TxtCompanyName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCompanyName");

                entity.Property(e => e.BlnApplyVat).HasColumnName("blnApplyVat");

                entity.Property(e => e.BlnConnect2Gl).HasColumnName("blnConnect2GL");

                entity.Property(e => e.BtnLogo).HasColumnName("btnLogo");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntCompany)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intCompany");

                entity.Property(e => e.NumVatRate)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numVatRate");

                entity.Property(e => e.TxtCompanyAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCompanyAddress");

                entity.Property(e => e.TxtContactPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtContactPhone");

                entity.Property(e => e.TxtEmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtEmailAddress");

                entity.Property(e => e.TxtGeneralIncomeLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtGeneralIncomeLedger");

                entity.Property(e => e.TxtInventoryExpenseLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtInventoryExpenseLedger");

                entity.Property(e => e.TxtInventoryIncomeLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtInventoryIncomeLedger");

                entity.Property(e => e.TxtInventoryLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtInventoryLedger");

                entity.Property(e => e.TxtOfficePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtOfficePhone");

                entity.Property(e => e.TxtPayableLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPayableLedger");

                entity.Property(e => e.TxtRecievableLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtRecievableLedger");

                entity.Property(e => e.TxtVatLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtVatLedger");
            });

            modelBuilder.Entity<TblCustomer>(entity =>
            {
                entity.HasKey(e => e.TxtCustomerCode);

                entity.ToTable("tblCustomer");

                entity.Property(e => e.TxtCustomerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCustomerCode");

                entity.Property(e => e.DteAnniversory)
                    .HasColumnType("datetime")
                    .HasColumnName("dteAnniversory");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteDob)
                    .HasColumnType("datetime")
                    .HasColumnName("dteDOB");

                entity.Property(e => e.IntCustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intCustomerID");

                entity.Property(e => e.NumCreditLimit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numCreditLimit");

                entity.Property(e => e.TxtCustomerName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtCustomerName");

                entity.Property(e => e.TxtEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txtEmail");

                entity.Property(e => e.TxtHomeAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtHomeAddress");

                entity.Property(e => e.TxtOfficeAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtOfficeAddress");

                entity.Property(e => e.TxtParentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtParentID");

                entity.Property(e => e.TxtRelationShip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtRelationShip");

                entity.Property(e => e.TxtSex)
                    .HasMaxLength(1)
                    .HasColumnName("txtSex")
                    .IsFixedLength(true);

                entity.Property(e => e.TxtTelephone1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtTelephone1");

                entity.Property(e => e.TxtTelephone2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtTelephone2");

                entity.Property(e => e.TxtTitle)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txtTitle");
            });

            modelBuilder.Entity<TblEmployee>(entity =>
            {
                entity.HasKey(e => e.TxtEmployeeCode);

                entity.ToTable("tblEmployee");

                entity.HasIndex(e => e.IntEmployeeId, "IX_tblEmployee")
                    .IsUnique();

                entity.Property(e => e.TxtEmployeeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtEmployeeCode");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntCompanyId).HasColumnName("intCompanyID");

                entity.Property(e => e.IntEmployeeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intEmployeeID");

                entity.Property(e => e.TxtAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("txtAddress");

                entity.Property(e => e.TxtAltTelephone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtAltTelephone");

                entity.Property(e => e.TxtName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtName");

                entity.Property(e => e.TxtNokname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtNOKName");

                entity.Property(e => e.TxtNokrelationship)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtNOKRelationship");

                entity.Property(e => e.TxtNoktelephone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtNOKTelephone");

                entity.Property(e => e.TxtPaymentMode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPaymentMode");

                entity.Property(e => e.TxtRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtRole");

                entity.Property(e => e.TxtTelephone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtTelephone");
            });

            modelBuilder.Entity<TblEmployeeActivity>(entity =>
            {
                entity.HasKey(e => e.IntActivityId);

                entity.ToTable("tblEmployeeActivities");

                entity.Property(e => e.IntActivityId).HasColumnName("intActivityID");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteDeallocated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteDeallocated");

                entity.Property(e => e.IntActivityType)
                    .HasColumnName("intActivityType")
                    .HasComment("1=Customer Order, 2 = In house Order");

                entity.Property(e => e.IntEmployeeId).HasColumnName("intEmployeeID");

                entity.Property(e => e.IntQuantity).HasColumnName("intQuantity");

                entity.Property(e => e.IntWorkItemId).HasColumnName("intWorkItemID");

                entity.Property(e => e.TxtProductionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtProductionCode");

                entity.HasOne(d => d.IntEmployee)
                    .WithMany(p => p.TblEmployeeActivities)
                    .HasPrincipalKey(p => p.IntEmployeeId)
                    .HasForeignKey(d => d.IntEmployeeId)
                    .HasConstraintName("FK_tblEmployeeActivities_tblEmployee");
            });

            modelBuilder.Entity<TblExpense>(entity =>
            {
                entity.HasKey(e => e.IntExpenseId);

                entity.ToTable("tblExpense");

                entity.Property(e => e.IntExpenseId).HasColumnName("intExpenseID");

                entity.Property(e => e.DteExpense)
                    .HasColumnType("datetime")
                    .HasColumnName("dteExpense");

                entity.Property(e => e.IntCompany).HasColumnName("intCompany");

                entity.Property(e => e.IsReversed)
                    .HasColumnName("isReversed")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numAmount");

                entity.Property(e => e.TxtExpenseCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtExpenseCode");

                entity.Property(e => e.TxtExpenseType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtExpenseType");

                entity.Property(e => e.TxtNarration)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtNarration");

                entity.Property(e => e.TxtPaymentSource)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPaymentSource");
            });

            modelBuilder.Entity<TblGlentry>(entity =>
            {
                entity.HasKey(e => e.IntGlentry);

                entity.ToTable("tblGLEntry");

                entity.Property(e => e.IntGlentry).HasColumnName("intGLEntry");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteValueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteValueDate");

                entity.Property(e => e.NumCredit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numCredit");

                entity.Property(e => e.NumDebit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numDebit");

                entity.Property(e => e.TxtEntryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtEntryCode");

                entity.Property(e => e.TxtExternalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtExternalCode");

                entity.Property(e => e.TxtLedgerAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtLedgerAccount");

                entity.Property(e => e.TxtMainAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtMainAccount");

                entity.Property(e => e.TxtNarration)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtNarration");

                entity.Property(e => e.TxtPostPeriod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("txtPostPeriod");

                entity.Property(e => e.TxtPostedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPostedBy");
            });

            modelBuilder.Entity<TblInventoryEntry>(entity =>
            {
                entity.HasKey(e => new { e.IntEntryId, e.TxtEntryCode });

                entity.ToTable("tblInventoryEntry");

                entity.HasIndex(e => e.TxtEntryCode, "IX_tblInventoryEntry")
                    .IsUnique();

                entity.Property(e => e.IntEntryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intEntryID");

                entity.Property(e => e.TxtEntryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtEntryCode");

                entity.Property(e => e.DteApproved)
                    .HasColumnType("datetime")
                    .HasColumnName("dteApproved");

                entity.Property(e => e.DteSentForApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSentForApproval");

                entity.Property(e => e.DteTransactionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteTransactionDate");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.Property(e => e.IntTransType).HasColumnName("intTransType");

                entity.Property(e => e.NumTotalPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numTotalPrice");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numUnitPrice");

                entity.Property(e => e.TxtApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtApprovedBy");

                entity.Property(e => e.TxtExternalEntryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtExternalEntryCode");

                entity.Property(e => e.TxtItemCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtItemCode");

                entity.Property(e => e.TxtSentForApprovalBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSentForApprovalBy");

                entity.Property(e => e.TxtStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtStatus")
                    .HasDefaultValueSql("('Open')");

                entity.Property(e => e.TxtVendorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtVendorCode");
            });

            modelBuilder.Entity<TblInventoryItem>(entity =>
            {
                entity.HasKey(e => e.TxtItemCode);

                entity.ToTable("tblInventoryItems");

                entity.Property(e => e.TxtItemCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtItemCode");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntInventoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intInventoryID");

                entity.Property(e => e.NumSellingPrice)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("numSellingPrice");

                entity.Property(e => e.TxtExpenseLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtExpenseLedger");

                entity.Property(e => e.TxtItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtItemName");

                entity.Property(e => e.TxtItemType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("txtItemType")
                    .HasDefaultValueSql("('P=Production Item, S= Sales Items')")
                    .IsFixedLength(true);

                entity.Property(e => e.TxtUnitOfMeasure)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtUnitOfMeasure");
            });

            modelBuilder.Entity<TblInventoryRequisition>(entity =>
            {
                entity.HasKey(e => e.IntEntryId)
                    .HasName("PK_tblIventoryDispense");

                entity.ToTable("tblInventoryRequisition");

                entity.Property(e => e.IntEntryId).HasColumnName("intEntryID");

                entity.Property(e => e.DteApproved)
                    .HasColumnType("datetime")
                    .HasColumnName("dteApproved");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteSentForApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSentForApproval");

                entity.Property(e => e.DteTransaction)
                    .HasColumnType("datetime")
                    .HasColumnName("dteTransaction");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.Property(e => e.TxtApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtApprovedBy");

                entity.Property(e => e.TxtEntryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtEntryCode");

                entity.Property(e => e.TxtExternalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtExternalCode");

                entity.Property(e => e.TxtExternalEntryCode)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtExternalEntryCode");

                entity.Property(e => e.TxtNarration)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtNarration");

                entity.Property(e => e.TxtSentForApprovalBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSentForApprovalBy");

                entity.Property(e => e.TxtStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtStatus")
                    .HasDefaultValueSql("('Open')");

                entity.HasOne(d => d.TxtEntryCodeNavigation)
                    .WithMany(p => p.TblInventoryRequisitions)
                    .HasPrincipalKey(p => p.TxtEntryCode)
                    .HasForeignKey(d => d.TxtEntryCode)
                    .HasConstraintName("FK_tblIventoryDispense_tblInventoryEntry");
            });

            modelBuilder.Entity<TblItem>(entity =>
            {
                entity.HasKey(e => e.IntItemId);

                entity.ToTable("tblItems");

                entity.Property(e => e.IntItemId).HasColumnName("intItemID");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated");

                entity.Property(e => e.IntCompany).HasColumnName("intCompany");

                entity.Property(e => e.NumCostOfAlteration)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numCostOfAlteration");

                entity.Property(e => e.NumCostOfSewing)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numCostOfSewing");

                entity.Property(e => e.TxtInventoryCode)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("txtInventoryCode");

                entity.Property(e => e.TxtItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtItemName");
            });

            modelBuilder.Entity<TblJournalDetail>(entity =>
            {
                entity.HasKey(e => e.IntJournalLine);

                entity.ToTable("tblJournalDetails");

                entity.Property(e => e.IntJournalLine).HasColumnName("intJournalLine");

                entity.Property(e => e.DtePostDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dtePostDate");

                entity.Property(e => e.DteValueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteValueDate");

                entity.Property(e => e.NumCredit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numCredit");

                entity.Property(e => e.NumDebit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numDebit");

                entity.Property(e => e.TxtJournalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtJournalCode");

                entity.Property(e => e.TxtLedgerAccount)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtLedgerAccount");

                entity.Property(e => e.TxtMainAccount)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtMainAccount");

                entity.Property(e => e.TxtNarration)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtNarration");

                entity.Property(e => e.TxtPostPeriod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("txtPostPeriod");

                entity.HasOne(d => d.TxtJournalCodeNavigation)
                    .WithMany(p => p.TblJournalDetails)
                    .HasForeignKey(d => d.TxtJournalCode)
                    .HasConstraintName("FK_tblJournalDetails_tblJournalMaster");
            });

            modelBuilder.Entity<TblJournalMaster>(entity =>
            {
                entity.HasKey(e => e.TxtJournalCode);

                entity.ToTable("tblJournalMaster");

                entity.Property(e => e.TxtJournalCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtJournalCode");

                entity.Property(e => e.DteApproved)
                    .HasColumnType("datetime")
                    .HasColumnName("dteApproved");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtePostDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dtePostDate");

                entity.Property(e => e.DteSentForApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSentForApproval");

                entity.Property(e => e.IntJournalMaster)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intJournalMaster");

                entity.Property(e => e.IsPosted)
                    .HasColumnName("isPosted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.NumJournalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numJournalAmount");

                entity.Property(e => e.TxtCreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCreatedBy");

                entity.Property(e => e.TxtPostPeriod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("txtPostPeriod");

                entity.Property(e => e.TxtPostedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPostedBy");

                entity.Property(e => e.TxtSentForApprovalBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSentForApprovalBy");

                entity.Property(e => e.TxtStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtStatus")
                    .HasDefaultValueSql("('Open')");

                entity.Property(e => e.TxtValueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("txtValueDate");
            });

            modelBuilder.Entity<TblMedicalCategory>(entity =>
            {
                entity.HasKey(e => e.TxtCategoryCode);

                entity.ToTable("tblMedicalCategory");

                entity.Property(e => e.TxtCategoryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCategoryCode");

                entity.Property(e => e.IntCategoryId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intCategoryID");

                entity.Property(e => e.TxtCategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txtCategoryName");
            });

            modelBuilder.Entity<TblMedicalSubCategory>(entity =>
            {
                entity.HasKey(e => e.TxtSubCategoryCode);

                entity.ToTable("tblMedicalSubCategory");

                entity.Property(e => e.TxtSubCategoryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSubCategoryCode");

                entity.Property(e => e.IntSubId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intSubID");

                entity.Property(e => e.TxtCategoryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCategoryCode");

                entity.Property(e => e.TxtSubCategoryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txtSubCategoryName");

                entity.HasOne(d => d.TxtCategoryCodeNavigation)
                    .WithMany(p => p.TblMedicalSubCategories)
                    .HasForeignKey(d => d.TxtCategoryCode)
                    .HasConstraintName("FK_tblMedicalSubCategory_tblMedicalCategory");
            });

            modelBuilder.Entity<TblMedicalTestType>(entity =>
            {
                entity.HasKey(e => e.TxtTestCode);

                entity.ToTable("tblMedicalTestType");

                entity.Property(e => e.TxtTestCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtTestCode");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intTypeID");

                entity.Property(e => e.TxtCategoryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCategoryCode");

                entity.Property(e => e.TxtSubCategoryCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSubCategoryCode");

                entity.Property(e => e.TxtTestName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("txtTestName");

                entity.HasOne(d => d.TxtCategoryCodeNavigation)
                    .WithMany(p => p.TblMedicalTestTypes)
                    .HasForeignKey(d => d.TxtCategoryCode)
                    .HasConstraintName("FK_tblMedicalTestType_tblMedicalCategory");

                entity.HasOne(d => d.TxtSubCategoryCodeNavigation)
                    .WithMany(p => p.TblMedicalTestTypes)
                    .HasForeignKey(d => d.TxtSubCategoryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMedicalTestType_tblMedicalSubCategory");
            });

            modelBuilder.Entity<TblOnlineOrder>(entity =>
            {
                entity.HasKey(e => e.IntId);

                entity.ToTable("tblOnlineOrder");

                entity.Property(e => e.IntId).HasColumnName("intID");

                entity.Property(e => e.DteOrderDate)
                    .HasColumnType("date")
                    .HasColumnName("dteOrderDate");

                entity.Property(e => e.IntCompanyId).HasColumnName("intCompanyID");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.Property(e => e.NumCostPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numCostPrice");

                entity.Property(e => e.NumTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numTotal");

                entity.Property(e => e.TxtCustomerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCustomerCode");

                entity.Property(e => e.TxtItemCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtItemCode");

                entity.HasOne(d => d.IntCompany)
                    .WithMany(p => p.TblOnlineOrders)
                    .HasPrincipalKey(p => p.IntCompany)
                    .HasForeignKey(d => d.IntCompanyId)
                    .HasConstraintName("FK_tblOnlineOrder_tblCompany");

                entity.HasOne(d => d.TxtCustomerCodeNavigation)
                    .WithMany(p => p.TblOnlineOrders)
                    .HasForeignKey(d => d.TxtCustomerCode)
                    .HasConstraintName("FK_tblOnlineOrder_tblCustomer");

                entity.HasOne(d => d.TxtItemCodeNavigation)
                    .WithMany(p => p.TblOnlineOrders)
                    .HasForeignKey(d => d.TxtItemCode)
                    .HasConstraintName("FK_tblOnlineOrder_tblInventoryItems");
            });

            modelBuilder.Entity<TblOrder>(entity =>
            {
                entity.HasKey(e => e.TxtOrderNumber)
                    .HasName("PK_tblCustomerOrder");

                entity.ToTable("tblOrder");

                entity.Property(e => e.TxtOrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtOrderNumber");

                entity.Property(e => e.BlnHasInventoryItem)
                    .HasColumnName("blnHasInventoryItem")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DteConfirmed)
                    .HasColumnType("datetime")
                    .HasColumnName("dteConfirmed");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated");

                entity.Property(e => e.DteDueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteDueDate");

                entity.Property(e => e.DteOrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteOrderDate");

                entity.Property(e => e.DteSentForApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSentForApproval");

                entity.Property(e => e.IntCompanyId).HasColumnName("intCompanyID");

                entity.Property(e => e.IntOrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intOrderID");

                entity.Property(e => e.NumDiscountAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numDiscountAmount");

                entity.Property(e => e.NumNetAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numNetAmount");

                entity.Property(e => e.NumOrderAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numOrderAmount");

                entity.Property(e => e.NumOtherCharges)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numOtherCharges");

                entity.Property(e => e.NumVat)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numVAT");

                entity.Property(e => e.TxtConfirmedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtConfirmedBy");

                entity.Property(e => e.TxtCreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCreatedBy");

                entity.Property(e => e.TxtCustomerCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCustomerCode");

                entity.Property(e => e.TxtSentForApproval)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSentForApproval");

                entity.Property(e => e.TxtStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtStatus")
                    .HasDefaultValueSql("('Open')");

                entity.HasOne(d => d.IntCompany)
                    .WithMany(p => p.TblOrders)
                    .HasPrincipalKey(p => p.IntCompany)
                    .HasForeignKey(d => d.IntCompanyId)
                    .HasConstraintName("FK_tblOrder_tblCompany");

                entity.HasOne(d => d.TxtCustomerCodeNavigation)
                    .WithMany(p => p.TblOrders)
                    .HasForeignKey(d => d.TxtCustomerCode)
                    .HasConstraintName("FK_tblCustomerOrder_tblCustomer");
            });

            modelBuilder.Entity<TblOrderItem>(entity =>
            {
                entity.HasKey(e => e.IntOrderItem);

                entity.ToTable("tblOrderItems");

                entity.Property(e => e.IntOrderItem).HasColumnName("intOrderItem");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.Property(e => e.NumTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numTotal");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numUnitPrice");

                entity.Property(e => e.TxtItemCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtItemCode");

                entity.Property(e => e.TxtNarration)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtNarration");

                entity.Property(e => e.TxtOrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtOrderNumber");

                entity.HasOne(d => d.TxtOrderNumberNavigation)
                    .WithMany(p => p.TblOrderItems)
                    .HasForeignKey(d => d.TxtOrderNumber)
                    .HasConstraintName("FK_tblOrderItems_tblOrder");
            });

            modelBuilder.Entity<TblOrderPayment>(entity =>
            {
                entity.HasKey(e => e.TxtPaymentRef);

                entity.ToTable("tblOrderPayment");

                entity.Property(e => e.TxtPaymentRef)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtPaymentRef");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated");

                entity.Property(e => e.IntPaymentId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intPaymentID");

                entity.Property(e => e.NumAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numAmount");

                entity.Property(e => e.TxtOrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtOrderNumber");

                entity.HasOne(d => d.TxtOrderNumberNavigation)
                    .WithMany(p => p.TblOrderPayments)
                    .HasForeignKey(d => d.TxtOrderNumber)
                    .HasConstraintName("FK_tblOrderPayment_tblCustomerOrder");
            });

            modelBuilder.Entity<TblPaymentRequest>(entity =>
            {
                entity.HasKey(e => e.IntPaymentId);

                entity.ToTable("tblPaymentRequest");

                entity.Property(e => e.IntPaymentId).HasColumnName("intPaymentID");

                entity.Property(e => e.DteApproved)
                    .HasColumnType("datetime")
                    .HasColumnName("dteApproved");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DtePayment)
                    .HasColumnType("datetime")
                    .HasColumnName("dtePayment");

                entity.Property(e => e.DteSentForApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSentForApproval");

                entity.Property(e => e.IntCompany).HasColumnName("intCompany");

                entity.Property(e => e.NumAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numAmount");

                entity.Property(e => e.TxtApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtApprovedBy");

                entity.Property(e => e.TxtCreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCreatedBy");

                entity.Property(e => e.TxtNarration)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("txtNarration");

                entity.Property(e => e.TxtPaymentCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPaymentCode");

                entity.Property(e => e.TxtPaymentSource)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtPaymentSource");

                entity.Property(e => e.TxtRequisitionCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtRequisitionCode");

                entity.Property(e => e.TxtSentForApprovalBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSentForApprovalBy");

                entity.Property(e => e.TxtStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtStatus")
                    .HasDefaultValueSql("('Open')");

                entity.Property(e => e.TxtVendorCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtVendorCode");

                entity.HasOne(d => d.TxtRequisitionCodeNavigation)
                    .WithMany(p => p.TblPaymentRequests)
                    .HasForeignKey(d => d.TxtRequisitionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPaymentRequest_tblPurchaseRequest");

                entity.HasOne(d => d.TxtVendorCodeNavigation)
                    .WithMany(p => p.TblPaymentRequests)
                    .HasForeignKey(d => d.TxtVendorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblPaymentRequest_tblVendor");
            });

            modelBuilder.Entity<TblPl>(entity =>
            {
                entity.HasKey(e => e.IntId);

                entity.ToTable("tblPL");

                entity.Property(e => e.IntId).HasColumnName("intID");

                entity.Property(e => e.IntOrderId).HasColumnName("intOrderID");

                entity.Property(e => e.IntType)
                    .HasColumnName("intType")
                    .HasComment("0=Headers, 1= Income, 2= Expense, 3= Total");

                entity.Property(e => e.TxtLedgerAccounts)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtLedgerAccounts");

                entity.Property(e => e.TxtScript)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtScript");

                entity.Property(e => e.TxtTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtTitle");
            });

            modelBuilder.Entity<TblPostPeriod>(entity =>
            {
                entity.HasKey(e => e.TxtPostPeriod);

                entity.ToTable("tblPostPeriod");

                entity.Property(e => e.TxtPostPeriod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPostPeriod");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated");

                entity.Property(e => e.DteEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteEndDate");

                entity.Property(e => e.DtePeriodClose)
                    .HasColumnType("datetime")
                    .HasColumnName("dtePeriodClose");

                entity.Property(e => e.DteStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteStartDate");

                entity.Property(e => e.IntPostPeriod)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intPostPeriod");

                entity.Property(e => e.IsPeriodClose).HasColumnName("isPeriodClose");

                entity.Property(e => e.IsYearEnd).HasColumnName("isYearEnd");

                entity.Property(e => e.TxtPeriodCloseBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPeriodCloseBy");
            });

            modelBuilder.Entity<TblProductionItem>(entity =>
            {
                entity.HasKey(e => e.TxtProductionCode);

                entity.ToTable("tblProductionItem");

                entity.Property(e => e.TxtProductionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtProductionCode");

                entity.Property(e => e.DteApproved)
                    .HasColumnType("datetime")
                    .HasColumnName("dteApproved");

                entity.Property(e => e.DteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("dteDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteReleased)
                    .HasColumnType("datetime")
                    .HasColumnName("dteReleased");

                entity.Property(e => e.DteSentForApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSentForApproval");

                entity.Property(e => e.IntCompanyId).HasColumnName("intCompanyID");

                entity.Property(e => e.IntCutter).HasColumnName("intCutter");

                entity.Property(e => e.IntItemId).HasColumnName("intItemID");

                entity.Property(e => e.IntProductionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intProductionID");

                entity.Property(e => e.IntTailor).HasColumnName("intTailor");

                entity.Property(e => e.TxtApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtApprovedBy");

                entity.Property(e => e.TxtCreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("txtCreatedBy");

                entity.Property(e => e.TxtInventoryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtInventoryCode");

                entity.Property(e => e.TxtInventoryEntryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtInventoryEntryCode");

                entity.Property(e => e.TxtReleasedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtReleasedBy");

                entity.Property(e => e.TxtSentBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSentBy");

                entity.Property(e => e.TxtStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtStatus")
                    .HasDefaultValueSql("('Open')");
            });

            modelBuilder.Entity<TblProductionMaterial>(entity =>
            {
                entity.HasKey(e => e.IntProductionMaterialId);

                entity.ToTable("tblProductionMaterial");

                entity.Property(e => e.IntProductionMaterialId).HasColumnName("intProductionMaterialID");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.Property(e => e.NumTotal)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numTotal");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numUnitPrice");

                entity.Property(e => e.TxtInventoryCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtInventoryCode");

                entity.Property(e => e.TxtProductionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtProductionCode");
            });

            modelBuilder.Entity<TblPurchaseRequest>(entity =>
            {
                entity.HasKey(e => e.TxtRequisitionCode);

                entity.ToTable("tblPurchaseRequest");

                entity.Property(e => e.TxtRequisitionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtRequisitionCode");

                entity.Property(e => e.DteApproved)
                    .HasColumnType("datetime")
                    .HasColumnName("dteApproved");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DteRequest)
                    .HasColumnType("datetime")
                    .HasColumnName("dteRequest");

                entity.Property(e => e.DteSentForApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("dteSentForApproval");

                entity.Property(e => e.IntCompany)
                    .HasColumnName("intCompany")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IntQty).HasColumnName("intQty");

                entity.Property(e => e.IntRequisition)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intRequisition");

                entity.Property(e => e.IntRequisitionType)
                    .HasColumnName("intRequisitionType")
                    .HasComment("1 = Inventory, 0 = Non Inventory");

                entity.Property(e => e.NumTotalAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numTotalAmount");

                entity.Property(e => e.NumUnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numUnitPrice");

                entity.Property(e => e.TxtApprovedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtApprovedBy");

                entity.Property(e => e.TxtCreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtCreatedBy");

                entity.Property(e => e.TxtDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtDescription");

                entity.Property(e => e.TxtExpenseLedger)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtExpenseLedger");

                entity.Property(e => e.TxtItemCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtItemCode");

                entity.Property(e => e.TxtSentForApprovalBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSentForApprovalBy");

                entity.Property(e => e.TxtStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtStatus")
                    .HasDefaultValueSql("('Open')");

                entity.Property(e => e.TxtVendorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtVendorCode");

                entity.HasOne(d => d.IntCompanyNavigation)
                    .WithMany(p => p.TblPurchaseRequests)
                    .HasPrincipalKey(p => p.IntCompany)
                    .HasForeignKey(d => d.IntCompany)
                    .HasConstraintName("FK_tblPurchaseRequest_tblCompany");

                entity.HasOne(d => d.TxtVendorCodeNavigation)
                    .WithMany(p => p.TblPurchaseRequests)
                    .HasForeignKey(d => d.TxtVendorCode)
                    .HasConstraintName("FK_tblPurchaseRequest_tblVendor");
            });

            modelBuilder.Entity<TblReciept>(entity =>
            {
                entity.HasKey(e => e.IntRecieptNo);

                entity.ToTable("tblReciepts");

                entity.Property(e => e.IntRecieptNo).HasColumnName("intRecieptNo");

                entity.Property(e => e.DteReciept)
                    .HasColumnType("datetime")
                    .HasColumnName("dteReciept");

                entity.Property(e => e.DteReversed)
                    .HasColumnType("datetime")
                    .HasColumnName("dteReversed");

                entity.Property(e => e.NumAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("numAmount");

                entity.Property(e => e.TxtNarration)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("txtNarration");

                entity.Property(e => e.TxtOrderNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtOrderNumber");

                entity.Property(e => e.TxtRecieptCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtRecieptCode");

                entity.Property(e => e.TxtRecieptType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtRecieptType");

                entity.HasOne(d => d.TxtOrderNumberNavigation)
                    .WithMany(p => p.TblReciepts)
                    .HasForeignKey(d => d.TxtOrderNumber)
                    .HasConstraintName("FK_tblReciepts_tblOrder");
            });

            modelBuilder.Entity<TblStaffGrade>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblStaffGrade");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntGrade).HasColumnName("intGrade");

                entity.Property(e => e.TxtGraceName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtGraceName");

                entity.Property(e => e.TxtGradeCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtGradeCode");
            });

            modelBuilder.Entity<TblStaffLevel>(entity =>
            {
                entity.HasKey(e => e.TxtLevelCode);

                entity.ToTable("tblStaffLevel");

                entity.Property(e => e.TxtLevelCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtLevelCode");

                entity.Property(e => e.IntLevel).HasColumnName("intLevel");

                entity.Property(e => e.TxtLevelName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtLevelName");
            });

            modelBuilder.Entity<TblSubAccount>(entity =>
            {
                entity.HasKey(e => e.TxtAccountCode);

                entity.ToTable("tblSubAccount");

                entity.HasIndex(e => e.IntSubAccount, "IX_tblSubAccount")
                    .IsUnique();

                entity.Property(e => e.TxtAccountCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtAccountCode");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntSubAccount)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intSubAccount");

                entity.Property(e => e.TxtAccountName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtAccountName");

                entity.Property(e => e.TxtMainAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtMainAccount");

                entity.HasOne(d => d.TxtMainAccountNavigation)
                    .WithMany(p => p.TblSubAccounts)
                    .HasForeignKey(d => d.TxtMainAccount)
                    .HasConstraintName("FK_tblSubAccount_tblAccountChart");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.IntUser);

                entity.ToTable("tblUsers");

                entity.Property(e => e.IntUser).HasColumnName("intUser");

                entity.Property(e => e.BlnIsActive)
                    .HasColumnName("blnIsActive")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated");

                entity.Property(e => e.TxtFullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtFullName");

                entity.Property(e => e.TxtPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtPassword");

                entity.Property(e => e.TxtSurname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtSurname");

                entity.Property(e => e.TxtUserAccessGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtUserAccessGroup");

                entity.Property(e => e.TxtUserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtUserName");

                entity.HasOne(d => d.TxtUserAccessGroupNavigation)
                    .WithMany(p => p.TblUsers)
                    .HasForeignKey(d => d.TxtUserAccessGroup)
                    .HasConstraintName("FK_tblUsers_tblUserGroup");
            });

            modelBuilder.Entity<TblUserAccess>(entity =>
            {
                entity.HasKey(e => new { e.TxtGroupCode, e.TxtMenuCode });

                entity.ToTable("tblUserAccess");

                entity.Property(e => e.TxtGroupCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtGroupCode");

                entity.Property(e => e.TxtMenuCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtMenuCode");

                entity.Property(e => e.BlnCreate).HasColumnName("blnCreate");

                entity.Property(e => e.BlnDelete).HasColumnName("blnDelete");

                entity.Property(e => e.BlnEdit).HasColumnName("blnEdit");

                entity.Property(e => e.BlnIsMain).HasColumnName("blnIsMain");

                entity.Property(e => e.BlnPrint).HasColumnName("blnPrint");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccess)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intAccess");
            });

            modelBuilder.Entity<TblUserGroup>(entity =>
            {
                entity.HasKey(e => e.TxtGroupCode);

                entity.ToTable("tblUserGroup");

                entity.Property(e => e.TxtGroupCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtGroupCode");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IntAccessGroup)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intAccessGroup");

                entity.Property(e => e.TxtGroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtGroupName");
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.HasKey(e => e.TxtVendorCode);

                entity.ToTable("tblVendor");

                entity.Property(e => e.TxtVendorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtVendorCode");

                entity.Property(e => e.DteCreated)
                    .HasColumnType("datetime")
                    .HasColumnName("dteCreated");

                entity.Property(e => e.IntVendorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("intVendorID");

                entity.Property(e => e.TxtContactPerson)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtContactPerson");

                entity.Property(e => e.TxtEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtEmail");

                entity.Property(e => e.TxtOfficeAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtOfficeAddress");

                entity.Property(e => e.TxtTelephone1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtTelephone1");

                entity.Property(e => e.TxtTelephone2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtTelephone2");

                entity.Property(e => e.TxtTin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtTIN");

                entity.Property(e => e.TxtVendorName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("txtVendorName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
