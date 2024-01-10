using webapi.Entity.Rxrep;
using Microsoft.EntityFrameworkCore;
using webapi.Model;

namespace webapi.Models;

public partial class RxrepContext : DbContext
{
    public RxrepContext()
    {
    }

    public RxrepContext(DbContextOptions<RxrepContext> options)
        : base(options)
    {
    }

    public virtual DbSet<WtDynamicctreport> WtDynamicctreports { get; set; }
    public virtual DbSet<VMfgHoldLastest> VMfgHoldLastests { get; set; }
    public virtual DbSet<RptScrap> RptScraps { get; set; }
    public virtual DbSet<VOeeSumV2011> VOeeSumV2011s { get; set; }
    public virtual DbSet<CostScrap0> CostScrap0s { get; set; }
    public virtual DbSet<RepEqpsStartEnd> RepEqpsStartEnds { get; set; }
    public virtual DbSet<RptWaferStart> RptWaferStarts { get; set; }
    public virtual DbSet<RptWipTrackout> RptWipTrackouts { get; set; }
    public virtual DbSet<RptLotFinish> RptLotFinishes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.163.76.4)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=RXREPT)));User Id=rxrep;Password=rxrep;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RXREP")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<RptScrap>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RPT_SCRAP");

            entity.HasIndex(e => new { e.Wipid, e.Process, e.Processver, e.Stepseq }, "I_RPT_SCRAP_1");

            entity.HasIndex(e => e.Scrapsysid, "I_RPT_SCRAP_3");

            entity.HasIndex(e => new { e.Wipid, e.Scrapdate }, "PK_RPT_SCRAP").IsUnique();

            entity.Property(e => e.AbnormDept1)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ABNORM_DEPT1");
            entity.Property(e => e.AbnormDept2)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ABNORM_DEPT2");
            entity.Property(e => e.AbnormReason)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ABNORM_REASON");
            entity.Property(e => e.AbnormScarp2)
                .HasColumnType("NUMBER")
                .HasColumnName("ABNORM_SCARP2");
            entity.Property(e => e.AbnormScrap1)
                .HasColumnType("NUMBER")
                .HasColumnName("ABNORM_SCRAP1");
            entity.Property(e => e.Abnormcard)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ABNORMCARD");
            entity.Property(e => e.Briefdescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("BRIEFDESCRIPTION");
            entity.Property(e => e.Cause1)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAUSE1");
            entity.Property(e => e.Cause2)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAUSE2");
            entity.Property(e => e.Commentcode)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("COMMENTCODE");
            entity.Property(e => e.Detaileddescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DETAILEDDESCRIPTION");
            entity.Property(e => e.Engabnormequip)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ENGABNORMEQUIP");
            entity.Property(e => e.Enganalyze)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("ENGANALYZE");
            entity.Property(e => e.Engdescription)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("ENGDESCRIPTION");
            entity.Property(e => e.Equipname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("EQUIPNAME");
            entity.Property(e => e.Flowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("FLOWSTEP");
            entity.Property(e => e.Lotcomment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LOTCOMMENT");
            entity.Property(e => e.Lotowner)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("LOTOWNER");
            entity.Property(e => e.Lotquantity)
                .HasColumnType("NUMBER")
                .HasColumnName("LOTQUANTITY");
            entity.Property(e => e.Lott)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("LOTT");
            entity.Property(e => e.Lottype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Maxflowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("MAXFLOWSTEP");
            entity.Property(e => e.Occursinstep)
                .HasMaxLength(51)
                .IsUnicode(false)
                .HasColumnName("OCCURSINSTEP");
            entity.Property(e => e.Pcmflag)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PCMFLAG");
            entity.Property(e => e.Pday)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("PDAY");
            entity.Property(e => e.Photosort)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOSORT");
            entity.Property(e => e.Platform)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PLATFORM");
            entity.Property(e => e.Process)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Processflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PROCESSFLAG");
            entity.Property(e => e.Processtype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Processver)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PROCESSVER");
            entity.Property(e => e.Productname)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Prodver)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PRODVER");
            entity.Property(e => e.Pstatus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'")
                .IsFixedLength()
                .HasColumnName("PSTATUS");
            entity.Property(e => e.ScrapReason)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("SCRAP_REASON");
            entity.Property(e => e.ScrapWaferno)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("SCRAP_WAFERNO");
            entity.Property(e => e.Scrapdate)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SCRAPDATE");
            entity.Property(e => e.Scrapqty)
                .HasColumnType("NUMBER")
                .HasColumnName("SCRAPQTY");
            entity.Property(e => e.Scrapqty1)
                .HasColumnType("NUMBER")
                .HasColumnName("SCRAPQTY1");
            entity.Property(e => e.Scrapsysid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("SCRAPSYSID");
            entity.Property(e => e.Scraptype)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SCRAPTYPE");
            entity.Property(e => e.Stage)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Stepseq)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STEPSEQ");
            entity.Property(e => e.Ttphotos)
                .HasColumnType("NUMBER")
                .HasColumnName("TTPHOTOS");
            entity.Property(e => e.Userid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("USERID");
            entity.Property(e => e.Username)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
            entity.Property(e => e.Wipid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("WIPID");
            entity.Property(e => e.Wono)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("WONO");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

        modelBuilder.Entity<VOeeSumV2011>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_OEE_SUM_V2011");

            entity.Property(e => e.Attr1)
                .HasColumnType("NUMBER")
                .HasColumnName("ATTR1");
            entity.Property(e => e.Avai)
                .HasColumnType("NUMBER")
                .HasColumnName("AVAI");
            entity.Property(e => e.Batchcapacity)
                .HasColumnType("NUMBER")
                .HasColumnName("BATCHCAPACITY");
            entity.Property(e => e.Batchqty)
                .HasColumnType("NUMBER")
                .HasColumnName("BATCHQTY");
            entity.Property(e => e.Capagroup)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAPAGROUP");
            entity.Property(e => e.Downcnt)
                .HasColumnType("NUMBER")
                .HasColumnName("DOWNCNT");
            entity.Property(e => e.DowncntS1)
                .HasColumnType("NUMBER")
                .HasColumnName("DOWNCNT_S1");
            entity.Property(e => e.Eff)
                .HasColumnType("NUMBER")
                .HasColumnName("EFF");
            entity.Property(e => e.Effrun)
                .HasColumnType("NUMBER")
                .HasColumnName("EFFRUN");
            entity.Property(e => e.EqpAttr1)
                .HasColumnType("NUMBER")
                .HasColumnName("EQP_ATTR1");
            entity.Property(e => e.EqpAttr2)
                .HasColumnType("NUMBER")
                .HasColumnName("EQP_ATTR2");
            entity.Property(e => e.Eqptype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("EQPTYPE");
            entity.Property(e => e.EqptypeDesc)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EQPTYPE_DESC");
            entity.Property(e => e.Equipid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("EQUIPID");
            entity.Property(e => e.Facdown)
                .HasColumnType("NUMBER")
                .HasColumnName("FACDOWN");
            entity.Property(e => e.Inqty)
                .HasColumnType("NUMBER")
                .HasColumnName("INQTY");
            entity.Property(e => e.Module)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("MODULE");
            entity.Property(e => e.Otherloss)
                .HasColumnType("NUMBER")
                .HasColumnName("OTHERLOSS");
            entity.Property(e => e.PUph)
                .HasColumnType("NUMBER")
                .HasColumnName("P_UPH");
            entity.Property(e => e.Pday)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PDAY");
            entity.Property(e => e.Qaqty)
                .HasColumnType("NUMBER")
                .HasColumnName("QAQTY");
            entity.Property(e => e.Run01)
                .HasColumnType("NUMBER")
                .HasColumnName("RUN_01");
            entity.Property(e => e.S1).HasColumnType("NUMBER");
            entity.Property(e => e.S2).HasColumnType("NUMBER");
            entity.Property(e => e.S3).HasColumnType("NUMBER");
            entity.Property(e => e.S4).HasColumnType("NUMBER");
            entity.Property(e => e.S5).HasColumnType("NUMBER");
            entity.Property(e => e.S6).HasColumnType("NUMBER");
            entity.Property(e => e.Sptsum)
                .HasColumnType("NUMBER")
                .HasColumnName("SPTSUM");
            entity.Property(e => e.Tt)
                .HasColumnType("NUMBER")
                .HasColumnName("TT");
            entity.Property(e => e.Ttime)
                .HasColumnType("NUMBER")
                .HasColumnName("TTIME");
            entity.Property(e => e.Uptime)
                .HasColumnType("NUMBER")
                .HasColumnName("UPTIME");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

        modelBuilder.Entity<CostScrap0>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("COST_SCRAP0");

            entity.Property(e => e.Lotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Process)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Processver)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PROCESSVER");
            entity.Property(e => e.Productname)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Prodver)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PRODVER");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Scrapdate)
                .HasColumnType("DATE")
                .HasColumnName("SCRAPDATE");
            entity.Property(e => e.Scrapqty)
                .HasColumnType("NUMBER")
                .HasColumnName("SCRAPQTY");
            entity.Property(e => e.Stepseq)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STEPSEQ");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

        modelBuilder.Entity<RepEqpsStartEnd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REP_EQPS_START_END");

            entity.HasIndex(e => new { e.Eqpid, e.Status, e.Changedt }, "REP_EQPS_START_END_IDX1");

            entity.HasIndex(e => new { e.Eqpid, e.Changedt }, "REP_EQPS_START_END_IDX2");

            entity.Property(e => e.Changedt)
                .HasColumnType("DATE")
                .HasColumnName("CHANGEDT");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Eqpid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EQPID");
            entity.Property(e => e.Eqptyp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EQPTYP");
            entity.Property(e => e.Iscr)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'R'\n")
                .HasColumnName("ISCR");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Usetime)
                .HasColumnType("NUMBER")
                .HasColumnName("USETIME");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");


        modelBuilder.Entity<WtDynamicctreport>(entity =>
        {
            entity.HasKey(e => new { e.Period, e.Pdate });

            entity.ToTable("WT_DYNAMICCTREPORT");

            entity.Property(e => e.Period)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("PERIOD");
            entity.Property(e => e.Pdate)
                .HasColumnType("NUMBER")
                .HasColumnName("PDATE");
            entity.Property(e => e.Amove)
                .HasColumnType("NUMBER")
                .HasColumnName("AMOVE");
            entity.Property(e => e.Atr)
                .HasColumnType("NUMBER")
                .HasColumnName("ATR");
            entity.Property(e => e.Awip)
                .HasColumnType("NUMBER")
                .HasColumnName("AWIP");
            entity.Property(e => e.Bankwip)
                .HasColumnType("NUMBER")
                .HasColumnName("BANKWIP");
            entity.Property(e => e.Cttarg)
                .HasColumnType("NUMBER")
                .HasColumnName("CTTARG");
            entity.Property(e => e.Holdwip)
 
                .HasColumnType("NUMBER")
                .HasColumnName("HOLDWIP");
            entity.Property(e => e.Pclip)
                .HasColumnType("NUMBER")
                .HasColumnName("PCLIP");
            entity.Property(e => e.Scrap)
   
                .HasColumnType("NUMBER")
                .HasColumnName("SCRAP");
            entity.Property(e => e.Steplayer)
                .HasColumnType("NUMBER")
                .HasColumnName("STEPLAYER");
            entity.Property(e => e.Steplayernew)
                .HasColumnType("NUMBER")
                .HasColumnName("STEPLAYERNEW");
            entity.Property(e => e.Totct)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTCT");
            entity.Property(e => e.Totmove)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTMOVE");
            entity.Property(e => e.Totnonwbct)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTNONWBCT");
            entity.Property(e => e.Totnonwbmove)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTNONWBMOVE");
            entity.Property(e => e.Totnonwbtr)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTNONWBTR");
            entity.Property(e => e.Tottr)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTTR");
            entity.Property(e => e.Totwip)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTWIP");
            entity.Property(e => e.Totwiplayer)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTWIPLAYER");
            entity.Property(e => e.Trtarg)
                .HasColumnType("NUMBER")
                .HasColumnName("TRTARG");
            entity.Property(e => e.Wareqty)
                .HasColumnType("NUMBER")
                .HasColumnName("WAREQTY");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

     
    modelBuilder.Entity<RptWipTrackout>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("RPT_WIP_TRACKOUT");

            entity.HasIndex(e => new { e.Wipid, e.Trackouttime, e.Lasttrackout }, "I_RPT_WIP_TRACKOUT_01");

            entity.HasIndex(e => e.Grouphistkey, "I_RPT_WIP_TRACKOUT_02");

            entity.HasIndex(e => new { e.Equipname, e.Trackouttime }, "I_RPT_WIP_TRACKOUT_03");

            entity.HasIndex(e => e.Activity, "I_RPT_WIP_TRACKOUT_04");

            entity.HasIndex(e => e.Trackouttime, "I_RPT_WIP_TRACKOUT_05");

            entity.HasIndex(e => e.Repdate, "I_RPT_WIP_TRACKOUT_06");

            entity.Property(e => e.AbcType)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ABC_TYPE");
            entity.Property(e => e.Activity)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ACTIVITY");
            entity.Property(e => e.Batchid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("BATCHID");
            entity.Property(e => e.Custhold)
                .HasColumnType("NUMBER")
                .HasColumnName("CUSTHOLD");
            entity.Property(e => e.Dummyqty)
                .HasColumnType("NUMBER")
                .HasColumnName("DUMMYQTY");
            entity.Property(e => e.Equipgroup)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPGROUP");
            entity.Property(e => e.Equipname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPNAME");
            entity.Property(e => e.Grouphistkey)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("GROUPHISTKEY");
            entity.Property(e => e.Lasttrackout)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LASTTRACKOUT");
            entity.Property(e => e.Lottype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Outflag)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("OUTFLAG");
            entity.Property(e => e.Photoflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PHOTOFLAG");
            entity.Property(e => e.Planname)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PLANNAME");
            entity.Property(e => e.Planversion)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PLANVERSION");
            entity.Property(e => e.Priority)
                .HasColumnType("NUMBER")
                .HasColumnName("PRIORITY");
            entity.Property(e => e.Processflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PROCESSFLAG");
            entity.Property(e => e.Productname)
                .HasMaxLength(102)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Productversion)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("PRODUCTVERSION");
            entity.Property(e => e.Recipe)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("RECIPE");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Reworkflag)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("REWORKFLAG");
            entity.Property(e => e.Rhold)
                .HasColumnType("NUMBER")
                .HasColumnName("RHOLD");
            entity.Property(e => e.Setuptime)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SETUPTIME");
            entity.Property(e => e.Stage)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Stepdescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STEPDESCRIPTION");
            entity.Property(e => e.Stepname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STEPNAME");
            entity.Property(e => e.Stepseq)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STEPSEQ");
            entity.Property(e => e.Stepversion)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("STEPVERSION");
            entity.Property(e => e.Trackinby)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TRACKINBY");
            entity.Property(e => e.Trackinbyid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TRACKINBYID");
            entity.Property(e => e.Trackinqty)
                .HasColumnType("NUMBER")
                .HasColumnName("TRACKINQTY");
            entity.Property(e => e.Trackintime)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TRACKINTIME");
            entity.Property(e => e.Trackoutby)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TRACKOUTBY");
            entity.Property(e => e.Trackoutbyid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("TRACKOUTBYID");
            entity.Property(e => e.Trackoutqty)
                .HasColumnType("NUMBER")
                .HasColumnName("TRACKOUTQTY");
            entity.Property(e => e.Trackouttime)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("TRACKOUTTIME");
            entity.Property(e => e.Tthold)
                .HasColumnType("NUMBER")
                .HasColumnName("TTHOLD");
            entity.Property(e => e.Whold)
                .HasColumnType("NUMBER")
                .HasColumnName("WHOLD");
            entity.Property(e => e.Wipid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("WIPID");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

        modelBuilder.Entity<VMfgHoldLastest>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_MFG_HOLD_LASTEST");

            entity.Property(e => e.Area)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("AREA");
            entity.Property(e => e.Comm)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COMM");
            entity.Property(e => e.Commentcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COMMENTCODE");
            entity.Property(e => e.Equipgroup)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPGROUP");
            entity.Property(e => e.Equipment)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EQUIPMENT");
            entity.Property(e => e.HoldDate)
                .HasColumnType("DATE")
                .HasColumnName("HOLD_DATE");
            entity.Property(e => e.Holdby)
                .HasMaxLength(82)
                .IsUnicode(false)
                .HasColumnName("HOLDBY");
            entity.Property(e => e.Holdcomment0)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOLDCOMMENT0");
            entity.Property(e => e.Holdreason)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOLDREASON");
            entity.Property(e => e.Holdreason0)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOLDREASON0");
            entity.Property(e => e.Layerno)
                .HasColumnType("NUMBER")
                .HasColumnName("LAYERNO");
            entity.Property(e => e.Lotid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Lotowner)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("LOTOWNER");
            entity.Property(e => e.Ordertype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ORDERTYPE");
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
            entity.Property(e => e.Processtype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Productrevision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRODUCTREVISION");
            entity.Property(e => e.Qty)
                .HasColumnType("NUMBER")
                .HasColumnName("QTY");
            entity.Property(e => e.Stage)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Stepdescription)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STEPDESCRIPTION");
            entity.Property(e => e.Stepid)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("STEPID");
            entity.Property(e => e.Stepseq)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STEPSEQ");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

        modelBuilder.Entity<RptLotFinish>(entity =>
        {
            entity.HasKey(e => e.Lotid).HasName("RPT_LOT_FINISH_IDX1");

            entity.ToTable("RPT_LOT_FINISH");

            entity.HasIndex(e => e.Wono, "I_RPT_LOT_FINISH");

            entity.Property(e => e.Lotid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Abctype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABCTYPE");
            entity.Property(e => e.Bank0process)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("BANK0PROCESS");
            entity.Property(e => e.Bank0processver)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("BANK0PROCESSVER");
            entity.Property(e => e.Bankreleasedate)
                .HasColumnType("DATE")
                .HasColumnName("BANKRELEASEDATE");
            entity.Property(e => e.Beflag)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("BEFLAG");
            entity.Property(e => e.Beprocess)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("BEPROCESS");
            entity.Property(e => e.Beprocessver)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("BEPROCESSVER");
            entity.Property(e => e.Createdate)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CREATEDATE");
            entity.Property(e => e.Custhold)
                .HasColumnType("NUMBER")
                .HasColumnName("CUSTHOLD");
            entity.Property(e => e.Custid)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CUSTID");
            entity.Property(e => e.Custprod)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("CUSTPROD");
            entity.Property(e => e.DailyPday)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DAILY_PDAY");
            entity.Property(e => e.Duedate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DUEDATE");
            entity.Property(e => e.Epiouttime)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EPIOUTTIME");
            entity.Property(e => e.Invdate)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("INVDATE");
            entity.Property(e => e.Invqty)
                .HasColumnType("NUMBER")
                .HasColumnName("INVQTY");
            entity.Property(e => e.Isepi)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ISEPI");
            entity.Property(e => e.Layerno)
                .HasColumnType("NUMBER")
                .HasColumnName("LAYERNO");
            entity.Property(e => e.Lotcomment)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOTCOMMENT");
            entity.Property(e => e.Lotowner)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOTOWNER");
            entity.Property(e => e.Lotstartdate)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LOTSTARTDATE");
            entity.Property(e => e.Lottype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Newwono)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("NEWWONO");
            entity.Property(e => e.Ordertype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ORDERTYPE");
            entity.Property(e => e.Outdate)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OUTDATE");
            entity.Property(e => e.Ownerid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("OWNERID");
            entity.Property(e => e.ParCode)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("PAR_CODE");
            entity.Property(e => e.Parentid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PARENTID");
            entity.Property(e => e.Pcmendtime)
                .HasColumnType("DATE")
                .HasColumnName("PCMENDTIME");
            entity.Property(e => e.Pcmholdtimes)
                .HasColumnType("NUMBER")
                .HasColumnName("PCMHOLDTIMES");
            entity.Property(e => e.Planinvdate)
                .HasColumnType("DATE")
                .HasColumnName("PLANINVDATE");
            entity.Property(e => e.Planname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PLANNAME");
            entity.Property(e => e.Planrevision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PLANREVISION");
            entity.Property(e => e.Platform)
                .HasMaxLength(400)
                .IsUnicode(false)
                .HasColumnName("PLATFORM");
            entity.Property(e => e.Plocation)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PLOCATION");
            entity.Property(e => e.Pono)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PONO");
            entity.Property(e => e.Priority)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("PRIORITY");
            entity.Property(e => e.Processtype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Productrevision)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRODUCTREVISION");
            entity.Property(e => e.Qaoutqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("QAOUTQTY");
            entity.Property(e => e.Qaouttime)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("QAOUTTIME");
            entity.Property(e => e.Splitdate)
                .HasColumnType("DATE")
                .HasColumnName("SPLITDATE");
            entity.Property(e => e.Startqty)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("STARTQTY");
            entity.Property(e => e.Totholdtime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTHOLDTIME");
            entity.Property(e => e.Totruntime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTRUNTIME");
            entity.Property(e => e.Totwaittime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTWAITTIME");
            entity.Property(e => e.Tpy)
                .HasColumnType("NUMBER")
                .HasColumnName("TPY");
            entity.Property(e => e.Ttphotos)
                .HasColumnType("NUMBER")
                .HasColumnName("TTPHOTOS");
            entity.Property(e => e.Ttstepcnt)
                .HasColumnType("NUMBER")
                .HasColumnName("TTSTEPCNT");
            entity.Property(e => e.Vflag)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("VFLAG");
            entity.Property(e => e.Wafervendor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("WAFERVENDOR");
            entity.Property(e => e.Wbflag)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("WBFLAG");
            entity.Property(e => e.Wono)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("WONO");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

        modelBuilder.Entity<RptWaferStart>(entity =>
        {
            entity.HasKey(e => e.Appid);

            entity.ToTable("RPT_WAFER_START");

            entity.HasIndex(e => e.Wono, "I_RPT_WAFER_START_WONO");

            entity.Property(e => e.Appid)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("APPID");
            entity.Property(e => e.Abctype)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABCTYPE");
            entity.Property(e => e.DailyPday)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DAILY_PDAY");
            entity.Property(e => e.Layerno)
                .HasColumnType("NUMBER")
                .HasColumnName("LAYERNO");
            entity.Property(e => e.Lotcomment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LOTCOMMENT");
            entity.Property(e => e.Lotcreatedate)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LOTCREATEDATE");
            entity.Property(e => e.Lotstartdate)
                .HasMaxLength(18)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("LOTSTARTDATE");
            entity.Property(e => e.Lottype)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Planname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PLANNAME");
            entity.Property(e => e.Planversion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PLANVERSION");
            entity.Property(e => e.Processtype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Productname)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("PRODUCTNAME");
            entity.Property(e => e.Productversion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRODUCTVERSION");
            entity.Property(e => e.Startqty)
                .HasColumnType("NUMBER")
                .HasColumnName("STARTQTY");
            entity.Property(e => e.Wono)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("WONO");
        });
        modelBuilder.HasSequence("ACTIONSTUDYNO");
        modelBuilder.HasSequence("CPT_SEQ");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_SHIPTONO");
        modelBuilder.HasSequence("CUST_CONSIGNMENT_TONO");
        modelBuilder.HasSequence("DEPT_ONDUTYNO");
        modelBuilder.HasSequence("DEV_MESSAGE_NO");
        modelBuilder.HasSequence("DEVELOP_EQUIP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_EQUIPJOBNO");
        modelBuilder.HasSequence("DEVELOP_ONDUTYNO");
        modelBuilder.HasSequence("DEVELOP_SYS_NO");
        modelBuilder.HasSequence("HEF_PRODUCT_INFO_ID");
        modelBuilder.HasSequence("HFE_LOT_INFO_ID");
        modelBuilder.HasSequence("IFAB_PURVIEWNO");
        modelBuilder.HasSequence("IFAB_UPLOADNO");
        modelBuilder.HasSequence("IFAB_USERNO");
        modelBuilder.HasSequence("IT_WORKPLANNO");
        modelBuilder.HasSequence("MODULE_STEPCODENO");
        modelBuilder.HasSequence("OEE_CAPAGROUP_SNO");
        modelBuilder.HasSequence("PMS_USER_NO");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_ID");
        modelBuilder.HasSequence("REP_FMA_EXAMQUESTION_MA_ID");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
