using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Entity.Rxmes;

namespace webapi.Models;

public partial class RxmesContext : DbContext
{
    public RxmesContext()
    {
    }

    public RxmesContext(DbContextOptions<RxmesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CustProductSetting> CustProductSettings { get; set; }
    public virtual DbSet<Fwwiptransaction> Fwwiptransactions { get; set; }
    public virtual DbSet<Fwlot> Fwlots { get; set; }
    public virtual DbSet<CustEqpSptDatum> CustEqpSptData { get; set; }
    public virtual DbSet<FwProcessSpec> FwProcessSpecs { get; set; }
    public virtual DbSet<Fwproductversion> Fwproductversions { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.163.76.5)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=RXPROD)));User Id=rxmes;Password=rxmes;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RXMES")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<CustProductSetting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CUST_PRODUCT_SETTING");

            entity.HasIndex(e => e.Product, "CUST_PRODUCT_SETTING_INDEX1").IsUnique();

            entity.Property(e => e.Beproductname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("BEPRODUCTNAME");
            entity.Property(e => e.Comments)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.Cuscode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CUSCODE");
            entity.Property(e => e.Cusno)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CUSNO");
            entity.Property(e => e.Cusprod)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CUSPROD");
            entity.Property(e => e.Datetime)
                .HasDefaultValueSql("sysdate")
                .HasColumnType("DATE")
                .HasColumnName("DATETIME");
            entity.Property(e => e.Dienum)
                .HasColumnType("NUMBER")
                .HasColumnName("DIENUM");
            entity.Property(e => e.Isbe)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("ISBE");
            entity.Property(e => e.Module)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MODULE");
            entity.Property(e => e.Motherpart)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MOTHERPART");
            entity.Property(e => e.Owner)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("OWNER");
            entity.Property(e => e.Photos)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOS");
            entity.Property(e => e.Processcode)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PROCESSCODE");
            entity.Property(e => e.Processgroup)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSGROUP");
            entity.Property(e => e.Processtech)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSTECH");
            entity.Property(e => e.Processtype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Prodstatus)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRODSTATUS");
            entity.Property(e => e.Product)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRODUCT");
            entity.Property(e => e.Qacontrol)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("QACONTROL");
            entity.Property(e => e.Quename)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("QUENAME");
            entity.Property(e => e.Sremark)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("SREMARK");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Thickfilm)
                .HasColumnType("NUMBER")
                .HasColumnName("THICKFILM");
            entity.Property(e => e.Wafertype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("WAFERTYPE");
            entity.Property(e => e.Wbflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("WBFLAG");
        });
        modelBuilder.HasSequence("CORESEQUENCE");
        modelBuilder.HasSequence("EQPSEQUENCE");
        modelBuilder.HasSequence("NEWCORESEQUENCE").IsCyclic();
        modelBuilder.HasSequence("NEWEQPSEQUENCE").IsCyclic();
        modelBuilder.HasSequence("PARTITIONSEQUENCE");
        modelBuilder.HasSequence("WIPSEQUENCE").IsCyclic();

        modelBuilder.Entity<Fwwiptransaction>(entity =>
        {
            entity.HasKey(e => e.Sysid).HasName("SYS_C007814");

            entity.ToTable("FWWIPTRANSACTION");

            entity.HasIndex(e => e.Lotobject, "LOTOBJECT_0E94");

            entity.HasIndex(e => e.Wipid, "WIPID_0E94");

            entity.HasIndex(e => e.Txnsequence, "WIP_TXNSEQUENCE_0E94");

            entity.Property(e => e.Sysid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("SYSID");
            entity.Property(e => e.Activity)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ACTIVITY");
            entity.Property(e => e.Attribute)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ATTRIBUTE");
            entity.Property(e => e.Clearfutureholdplanid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("CLEARFUTUREHOLDPLANID");
            entity.Property(e => e.Clearfutureholdstepid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("CLEARFUTUREHOLDSTEPID");
            entity.Property(e => e.Componentid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COMPONENTID");
            entity.Property(e => e.Componentqtyadded)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COMPONENTQTYADDED");
            entity.Property(e => e.Componentqtyremoved)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COMPONENTQTYREMOVED");
            entity.Property(e => e.Consumeqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CONSUMEQTY");
            entity.Property(e => e.Endstephandle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ENDSTEPHANDLE");
            entity.Property(e => e.Fromlocation)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMLOCATION");
            entity.Property(e => e.Frommaterial)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FROMMATERIAL");
            entity.Property(e => e.Futureholdplanid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("FUTUREHOLDPLANID");
            entity.Property(e => e.Futureholdstepid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("FUTUREHOLDSTEPID");
            entity.Property(e => e.Futureplanid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("FUTUREPLANID");
            entity.Property(e => e.Futurestepid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("FUTURESTEPID");
            entity.Property(e => e.Futuretype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FUTURETYPE");
            entity.Property(e => e.Holdrelease)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("HOLDRELEASE");
            entity.Property(e => e.Inlocation)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("INLOCATION");
            entity.Property(e => e.Instep)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("INSTEP");
            entity.Property(e => e.Lasttrackout)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LASTTRACKOUT");
            entity.Property(e => e.Lasttxnid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("LASTTXNID");
            entity.Property(e => e.Lotobject)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("LOTOBJECT");
            entity.Property(e => e.Mainlotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("MAINLOTID");
            entity.Property(e => e.Mergestepid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("MERGESTEPID");
            entity.Property(e => e.Newlotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NEWLOTID");
            entity.Property(e => e.Newplan)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("NEWPLAN");
            entity.Property(e => e.Newproduct)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NEWPRODUCT");
            entity.Property(e => e.Newstep)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("NEWSTEP");
            entity.Property(e => e.Newvalue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NEWVALUE");
            entity.Property(e => e.Oldlotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("OLDLOTID");
            entity.Property(e => e.Originalstep)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("ORIGINALSTEP");
            entity.Property(e => e.Originalvalue)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ORIGINALVALUE");
            entity.Property(e => e.Outstep)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("OUTSTEP");
            entity.Property(e => e.Parenttxn)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PARENTTXN");
            entity.Property(e => e.Path)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PATH");
            entity.Property(e => e.Quantityin)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("QUANTITYIN");
            entity.Property(e => e.Quantityout)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("QUANTITYOUT");
            entity.Property(e => e.Receiveinfo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("RECEIVEINFO");
            entity.Property(e => e.Rejoinstephandle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("REJOINSTEPHANDLE");
            entity.Property(e => e.Reworkstep)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("REWORKSTEP");
            entity.Property(e => e.Schedule)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SCHEDULE");
            entity.Property(e => e.Scheduleversion)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SCHEDULEVERSION");
            entity.Property(e => e.Shift)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SHIFT");
            entity.Property(e => e.Shipmentnumber)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SHIPMENTNUMBER");
            entity.Property(e => e.Stephandleforundo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STEPHANDLEFORUNDO");
            entity.Property(e => e.Stepidafterundo)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("STEPIDAFTERUNDO");
            entity.Property(e => e.Stepidbeforeundo)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("STEPIDBEFOREUNDO");
            entity.Property(e => e.Stepidtoundo)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("STEPIDTOUNDO");
            entity.Property(e => e.Tolocation)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TOLOCATION");
            entity.Property(e => e.Trackintime)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TRACKINTIME");
            entity.Property(e => e.Transferfromlotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TRANSFERFROMLOTID");
            entity.Property(e => e.Transferqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TRANSFERQTY");
            entity.Property(e => e.Transfertolotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TRANSFERTOLOTID");
            entity.Property(e => e.Txncomment)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("TXNCOMMENT");
            entity.Property(e => e.Txnsequence)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("TXNSEQUENCE");
            entity.Property(e => e.Txntimestamp)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TXNTIMESTAMP");
            entity.Property(e => e.Undoflag)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UNDOFLAG");
            entity.Property(e => e.Undotype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("UNDOTYPE");
            entity.Property(e => e.Userid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("USERID");
            entity.Property(e => e.Wipid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("WIPID");
            entity.Property(e => e.Wiptxntoundo)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("WIPTXNTOUNDO");
        });
        modelBuilder.HasSequence("CORESEQUENCE");
        modelBuilder.HasSequence("EQPSEQUENCE");
        modelBuilder.HasSequence("NEWCORESEQUENCE").IsCyclic();
        modelBuilder.HasSequence("NEWEQPSEQUENCE").IsCyclic();
        modelBuilder.HasSequence("PARTITIONSEQUENCE");
        modelBuilder.HasSequence("WIPSEQUENCE").IsCyclic();

        modelBuilder.Entity<CustEqpSptDatum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CUST_EQP_SPT_DATA");

            entity.Property(e => e.Capability)
                .HasColumnType("NUMBER")
                .HasColumnName("CAPABILITY");
            entity.Property(e => e.Capacity)
                .HasColumnType("NUMBER")
                .HasColumnName("CAPACITY");
            entity.Property(e => e.Equipmentname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENTNAME");
            entity.Property(e => e.Isavailable)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ISAVAILABLE");
            entity.Property(e => e.Modifytime)
                .HasMaxLength(24)
                .IsUnicode(false)
                .HasColumnName("MODIFYTIME");
            entity.Property(e => e.Processunit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("PROCESSUNIT");
            entity.Property(e => e.Spt)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SPT");
            entity.Property(e => e.Sptd)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SPTD");
            entity.Property(e => e.Sptstate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SPTSTATE");
            entity.Property(e => e.Stepname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("STEPNAME");
        });
        modelBuilder.HasSequence("CORESEQUENCE");
        modelBuilder.HasSequence("EQPSEQUENCE");
        modelBuilder.HasSequence("NEWCORESEQUENCE").IsCyclic();
        modelBuilder.HasSequence("NEWEQPSEQUENCE").IsCyclic();
        modelBuilder.HasSequence("PARTITIONSEQUENCE");
        modelBuilder.HasSequence("WIPSEQUENCE").IsCyclic();

    

    modelBuilder.Entity<FwProcessSpec>(entity =>
        {
            entity.HasKey(e => new { e.PROCESS, e.Processver, e.Stepseq, e.Deletestep });

            entity.ToTable("FW_PROCESS_SPEC");

            entity.Property(e => e.PROCESS)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Processver)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PROCESSVER");
            entity.Property(e => e.Stepseq)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STEPSEQ");
            entity.Property(e => e.Deletestep)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("DELETESTEP");
            entity.Property(e => e.BackResource)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BACK_RESOURCE");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COMMENTS");
            entity.Property(e => e.Contaminationflag)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CONTAMINATIONFLAG");
            entity.Property(e => e.Dedicationflag)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("DEDICATIONFLAG");
            entity.Property(e => e.Edcplan)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("EDCPLAN");
            entity.Property(e => e.Firstocapstepseq)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("FIRSTOCAPSTEPSEQ");
            entity.Property(e => e.Instruction)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("INSTRUCTION");
            entity.Property(e => e.Maxexectime)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MAXEXECTIME");
            entity.Property(e => e.Maxqueuetime)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MAXQUEUETIME");
            entity.Property(e => e.Maxreworkcnt)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("MAXREWORKCNT");
            entity.Property(e => e.Mergestep)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("MERGESTEP");
            entity.Property(e => e.Monitorwafer)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("MONITORWAFER");
            entity.Property(e => e.PcmEffCores)
                .HasColumnType("NUMBER")
                .HasColumnName("PCM_EFF_CORES");
            entity.Property(e => e.PcmYield)
                .HasColumnType("NUMBER")
                .HasColumnName("PCM_YIELD");
            entity.Property(e => e.PrimResource)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PRIM_RESOURCE");
            entity.Property(e => e.Processtype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Recipe)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("RECIPE");
            entity.Property(e => e.Reticle)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("RETICLE");
            entity.Property(e => e.Runcardinfo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("RUNCARDINFO");
            entity.Property(e => e.Secondocapstepseq)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("SECONDOCAPSTEPSEQ");
            entity.Property(e => e.Stage)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Standardruntime)
                .HasPrecision(4)
                .HasColumnName("STANDARDRUNTIME");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Step)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STEP");
            entity.Property(e => e.Stepcapability)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("STEPCAPABILITY");
            entity.Property(e => e.Stepdescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STEPDESCRIPTION");
            entity.Property(e => e.Stephandle)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STEPHANDLE");
            entity.Property(e => e.Stocker)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STOCKER");
            entity.Property(e => e.Subplan)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("SUBPLAN");
            entity.Property(e => e.Thirdocapstepseq)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("THIRDOCAPSTEPSEQ");
            entity.Property(e => e.Workarea)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("WORKAREA");
        });
        modelBuilder.HasSequence("CORESEQUENCE");
        modelBuilder.HasSequence("EQPSEQUENCE");
        modelBuilder.HasSequence("NEWCORESEQUENCE").IsCyclic();
        modelBuilder.HasSequence("NEWEQPSEQUENCE").IsCyclic();
        modelBuilder.HasSequence("PARTITIONSEQUENCE");
        modelBuilder.HasSequence("WIPSEQUENCE").IsCyclic();



    modelBuilder.Entity<Fwlot>(entity =>
        {
            entity.HasKey(e => e.Sysid).HasName("SYS_C007687");

            entity.ToTable("FWLOT");

            entity.HasIndex(e => e.Processingstatus, "PROCESSINGSTATUS_0E31");

            entity.HasIndex(e => e.Appid, "SYS_C007688").IsUnique();

            entity.Property(e => e.Sysid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("SYSID");
            entity.Property(e => e.Appid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("APPID");
            entity.Property(e => e.Capacityqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CAPACITYQTY");
            entity.Property(e => e.Componentqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("COMPONENTQTY");
            entity.Property(e => e.Componentunits)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COMPONENTUNITS");
            entity.Property(e => e.Constructtype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("CONSTRUCTTYPE");
            entity.Property(e => e.Defectcomponentqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DEFECTCOMPONENTQTY");
            entity.Property(e => e.Duedate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DUEDATE");
            entity.Property(e => e.Futureactions)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("FUTUREACTIONS");
            entity.Property(e => e.Fwtimestamp)
                .HasPrecision(10)
                .HasColumnName("FWTIMESTAMP");
            entity.Property(e => e.Holdstate)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("HOLDSTATE");
            entity.Property(e => e.Lastlocation)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LASTLOCATION");
            entity.Property(e => e.Laststepid)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("LASTSTEPID");
            entity.Property(e => e.Lasttransactiontime)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LASTTRANSACTIONTIME");
            entity.Property(e => e.Lasttxnid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("LASTTXNID");
            entity.Property(e => e.Lottype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Numchildren)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("NUMCHILDREN");
            entity.Property(e => e.Ordernumber)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("ORDERNUMBER");
            entity.Property(e => e.Partprogid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PARTPROGID");
            entity.Property(e => e.Planname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PLANNAME");
            entity.Property(e => e.Planrevision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PLANREVISION");
            entity.Property(e => e.Priority)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRIORITY");
            entity.Property(e => e.Processingstatus)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PROCESSINGSTATUS");
            entity.Property(e => e.Processspeed)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PROCESSSPEED");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Productrevision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRODUCTREVISION");
            entity.Property(e => e.Reworkcounter)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("REWORKCOUNTER");
            entity.Property(e => e.Scheduledcompletedate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SCHEDULEDCOMPLETEDATE");
            entity.Property(e => e.Startcomponentqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STARTCOMPONENTQTY");
            entity.Property(e => e.Startdate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("STARTDATE");
            entity.Property(e => e.Starttime)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("STARTTIME");
            entity.Property(e => e.Subcomptotalqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("SUBCOMPTOTALQTY");
            entity.Property(e => e.Trackouttime)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TRACKOUTTIME");
            entity.Property(e => e.Transportid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TRANSPORTID");
            entity.Property(e => e.Unittrace)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UNITTRACE");
            entity.Property(e => e.Vendorid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("VENDORID");
            entity.Property(e => e.Vendorlotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("VENDORLOTID");
        });
        modelBuilder.HasSequence("CORESEQUENCE");
        modelBuilder.HasSequence("EQPSEQUENCE");
        modelBuilder.HasSequence("NEWCORESEQUENCE").IsCyclic();
        modelBuilder.HasSequence("NEWEQPSEQUENCE").IsCyclic();
        modelBuilder.HasSequence("PARTITIONSEQUENCE");
        modelBuilder.HasSequence("WIPSEQUENCE").IsCyclic();

        modelBuilder.Entity<Fwproductversion>(entity =>
        {
            entity.HasKey(e => e.Sysid).HasName("SYS_C007414");

            entity.ToTable("FWPRODUCTVERSION");

            entity.Property(e => e.Sysid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("SYSID");
            entity.Property(e => e.Currenthistory)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CURRENTHISTORY");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Historyhasbeensuppressed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("HISTORYHASBEENSUPPRESSED");
            entity.Property(e => e.Historyissuppressed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("HISTORYISSUPPRESSED");
            entity.Property(e => e.Id)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("ID");
            entity.Property(e => e.Owner)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("OWNER");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Revision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("REVISION");
            entity.Property(e => e.Revstate)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("REVSTATE");
        });
        modelBuilder.HasSequence("CORESEQUENCE");
        modelBuilder.HasSequence("EQPSEQUENCE");
        modelBuilder.HasSequence("NEWCORESEQUENCE").IsCyclic();
        modelBuilder.HasSequence("NEWEQPSEQUENCE").IsCyclic();
        modelBuilder.HasSequence("PARTITIONSEQUENCE");
        modelBuilder.HasSequence("WIPSEQUENCE").IsCyclic();

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
