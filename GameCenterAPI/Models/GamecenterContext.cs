using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace GameCenterAPI.Models;

public partial class GamecenterContext : DbContext
{
    public GamecenterContext()
    {
    }

    public GamecenterContext(DbContextOptions<GamecenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBox> TbBoxes { get; set; }

    public virtual DbSet<TbClassify> TbClassifies { get; set; }

    public virtual DbSet<TbCompany> TbCompanies { get; set; }

    public virtual DbSet<TbCustomer> TbCustomers { get; set; }

    public virtual DbSet<TbDepartment> TbDepartments { get; set; }

    public virtual DbSet<TbEmployee> TbEmployees { get; set; }

    public virtual DbSet<TbItem> TbItems { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbPrinter> TbPrinters { get; set; }

    public virtual DbSet<TbPrivilege> TbPrivileges { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbService> TbServices { get; set; }

    public virtual DbSet<TbStore> TbStores { get; set; }

    public virtual DbSet<TbTable> TbTables { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    public virtual DbSet<Tbbill> Tbbills { get; set; }

    public virtual DbSet<Tbbilldetail> Tbbilldetails { get; set; }

    public virtual DbSet<Tbtransaction> Tbtransactions { get; set; }

    public virtual DbSet<Tbunit> Tbunits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=gamecenter;user=root;password=12345678", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<TbBox>(entity =>
        {
            entity.HasKey(e => e.BoxId).HasName("PRIMARY");

            entity
                .ToTable("tb_box", tb => tb.HasComment("امين الصندوق اليومي"))
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.BoxUId, "box_u_id");

            entity.Property(e => e.BoxId).HasColumnName("box_id");
            entity.Property(e => e.BoxDateIn)
                .HasColumnType("datetime")
                .HasColumnName("box_date_in");
            entity.Property(e => e.BoxDateOut)
                .HasColumnType("datetime")
                .HasColumnName("box_date_out");
            entity.Property(e => e.BoxDetails)
                .HasMaxLength(200)
                .HasColumnName("box_details");
            entity.Property(e => e.BoxIsopen).HasColumnName("box_isopen");
            entity.Property(e => e.BoxMonyIn).HasColumnName("box_mony_in");
            entity.Property(e => e.BoxMonyOut).HasColumnName("box_mony_out");
            entity.Property(e => e.BoxUId)
                .HasComment("اليوزر الذي فتح الصندوق")
                .HasColumnName("box_u_id");

            entity.HasOne(d => d.BoxU).WithMany(p => p.TbBoxes)
                .HasForeignKey(d => d.BoxUId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_box_ibfk_1");
        });

        modelBuilder.Entity<TbClassify>(entity =>
        {
            entity.HasKey(e => e.ClId).HasName("PRIMARY");

            entity
                .ToTable("tb_classify")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.ClId).HasColumnName("cl_id");
            entity.Property(e => e.ClDetails)
                .HasColumnType("text")
                .HasColumnName("cl_details");
            entity.Property(e => e.ClName)
                .HasMaxLength(100)
                .HasColumnName("cl_name");
        });

        modelBuilder.Entity<TbCompany>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PRIMARY");

            entity
                .ToTable("tb_company")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.CId).HasColumnName("c_id");
            entity.Property(e => e.CAddress)
                .HasMaxLength(50)
                .HasColumnName("c_address");
            entity.Property(e => e.CEmail)
                .HasMaxLength(50)
                .HasColumnName("c_email");
            entity.Property(e => e.CInsta)
                .HasMaxLength(50)
                .HasColumnName("c_insta");
            entity.Property(e => e.CLogo)
                .HasColumnType("blob")
                .HasColumnName("c_logo");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .HasColumnName("c_name");
            entity.Property(e => e.CPhone)
                .HasMaxLength(50)
                .HasColumnName("c_phone");
            entity.Property(e => e.CPhone1)
                .HasMaxLength(15)
                .HasColumnName("c_phone1");
            entity.Property(e => e.CSnap)
                .HasColumnType("blob")
                .HasColumnName("c_snap");
        });

        modelBuilder.Entity<TbCustomer>(entity =>
        {
            entity.HasKey(e => e.CuId).HasName("PRIMARY");

            entity
                .ToTable("tb_customers")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.CuId).HasColumnName("cu_id");
            entity.Property(e => e.CuAddress)
                .HasColumnType("text")
                .HasColumnName("cu_address");
            entity.Property(e => e.CuLocation)
                .HasColumnType("text")
                .HasColumnName("cu_location");
            entity.Property(e => e.CuName)
                .HasMaxLength(200)
                .HasColumnName("cu_name");
            entity.Property(e => e.CuNote)
                .HasColumnType("text")
                .HasColumnName("cu_note");
            entity.Property(e => e.CuPhone)
                .HasMaxLength(50)
                .HasColumnName("cu_phone");
            entity.Property(e => e.CuPhone2)
                .HasMaxLength(50)
                .HasColumnName("cu_phone2");
        });

        modelBuilder.Entity<TbDepartment>(entity =>
        {
            entity.HasKey(e => e.DeId).HasName("PRIMARY");

            entity
                .ToTable("tb_department")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.DeId).HasColumnName("de_id");
            entity.Property(e => e.DeName)
                .HasMaxLength(50)
                .HasColumnName("de_name");
        });

        modelBuilder.Entity<TbEmployee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PRIMARY");

            entity
                .ToTable("tb_employee")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.EmpName, "e_name").IsUnique();

            entity.HasIndex(e => e.EmpUserId, "tb_employee_ibfk_1");

            entity.Property(e => e.EmpId).HasColumnName("emp_id");
            entity.Property(e => e.EmpAddress)
                .HasMaxLength(50)
                .HasColumnName("emp_address");
            entity.Property(e => e.EmpDatebegin).HasColumnName("emp_datebegin");
            entity.Property(e => e.EmpDepartment)
                .HasMaxLength(50)
                .HasColumnName("emp_department");
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .HasColumnName("emp_name");
            entity.Property(e => e.EmpPhone)
                .HasMaxLength(50)
                .HasColumnName("emp_phone");
            entity.Property(e => e.EmpUserId).HasColumnName("emp_user_id");

            entity.HasOne(d => d.EmpUser).WithMany(p => p.TbEmployees)
                .HasForeignKey(d => d.EmpUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_employee_ibfk_1");
        });

        modelBuilder.Entity<TbItem>(entity =>
        {
            entity.HasKey(e => e.IId).HasName("PRIMARY");

            entity
                .ToTable("tb_item")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.IPrinterId, "i_printer_id");

            entity.HasIndex(e => e.IStoreId, "i_store_id");

            entity.Property(e => e.IId).HasColumnName("i_id");
            entity.Property(e => e.IBarcode)
                .HasMaxLength(100)
                .HasColumnName("i_barcode");
            entity.Property(e => e.IDetails)
                .HasColumnType("text")
                .HasColumnName("i_details");
            entity.Property(e => e.IImg)
                .HasColumnType("mediumblob")
                .HasColumnName("i_img");
            entity.Property(e => e.IIstime).HasColumnName("i_istime");
            entity.Property(e => e.ILimit).HasColumnName("i_limit");
            entity.Property(e => e.IName)
                .HasMaxLength(100)
                .HasColumnName("i_name");
            entity.Property(e => e.IPriceAvg).HasColumnName("i_price_avg");
            entity.Property(e => e.IPriceBuy).HasColumnName("i_price_buy");
            entity.Property(e => e.IPriceSale).HasColumnName("i_price_sale");
            entity.Property(e => e.IPrint)
                .HasComment("طباعة للمطبخ")
                .HasColumnName("i_print");
            entity.Property(e => e.IPrinterId).HasColumnName("i_printer_id");
            entity.Property(e => e.IQty).HasColumnName("i_qty");
            entity.Property(e => e.IStoreId).HasColumnName("i_store_id");

            entity.HasOne(d => d.IPrinter).WithMany(p => p.TbItems)
                .HasForeignKey(d => d.IPrinterId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_item_ibfk_1");

            entity.HasOne(d => d.IStore).WithMany(p => p.TbItems)
                .HasForeignKey(d => d.IStoreId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_item_ibfk_2");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MId).HasName("PRIMARY");

            entity
                .ToTable("tb_menu")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.MMenu, "connectWithService");

            entity.HasIndex(e => e.MBoxId, "m_box_id");

            entity.HasIndex(e => e.MCuId, "m_cu_id");

            entity.HasIndex(e => e.MDriverId, "m_driver_id");

            entity.HasIndex(e => e.MUId, "m_u_id");

            entity.Property(e => e.MId).HasColumnName("m_id");
            entity.Property(e => e.MBoxId).HasColumnName("m_box_id");
            entity.Property(e => e.MCancel)
                .HasComment("الغاء الوصل")
                .HasColumnName("m_cancel");
            entity.Property(e => e.MCuId)
                .HasComment("في حال كانت القائمة دلفري")
                .HasColumnName("m_cu_id");
            entity.Property(e => e.MDate)
                .HasColumnType("datetime")
                .HasColumnName("m_date");
            entity.Property(e => e.MDeleveryPrice)
                .HasPrecision(10, 2)
                .HasColumnName("m_delevery_price");
            entity.Property(e => e.MDiscount).HasColumnName("m_discount");
            entity.Property(e => e.MDriverId)
                .HasComment("هة نفسه الموظفين")
                .HasColumnName("m_driver_id");
            entity.Property(e => e.MIsactive).HasColumnName("m_isactive");
            entity.Property(e => e.MMenu).HasColumnName("m_menu");
            entity.Property(e => e.MNote)
                .HasColumnType("text")
                .HasColumnName("m_note");
            entity.Property(e => e.MType)
                .HasMaxLength(50)
                .HasComment("داخل-سفري-دلفري")
                .HasColumnName("m_type");
            entity.Property(e => e.MUId).HasColumnName("m_u_id");

            entity.HasOne(d => d.MBox).WithMany(p => p.TbMenus)
                .HasForeignKey(d => d.MBoxId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_menu_ibfk_3");

            entity.HasOne(d => d.MCu).WithMany(p => p.TbMenus)
                .HasForeignKey(d => d.MCuId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_menu_ibfk_1");

            entity.HasOne(d => d.MDriver).WithMany(p => p.TbMenus)
                .HasForeignKey(d => d.MDriverId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_menu_ibfk_2");

            entity.HasOne(d => d.MU).WithMany(p => p.TbMenus)
                .HasForeignKey(d => d.MUId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_menu_ibfk_4");
        });

        modelBuilder.Entity<TbPrinter>(entity =>
        {
            entity.HasKey(e => e.PrinterId).HasName("PRIMARY");

            entity.ToTable("tb_printer");

            entity.Property(e => e.PrinterId).HasColumnName("printer_id");
            entity.Property(e => e.PrinterDetails)
                .HasColumnType("text")
                .HasColumnName("printer_details");
            entity.Property(e => e.PrinterLocation)
                .HasMaxLength(100)
                .HasColumnName("printer_location");
            entity.Property(e => e.PrinterName)
                .HasMaxLength(200)
                .HasColumnName("printer_name");
        });

        modelBuilder.Entity<TbPrivilege>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tb_privilege")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.RoleId, "pr_ro_id");

            entity.Property(e => e.FormName).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.TbPrivileges)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("tb_privilege_ibfk_1");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoId).HasName("PRIMARY");

            entity
                .ToTable("tb_role")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.RoName, "ro_name").IsUnique();

            entity.Property(e => e.RoId).HasColumnName("ro_id");
            entity.Property(e => e.RoDetiles)
                .HasMaxLength(50)
                .HasColumnName("ro_detiles");
            entity.Property(e => e.RoName)
                .HasMaxLength(50)
                .HasColumnName("ro_name");
        });

        modelBuilder.Entity<TbService>(entity =>
        {
            entity.HasKey(e => e.SeId).HasName("PRIMARY");

            entity
                .ToTable("tb_service")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.SeIId, "se_i_id");

            entity.HasIndex(e => e.SeMenu, "se_menu");

            entity.Property(e => e.SeId).HasColumnName("se_id");
            entity.Property(e => e.SeDiscount).HasColumnName("se_discount");
            entity.Property(e => e.SeEnd)
                .HasComment("عند اضافة مادة نفس الوقت بدء ونهاية")
                .HasColumnType("time")
                .HasColumnName("se_end");
            entity.Property(e => e.SeIId).HasColumnName("se_i_id");
            entity.Property(e => e.SeIsdel).HasColumnName("se_isdel");
            entity.Property(e => e.SeMargeTo)
                .HasMaxLength(20)
                .HasColumnName("se_margeTo");
            entity.Property(e => e.SeMenu).HasColumnName("se_menu");
            entity.Property(e => e.SePrice).HasColumnName("se_price");
            entity.Property(e => e.SePrint).HasColumnName("se_print");
            entity.Property(e => e.SeQty).HasColumnName("se_qty");
            entity.Property(e => e.SeStart)
                .HasComment("بداية وقت اللعب")
                .HasColumnType("time")
                .HasColumnName("se_start");
            entity.Property(e => e.SeTNumber).HasColumnName("se_t_number");

            entity.HasOne(d => d.SeI).WithMany(p => p.TbServices)
                .HasForeignKey(d => d.SeIId)
                .HasConstraintName("tb_service_ibfk_2");
        });

        modelBuilder.Entity<TbStore>(entity =>
        {
            entity.HasKey(e => e.StoreId).HasName("PRIMARY");

            entity
                .ToTable("tb_store", tb => tb.HasComment("المخازن"))
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.Property(e => e.StoreId).HasColumnName("store_id");
            entity.Property(e => e.StoreDetails)
                .HasColumnType("text")
                .HasColumnName("store_details");
            entity.Property(e => e.StoreImg)
                .HasColumnType("mediumblob")
                .HasColumnName("store_img");
            entity.Property(e => e.StoreName)
                .HasMaxLength(50)
                .HasColumnName("store_name");
        });

        modelBuilder.Entity<TbTable>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PRIMARY");

            entity
                .ToTable("tb_table")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.TDefaultItem, "tb_table_ibfk_1");

            entity.Property(e => e.TId).HasColumnName("t_id");
            entity.Property(e => e.TDefaultItem).HasColumnName("t_defaultItem");
            entity.Property(e => e.TDetails)
                .HasMaxLength(200)
                .HasColumnName("t_details");
            entity.Property(e => e.TLocation)
                .HasMaxLength(200)
                .HasColumnName("t_location");
            entity.Property(e => e.TMap).HasColumnName("t_map");
            entity.Property(e => e.TName)
                .HasMaxLength(50)
                .HasColumnName("t_name");
            entity.Property(e => e.TNumber).HasColumnName("t_number");
            entity.Property(e => e.TbImage)
                .HasColumnType("mediumblob")
                .HasColumnName("tb_image");

            entity.HasOne(d => d.TDefaultItemNavigation).WithMany(p => p.TbTables)
                .HasForeignKey(d => d.TDefaultItem)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tb_table_ibfk_1");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PRIMARY");

            entity
                .ToTable("tb_user")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_general_ci");

            entity.HasIndex(e => e.UPrivilage, "tb_user_ibfk_1");

            entity.HasIndex(e => e.UUsername, "u_username").IsUnique();

            entity.Property(e => e.UId).HasColumnName("u_id");
            entity.Property(e => e.UActive).HasColumnName("u_active");
            entity.Property(e => e.UPassword)
                .HasMaxLength(50)
                .HasColumnName("u_password");
            entity.Property(e => e.UPrivilage)
                .HasComment("هو نفسه ro_id")
                .HasColumnName("u_privilage");
            entity.Property(e => e.URoot)
                .HasMaxLength(50)
                .HasColumnName("u_root");
            entity.Property(e => e.UUsername)
                .HasMaxLength(50)
                .HasColumnName("u_username");

            entity.HasOne(d => d.UPrivilageNavigation).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.UPrivilage)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tb_user_ibfk_1");
        });

        modelBuilder.Entity<Tbbill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PRIMARY");

            entity
                .ToTable("tbbill")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.BilEmployeeId, "tbbill_ibfk_1");

            entity.HasIndex(e => e.BillCustomerId, "tbbill_ibfk_3");

            entity.HasIndex(e => e.BillBoxId, "tbbill_ibfk_4");

            entity.Property(e => e.BillId)
                .ValueGeneratedNever()
                .HasColumnName("billID");
            entity.Property(e => e.BilEmployeeId).HasColumnName("bilEmployeeID");
            entity.Property(e => e.BillBoxId).HasColumnName("billBoxID");
            entity.Property(e => e.BillCustomerId).HasColumnName("billCustomerID");
            entity.Property(e => e.BillDate)
                .HasColumnType("datetime")
                .HasColumnName("billDate");
            entity.Property(e => e.BillDiscount)
                .HasPrecision(29, 2)
                .HasColumnName("billDiscount");
            entity.Property(e => e.BillEditDate)
                .HasColumnType("datetime")
                .HasColumnName("billEditDate");
            entity.Property(e => e.BillMarketNumber)
                .HasMaxLength(25)
                .HasColumnName("billMarketNumber");
            entity.Property(e => e.BillNote)
                .HasColumnType("mediumtext")
                .HasColumnName("billNote");
            entity.Property(e => e.BillPaidtype).HasColumnName("billPaidtype");
            entity.Property(e => e.BillType)
                .HasMaxLength(50)
                .HasComment("نوع القائمة شراء-بيع-ارجاع شراء-ارجاع بيع")
                .HasColumnName("billType");

            entity.HasOne(d => d.BilEmployee).WithMany(p => p.Tbbills)
                .HasForeignKey(d => d.BilEmployeeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tbbill_ibfk_1");

            entity.HasOne(d => d.BillBox).WithMany(p => p.Tbbills)
                .HasForeignKey(d => d.BillBoxId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tbbill_ibfk_2");

            entity.HasOne(d => d.BillCustomer).WithMany(p => p.Tbbills)
                .HasForeignKey(d => d.BillCustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tbbill_ibfk_3");
        });

        modelBuilder.Entity<Tbbilldetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tbbilldetails")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.ItemId, "ItemID");

            entity.HasIndex(e => e.BillId, "tbbilldetails_ibfk_1");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BillId).HasColumnName("billID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Price).HasPrecision(29, 2);

            entity.HasOne(d => d.Bill).WithMany(p => p.Tbbilldetails)
                .HasForeignKey(d => d.BillId)
                .HasConstraintName("tbbilldetails_ibfk_2");

            entity.HasOne(d => d.Item).WithMany(p => p.Tbbilldetails)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("tbbilldetails_ibfk_1");
        });

        modelBuilder.Entity<Tbtransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity
                .ToTable("tbtransactions")
                .UseCollation("utf8mb4_general_ci");

            entity.HasIndex(e => e.TransactionClassifyId, "TransactionClassifyId");

            entity.HasIndex(e => e.TransactionCustomerId, "TransactionCustomerId");

            entity.HasIndex(e => e.TransactionBoxId, "TransactionSafeDepostID");

            entity.HasIndex(e => e.TransactionUserId, "TransactionUserId");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.TransactionAmount).HasPrecision(10, 2);
            entity.Property(e => e.TransactionBoxId).HasColumnName("TransactionBoxID");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionDescription).HasMaxLength(255);
            entity.Property(e => e.TransactionType).HasColumnType("enum('expense','payment')");

            entity.HasOne(d => d.TransactionBox).WithMany(p => p.Tbtransactions)
                .HasForeignKey(d => d.TransactionBoxId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tbtransactions_ibfk_1");

            entity.HasOne(d => d.TransactionClassify).WithMany(p => p.Tbtransactions)
                .HasForeignKey(d => d.TransactionClassifyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("tbtransactions_ibfk_2");

            entity.HasOne(d => d.TransactionCustomer).WithMany(p => p.Tbtransactions)
                .HasForeignKey(d => d.TransactionCustomerId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tbtransactions_ibfk_3");

            entity.HasOne(d => d.TransactionUser).WithMany(p => p.Tbtransactions)
                .HasForeignKey(d => d.TransactionUserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("tbtransactions_ibfk_4");
        });

        modelBuilder.Entity<Tbunit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PRIMARY");

            entity
                .ToTable("tbunit")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.UnitId).HasColumnName("UnitID");
            entity.Property(e => e.UnitName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
