﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webapi.Entity;
using webapi.Entity.Rxrep2;
using webapi.Model;

namespace webapi.Models;

public partial class Rxrept2Context: DbContext
{
    public Rxrept2Context()
    {
    }

    public Rxrept2Context(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }
    public virtual DbSet<BCapagroupMove> BCapagroupMoves { get; set; }
    public virtual DbSet<RepActlH> RepActlHs { get; set; }

    public virtual DbSet<RepChangepriTmp> RepChangepriTmps { get; set; }
    public virtual DbSet<SpllotDesc> SpllotDescs { get; set; }
    public virtual DbSet<Monthplan> Monthplans { get; set; }
    public virtual DbSet<RepActlHAll> RepActlHAlls { get; set; }
    public virtual DbSet<RepActl15min> RepActl15mins { get; set; }
    public virtual DbSet<Waferstartemailmounth> Waferstartemailmounths { get; set; }
    public virtual DbSet<RepHistTot> RepHistTots { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.163.76.4)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=RXREPT)));User Id=rxrep2;Password=rxrep2;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("RXREP2")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<RepChangepriTmp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REP_CHANGEPRI_TMP");

            entity.HasIndex(e => e.Lotid, "REP_CHANGEPRI_TMP_IDX");

            entity.Property(e => e.Change)
                .HasColumnType("NUMBER")
                .HasColumnName("CHANGE");
            entity.Property(e => e.Diffe)
                .HasColumnType("NUMBER")
                .HasColumnName("DIFFE");
            entity.Property(e => e.Flowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("FLOWSTEP");
            entity.Property(e => e.ForeTheoct)
                .HasColumnType("NUMBER")
                .HasColumnName("FORE_THEOCT");
            entity.Property(e => e.Foretime)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME");
            entity.Property(e => e.Foretime1)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME1");
            entity.Property(e => e.Foretime2)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME2");
            entity.Property(e => e.Lotid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.NowTheoct)
                .HasColumnType("NUMBER")
                .HasColumnName("NOW_THEOCT");
            entity.Property(e => e.Outdate)
                .HasColumnType("DATE")
                .HasColumnName("OUTDATE");
            entity.Property(e => e.Partid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PARTID");
            entity.Property(e => e.Partname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("PARTNAME");
            entity.Property(e => e.Ppforetime)
                .HasColumnType("DATE")
                .HasColumnName("PPFORETIME");
            entity.Property(e => e.Qty)
                .HasColumnType("NUMBER")
                .HasColumnName("QTY");
            entity.Property(e => e.Ratio)
                .HasColumnType("NUMBER")
                .HasColumnName("RATIO");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Reqdtime)
                .HasColumnType("DATE")
                .HasColumnName("REQDTIME");
            entity.Property(e => e.Stage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Stageratio)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGERATIO");
            entity.Property(e => e.Starttime)
                .HasColumnType("DATE")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.TotTheoct)
                .HasColumnType("NUMBER")
                .HasColumnName("TOT_THEOCT");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");


        modelBuilder.Entity<SpllotDesc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SPLLOT_DESC");

            entity.Property(e => e.Department)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT");
            entity.Property(e => e.Dotime)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DOTIME");
            entity.Property(e => e.Lotid)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Userdesc)
                .HasMaxLength(510)
                .IsUnicode(false)
                .HasColumnName("USERDESC");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");

        modelBuilder.Entity<Monthplan>(entity =>
        {
            entity.HasKey(e => new { e.Process, e.Dept }).HasName("PK_PROCESS_DEPT");

            entity.ToTable("MONTHPLAN");

            entity.Property(e => e.Process)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Dept)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPT");
            entity.Property(e => e.Day1)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY1");
            entity.Property(e => e.Day10)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY10");
            entity.Property(e => e.Day11)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY11");
            entity.Property(e => e.Day12)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY12");
            entity.Property(e => e.Day13)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY13");
            entity.Property(e => e.Day14)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY14");
            entity.Property(e => e.Day15)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY15");
            entity.Property(e => e.Day16)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY16");
            entity.Property(e => e.Day17)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY17");
            entity.Property(e => e.Day18)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY18");
            entity.Property(e => e.Day19)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY19");
            entity.Property(e => e.Day2)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY2");
            entity.Property(e => e.Day20)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY20");
            entity.Property(e => e.Day21)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY21");
            entity.Property(e => e.Day22)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY22");
            entity.Property(e => e.Day23)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY23");
            entity.Property(e => e.Day24)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY24");
            entity.Property(e => e.Day25)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY25");
            entity.Property(e => e.Day26)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY26");
            entity.Property(e => e.Day27)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY27");
            entity.Property(e => e.Day28)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY28");
            entity.Property(e => e.Day29)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY29");
            entity.Property(e => e.Day3)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY3");
            entity.Property(e => e.Day30)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY30");
            entity.Property(e => e.Day31)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY31");
            entity.Property(e => e.Day4)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY4");
            entity.Property(e => e.Day5)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY5");
            entity.Property(e => e.Day6)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY6");
            entity.Property(e => e.Day7)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY7");
            entity.Property(e => e.Day8)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY8");
            entity.Property(e => e.Day9)
                .HasColumnType("NUMBER")
                .HasColumnName("DAY9");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");


        modelBuilder.Entity<Waferstartemailmounth>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("WAFERSTARTEMAILMOUNTH");

            entity.HasIndex(e => e.Product, "PRODUCT").IsUnique();

            entity.Property(e => e.Bppcs)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("BPPCS");
            entity.Property(e => e.Bpwsaccplan)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("BPWSACCPLAN");
            entity.Property(e => e.Cap)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("CAP");
            entity.Property(e => e.Daigon)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DAIGON");
            entity.Property(e => e.Mfpcs)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("MFPCS");
            entity.Property(e => e.Process)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Product)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PRODUCT");
            entity.Property(e => e.Stage)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Wsaccplan)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("WSACCPLAN");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");

        modelBuilder.Entity<BCapagroupMove>(entity =>
        {
            entity.HasKey(e => new { e.Capagroup, e.Equipid }).HasName("B_CAPAGROUP_MOVE_PK");

            entity.ToTable("B_CAPAGROUP_MOVE");

            entity.Property(e => e.Capagroup)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CAPAGROUP");
            entity.Property(e => e.Equipid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EQUIPID");
            entity.Property(e => e.Iskey)
                .HasColumnType("NUMBER")
                .HasColumnName("ISKEY");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");

        modelBuilder.Entity<RepActlHAll>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REP_ACTL_H_ALL");

            entity.HasIndex(e => e.Lotid, "REP_ACTL_H_ALL_IDX1").IsUnique();

            entity.Property(e => e.Alterday)
                .HasColumnType("NUMBER")
                .HasColumnName("ALTERDAY");
            entity.Property(e => e.CapaGroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CAPA_GROUP");
            entity.Property(e => e.Capability)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAPABILITY");
            entity.Property(e => e.Class1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS1");
            entity.Property(e => e.Class2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS2");
            entity.Property(e => e.Class3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS3");
            entity.Property(e => e.Class4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS4");
            entity.Property(e => e.Cr1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CR1");
            entity.Property(e => e.Cr2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CR2");
            entity.Property(e => e.Cr3)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CR3");
            entity.Property(e => e.Createtime)
                .HasColumnType("DATE")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Curmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("CURMAINQTY");
            entity.Property(e => e.Curprcdcurinstnum)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CURPRCDCURINSTNUM");
            entity.Property(e => e.Curprcdid)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CURPRCDID");
            entity.Property(e => e.Curprcdname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("CURPRCDNAME");
            entity.Property(e => e.Customername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERNAME");
            entity.Property(e => e.Custordernumber)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CUSTORDERNUMBER");
            entity.Property(e => e.Empidtrackin)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKIN");
            entity.Property(e => e.Empidtrackout)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKOUT");
            entity.Property(e => e.Endmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("ENDMAINQTY");
            entity.Property(e => e.Endtime)
                .HasColumnType("DATE")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Engineer)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ENGINEER");
            entity.Property(e => e.Eqpid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("EQPID");
            entity.Property(e => e.Eqptype)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("EQPTYPE");
            entity.Property(e => e.Flag)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FLAG");
            entity.Property(e => e.Flowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("FLOWSTEP");
            entity.Property(e => e.Foretime)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME");
            entity.Property(e => e.Foretime1)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME1");
            entity.Property(e => e.Foretime2)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME2");
            entity.Property(e => e.G6g7)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("G6G7");
            entity.Property(e => e.Holdcode)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("HOLDCODE");
            entity.Property(e => e.Holdcode1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HOLDCODE1");
            entity.Property(e => e.Holdreas)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOLDREAS");
            entity.Property(e => e.Holdtimes)
                .HasColumnType("NUMBER")
                .HasColumnName("HOLDTIMES");
            entity.Property(e => e.Holdtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOLDTYPE");
            entity.Property(e => e.Holduser)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("HOLDUSER");
            entity.Property(e => e.Jyb)
                .HasColumnType("NUMBER")
                .HasColumnName("JYB");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Locationtype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LOCATIONTYPE");
            entity.Property(e => e.Lotcmnt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOTCMNT");
            entity.Property(e => e.Lotid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Lotparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("LOTPARMCOUNT");
            entity.Property(e => e.Lottype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Maxflowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("MAXFLOWSTEP");
            entity.Property(e => e.ModifyReqdtime)
                .HasColumnType("DATE")
                .HasColumnName("MODIFY_REQDTIME");
            entity.Property(e => e.Module)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MODULE");
            entity.Property(e => e.NewQueuetime)
                .HasColumnType("DATE")
                .HasColumnName("NEW_QUEUETIME");
            entity.Property(e => e.Newpriority)
                .HasColumnType("NUMBER")
                .HasColumnName("NEWPRIORITY");
            entity.Property(e => e.OldOutdate)
                .HasColumnType("DATE")
                .HasColumnName("OLD_OUTDATE");
            entity.Property(e => e.Outdate)
                .HasColumnType("DATE")
                .HasColumnName("OUTDATE");
            entity.Property(e => e.Parentid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PARENTID");
            entity.Property(e => e.Partid)
                .HasMaxLength(61)
                .IsUnicode(false)
                .HasColumnName("PARTID");
            entity.Property(e => e.Partname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("PARTNAME");
            entity.Property(e => e.Partversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PARTVERSION");
            entity.Property(e => e.Pcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PCODE");
            entity.Property(e => e.Photomax)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOMAX");
            entity.Property(e => e.Photosort)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOSORT");
            entity.Property(e => e.Prcdstarttime)
                .HasColumnType("DATE")
                .HasColumnName("PRCDSTARTTIME");
            entity.Property(e => e.Priority)
                .HasColumnType("NUMBER")
                .HasColumnName("PRIORITY");
            entity.Property(e => e.Process)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Processtype)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Prodstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRODSTAGE");
            entity.Property(e => e.ProdstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODSTAGE_SORT");
            entity.Property(e => e.Queuetime)
                .HasColumnType("DATE")
                .HasColumnName("QUEUETIME");
            entity.Property(e => e.Recpid)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("RECPID");
            entity.Property(e => e.Recpname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("RECPNAME");
            entity.Property(e => e.Recpversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("RECPVERSION");
            entity.Property(e => e.Reference)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("REFERENCE");
            entity.Property(e => e.Reltime)
                .HasColumnType("DATE")
                .HasColumnName("RELTIME");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Replott)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("REPLOTT");
            entity.Property(e => e.Repstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("REPSTAGE");
            entity.Property(e => e.RepstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("REPSTAGE_SORT");
            entity.Property(e => e.Reqdtime)
                .HasColumnType("DATE")
                .HasColumnName("REQDTIME");
            entity.Property(e => e.Reqdtime1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("REQDTIME1");
            entity.Property(e => e.Reworkcyclecount)
                .HasColumnType("NUMBER")
                .HasColumnName("REWORKCYCLECOUNT");
            entity.Property(e => e.Setparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("SETPARMCOUNT");
            entity.Property(e => e.Stage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Stageheldtime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGEHELDTIME");
            entity.Property(e => e.Stageruntime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGERUNTIME");
            entity.Property(e => e.Stagestarttime)
                .HasColumnType("DATE")
                .HasColumnName("STAGESTARTTIME");
            entity.Property(e => e.Stagewaittime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGEWAITTIME");
            entity.Property(e => e.Startmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("STARTMAINQTY");
            entity.Property(e => e.Starttime)
                .HasColumnType("DATE")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.State)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.Stateentrytime)
                .HasColumnType("DATE")
                .HasColumnName("STATEENTRYTIME");
            entity.Property(e => e.Taxis)
                .HasColumnType("NUMBER")
                .HasColumnName("TAXIS");
            entity.Property(e => e.Tempparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("TEMPPARMCOUNT");
            entity.Property(e => e.Theoct)
                .HasColumnType("NUMBER")
                .HasColumnName("THEOCT");
            entity.Property(e => e.Totalheldtime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALHELDTIME");
            entity.Property(e => e.Totalruntime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALRUNTIME");
            entity.Property(e => e.Totalwaittime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALWAITTIME");
            entity.Property(e => e.Trackinmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("TRACKINMAINQTY");
            entity.Property(e => e.Trackintime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKINTIME");
            entity.Property(e => e.Trackouttime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKOUTTIME");
            entity.Property(e => e.Type)
                .HasColumnType("NUMBER")
                .HasColumnName("TYPE");
            entity.Property(e => e.Vflag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VFLAG");
            entity.Property(e => e.Waittime)
                .HasColumnType("NUMBER")
                .HasColumnName("WAITTIME");
            entity.Property(e => e.YellowLabel)
                .HasColumnType("DATE")
                .HasColumnName("YELLOW_LABEL");
            entity.Property(e => e.YellowLabel2)
                .HasColumnType("DATE")
                .HasColumnName("YELLOW_LABEL2");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");


        modelBuilder.Entity<RepActlH>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REP_ACTL_H");

            entity.HasIndex(e => e.Lotid, "REP_ACTL_H_IDX1");

            entity.HasIndex(e => e.Stage, "REP_ACTL_H_IDX2");

            entity.HasIndex(e => e.Processtype, "REP_ACTL_H_IDX3");

            entity.HasIndex(e => e.Repstage, "REP_ACTL_H_IDX4");

            entity.HasIndex(e => e.Module, "REP_ACTL_H_IDX5");

            entity.HasIndex(e => e.Priority, "REP_ACTL_H_IDX6");

            entity.HasIndex(e => new { e.Priority, e.Recpname }, "REP_ACTL_H_IDX7");

            entity.HasIndex(e => new { e.Priority, e.Recpname, e.Partname }, "REP_ACTL_H_IDX8");

            entity.Property(e => e.Callprcdid)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CALLPRCDID");
            entity.Property(e => e.CapaGroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CAPA_GROUP");
            entity.Property(e => e.Capability)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAPABILITY");
            entity.Property(e => e.Class1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS1");
            entity.Property(e => e.Class2)
                .HasMaxLength(20)
                .HasColumnName("CLASS2");
            entity.Property(e => e.Class3)
                .HasMaxLength(20)

                .HasColumnName("CLASS3");
            entity.Property(e => e.Class4)
                .HasMaxLength(20)

                .HasColumnName("CLASS4");
            entity.Property(e => e.Cr1)
                .HasMaxLength(20)

                .HasColumnName("CR1");
            entity.Property(e => e.Cr2)
                .HasMaxLength(100)

                .HasColumnName("CR2");
            entity.Property(e => e.Cr3)
                .HasMaxLength(45)

                .HasColumnName("CR3");
            entity.Property(e => e.Createtime)
                .HasColumnType("DATE")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Curmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("CURMAINQTY");
            entity.Property(e => e.Curprcdcurinstnum)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CURPRCDCURINSTNUM");
            entity.Property(e => e.Curprcdname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("CURPRCDNAME");
            entity.Property(e => e.Customername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERNAME");
            entity.Property(e => e.Custordernumber)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CUSTORDERNUMBER");
            entity.Property(e => e.Empidtrackin)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKIN");
            entity.Property(e => e.Empidtrackout)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKOUT");
            entity.Property(e => e.Endmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("ENDMAINQTY");
            entity.Property(e => e.Endtime)
                .HasColumnType("DATE")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Engineer)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ENGINEER");
            entity.Property(e => e.Eqpid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EQPID");
            entity.Property(e => e.Eqptype)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("EQPTYPE");
            entity.Property(e => e.Flag)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FLAG");
            entity.Property(e => e.Flowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("FLOWSTEP");
            entity.Property(e => e.ForecastType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FORECAST_TYPE");
            entity.Property(e => e.Foretime)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME");
            entity.Property(e => e.Foretime1)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME1");
            entity.Property(e => e.Foretime2)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME2");
            entity.Property(e => e.G6g7)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("G6G7");
            entity.Property(e => e.Holdcode)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("HOLDCODE");
            entity.Property(e => e.Holdcode1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HOLDCODE1");
            entity.Property(e => e.Holdreas)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOLDREAS");
            entity.Property(e => e.Holdtimes)
                .HasColumnType("NUMBER")
                .HasColumnName("HOLDTIMES");
            entity.Property(e => e.Holdtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOLDTYPE");
            entity.Property(e => e.Holduser)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("HOLDUSER");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Locationtype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LOCATIONTYPE");
            entity.Property(e => e.LotLevel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOT_LEVEL");
            entity.Property(e => e.Lotcmnt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOTCMNT");
            entity.Property(e => e.Lotid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Lotparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("LOTPARMCOUNT");
            entity.Property(e => e.Lottype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Maxflowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("MAXFLOWSTEP");
            entity.Property(e => e.ModifyReqdtime)
                .HasColumnType("DATE")
                .HasColumnName("MODIFY_REQDTIME");
            entity.Property(e => e.Module)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MODULE");
            entity.Property(e => e.NewQueuetime)
                .HasColumnType("DATE")
                .HasColumnName("NEW_QUEUETIME");
            entity.Property(e => e.NewQueuetimeDevfabhold)
                .HasColumnType("DATE")
                .HasColumnName("NEW_QUEUETIME_DEVFABHOLD");
            entity.Property(e => e.Newpriority)
                .HasColumnType("NUMBER")
                .HasColumnName("NEWPRIORITY");
            entity.Property(e => e.Outdate)
                .HasColumnType("DATE")
                .HasColumnName("OUTDATE");
            entity.Property(e => e.Parentid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PARENTID");
            entity.Property(e => e.Partid)
                .HasMaxLength(61)
                .IsUnicode(false)
                .HasColumnName("PARTID");
            entity.Property(e => e.Partname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("PARTNAME");
            entity.Property(e => e.Partversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PARTVERSION");
            entity.Property(e => e.Pcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PCODE");
            entity.Property(e => e.Photomax)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOMAX");
            entity.Property(e => e.Photosort)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOSORT");
            entity.Property(e => e.Prcdstarttime)
                .HasColumnType("DATE")
                .HasColumnName("PRCDSTARTTIME");
            entity.Property(e => e.Priority)
                .HasColumnType("NUMBER")
                .HasColumnName("PRIORITY");
            entity.Property(e => e.Process)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Processtype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Prodstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRODSTAGE");
            entity.Property(e => e.ProdstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODSTAGE_SORT");
            entity.Property(e => e.Queuetime)
                .HasColumnType("DATE")
                .HasColumnName("QUEUETIME");
            entity.Property(e => e.Ratio)
                .HasColumnType("NUMBER")
                .HasColumnName("RATIO");
            entity.Property(e => e.Recpid)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("RECPID");
            entity.Property(e => e.Recpname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("RECPNAME");
            entity.Property(e => e.Recpversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("RECPVERSION");
            entity.Property(e => e.Reference)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("REFERENCE");
            entity.Property(e => e.Reltime)
                .HasColumnType("DATE")
                .HasColumnName("RELTIME");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Replott)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("REPLOTT");
            entity.Property(e => e.Repstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("REPSTAGE");
            entity.Property(e => e.RepstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("REPSTAGE_SORT");
            entity.Property(e => e.Reqdtime)
                .HasColumnType("DATE")
                .HasColumnName("REQDTIME");
            entity.Property(e => e.Reworkcyclecount)
                .HasColumnType("NUMBER")
                .HasColumnName("REWORKCYCLECOUNT");
            entity.Property(e => e.Setparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("SETPARMCOUNT");
            entity.Property(e => e.Stage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Stageheldtime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGEHELDTIME");
            entity.Property(e => e.Stageruntime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGERUNTIME");
            entity.Property(e => e.Stagestarttime)
                .HasColumnType("DATE")
                .HasColumnName("STAGESTARTTIME");
            entity.Property(e => e.Stagewaittime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGEWAITTIME");
            entity.Property(e => e.Startmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("STARTMAINQTY");
            entity.Property(e => e.Starttime)
                .HasColumnType("DATE")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.Stateentrytime)
                .HasColumnType("DATE")
                .HasColumnName("STATEENTRYTIME");
            entity.Property(e => e.Taxis)
                .HasColumnType("NUMBER")
                .HasColumnName("TAXIS");
            entity.Property(e => e.Tempparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("TEMPPARMCOUNT");
            entity.Property(e => e.Theoct)
                .HasColumnType("NUMBER")
                .HasColumnName("THEOCT");
            entity.Property(e => e.TodayMoves)
                .HasColumnType("NUMBER")
                .HasColumnName("TODAY_MOVES");
            entity.Property(e => e.TodayPlansteps)
                .HasColumnType("NUMBER")
                .HasColumnName("TODAY_PLANSTEPS");
            entity.Property(e => e.TodaySteps)
                .HasColumnType("NUMBER")
                .HasColumnName("TODAY_STEPS");
            entity.Property(e => e.Totalheldtime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALHELDTIME");
            entity.Property(e => e.Totalruntime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALRUNTIME");
            entity.Property(e => e.Totalwaittime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALWAITTIME");
            entity.Property(e => e.Trackinmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("TRACKINMAINQTY");
            entity.Property(e => e.Trackintime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKINTIME");
            entity.Property(e => e.Trackouttime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKOUTTIME");
            entity.Property(e => e.Type)
                .HasColumnType("NUMBER")
                .HasColumnName("TYPE");
            entity.Property(e => e.Vflag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VFLAG");
            entity.Property(e => e.YesterdayPlansteps)
                .HasColumnType("NUMBER")
                .HasColumnName("YESTERDAY_PLANSTEPS");
            entity.Property(e => e.YesterdaySteps)
                .HasColumnType("NUMBER")
                .HasColumnName("YESTERDAY_STEPS");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");

        modelBuilder.Entity<RepHistTot>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REP_HIST_TOT");

            entity.Property(e => e.BatchFlag)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("BATCH_FLAG");
            entity.Property(e => e.Callprcdid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CALLPRCDID");
            entity.Property(e => e.CapaGroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CAPA_GROUP");
            entity.Property(e => e.Capability)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAPABILITY");
            entity.Property(e => e.Class1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLASS1");
            entity.Property(e => e.Class2)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLASS2");
            entity.Property(e => e.Class3)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLASS3");
            entity.Property(e => e.Class4)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLASS4");
            entity.Property(e => e.Curmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("CURMAINQTY");
            entity.Property(e => e.Curprcdcurinstnum)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("CURPRCDCURINSTNUM");
            entity.Property(e => e.Curprcdstage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CURPRCDSTAGE");
            entity.Property(e => e.Curreworkmattype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("CURREWORKMATTYPE");
            entity.Property(e => e.Cursubqty)
                .HasColumnType("NUMBER")
                .HasColumnName("CURSUBQTY");
            entity.Property(e => e.Cushold)
                .HasColumnType("NUMBER")
                .HasColumnName("CUSHOLD");
            entity.Property(e => e.Empidtrackin)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKIN");
            entity.Property(e => e.Empidtrackout)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKOUT");
            entity.Property(e => e.Endrecptime)
                .HasColumnType("DATE")
                .HasColumnName("ENDRECPTIME");
            entity.Property(e => e.Eqpid)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("EQPID");
            entity.Property(e => e.Eqptype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("EQPTYPE");
            entity.Property(e => e.Evcount)
                .HasColumnType("NUMBER")
                .HasColumnName("EVCOUNT");
            entity.Property(e => e.Histkey)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("HISTKEY");
            entity.Property(e => e.Histtime)
                .HasColumnType("DATE")
                .HasColumnName("HISTTIME");
            entity.Property(e => e.Lastevendmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("LASTEVENDMAINQTY");
            entity.Property(e => e.Lastevstate)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LASTEVSTATE");
            entity.Property(e => e.Lastevtime)
                .HasColumnType("DATE")
                .HasColumnName("LASTEVTIME");
            entity.Property(e => e.Lastevtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("LASTEVTYPE");
            entity.Property(e => e.Lastevuser)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("LASTEVUSER");
            entity.Property(e => e.Lastevvariant)
                .HasMaxLength(67)
                .IsUnicode(false)
                .HasColumnName("LASTEVVARIANT");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Locationtype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LOCATIONTYPE");
            entity.Property(e => e.Lotid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Lottype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Maxflowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("MAXFLOWSTEP");
            entity.Property(e => e.ModifyReqdtime)
                .HasColumnType("DATE")
                .HasColumnName("MODIFY_REQDTIME");
            entity.Property(e => e.Module)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODULE");
            entity.Property(e => e.Newpriority)
                .HasColumnType("NUMBER")
                .HasColumnName("NEWPRIORITY");
            entity.Property(e => e.Nextstep)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("NEXTSTEP");
            entity.Property(e => e.Outdate)
                .HasColumnType("DATE")
                .HasColumnName("OUTDATE");
            entity.Property(e => e.Parentid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PARENTID");
            entity.Property(e => e.Partid)
                .HasMaxLength(62)
                .IsUnicode(false)
                .HasColumnName("PARTID");
            entity.Property(e => e.Partname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("PARTNAME");
            entity.Property(e => e.Partversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PARTVERSION");
            entity.Property(e => e.Pcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PCODE");
            entity.Property(e => e.PhotoMax)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTO_MAX");
            entity.Property(e => e.PhotoSort)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTO_SORT");
            entity.Property(e => e.Prcdkey)
                .HasMaxLength(39)
                .IsUnicode(false)
                .HasColumnName("PRCDKEY");
            entity.Property(e => e.Priocat)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRIOCAT");
            entity.Property(e => e.Priority)
                .HasColumnType("NUMBER")
                .HasColumnName("PRIORITY");
            entity.Property(e => e.Process)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Processtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Processver)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("PROCESSVER");
            entity.Property(e => e.Prodarea)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PRODAREA");
            entity.Property(e => e.Prodct)
                .HasColumnType("NUMBER(5,2)")
                .HasColumnName("PRODCT");
            entity.Property(e => e.Prodstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRODSTAGE");
            entity.Property(e => e.ProdstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODSTAGE_SORT");
            entity.Property(e => e.Queuetime)
                .HasColumnType("DATE")
                .HasColumnName("QUEUETIME");
            entity.Property(e => e.Recpid)
                .HasMaxLength(128)
                .IsUnicode(false)
                .HasColumnName("RECPID");
            entity.Property(e => e.Recpname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("RECPNAME");
            entity.Property(e => e.Recpversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("RECPVERSION");
            entity.Property(e => e.Reltime)
                .HasColumnType("DATE")
                .HasColumnName("RELTIME");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Replott)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("REPLOTT");
            entity.Property(e => e.Repstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("REPSTAGE");
            entity.Property(e => e.RepstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("REPSTAGE_SORT");
            entity.Property(e => e.Reqdtime)
                .HasColumnType("DATE")
                .HasColumnName("REQDTIME");
            entity.Property(e => e.Reworkcyclecount)
                .HasColumnType("NUMBER")
                .HasColumnName("REWORKCYCLECOUNT");
            entity.Property(e => e.Rhold)
                .HasColumnType("NUMBER")
                .HasColumnName("RHOLD");
            entity.Property(e => e.SortFlow)
                .HasColumnType("NUMBER")
                .HasColumnName("SORT_FLOW");
            entity.Property(e => e.Stage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Startrecptime)
                .HasColumnType("DATE")
                .HasColumnName("STARTRECPTIME");
            entity.Property(e => e.Taxis)
                .HasColumnType("NUMBER")
                .HasColumnName("TAXIS");
            entity.Property(e => e.Tempparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("TEMPPARMCOUNT");
            entity.Property(e => e.Testcount)
                .HasColumnType("NUMBER")
                .HasColumnName("TESTCOUNT");
            entity.Property(e => e.Theoct)
                .HasColumnType("NUMBER")
                .HasColumnName("THEOCT");
            entity.Property(e => e.Theoqty)
                .HasColumnType("NUMBER")
                .HasColumnName("THEOQTY");
            entity.Property(e => e.Totalreworkcyclecount)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALREWORKCYCLECOUNT");
            entity.Property(e => e.Trackinmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("TRACKINMAINQTY");
            entity.Property(e => e.Trackintime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKINTIME");
            entity.Property(e => e.Trackouttime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKOUTTIME");
            entity.Property(e => e.Tthold)
                .HasColumnType("NUMBER")
                .HasColumnName("TTHOLD");
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TYPE");
            entity.Property(e => e.Vflag)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VFLAG");
            entity.Property(e => e.Whold)
                .HasColumnType("NUMBER")
                .HasColumnName("WHOLD");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");

        modelBuilder.Entity<RepActl15min>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("REP_ACTL_15MIN");

            entity.HasIndex(e => e.Lotid, "REP_ACTL_15MIN_IDX1");

            entity.HasIndex(e => e.Stage, "REP_ACTL_15MIN_IDX2");

            entity.HasIndex(e => e.Processtype, "REP_ACTL_15MIN_IDX3");

            entity.HasIndex(e => e.Repstage, "REP_ACTL_15MIN_IDX4");

            entity.HasIndex(e => e.Module, "REP_ACTL_15MIN_IDX5");

            entity.Property(e => e.Callprcdid)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("CALLPRCDID");
            entity.Property(e => e.CapaGroup)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CAPA_GROUP");
            entity.Property(e => e.Capability)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAPABILITY");
            entity.Property(e => e.Class1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS1");
            entity.Property(e => e.Class2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS2");
            entity.Property(e => e.Class3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS3");
            entity.Property(e => e.Class4)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CLASS4");
            entity.Property(e => e.Cr1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CR1");
            entity.Property(e => e.Cr2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CR2");
            entity.Property(e => e.Cr3)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CR3");
            entity.Property(e => e.Createtime)
                .HasColumnType("DATE")
                .HasColumnName("CREATETIME");
            entity.Property(e => e.Curmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("CURMAINQTY");
            entity.Property(e => e.Curprcdcurinstnum)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CURPRCDCURINSTNUM");
            entity.Property(e => e.Curprcdname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("CURPRCDNAME");
            entity.Property(e => e.Customername)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CUSTOMERNAME");
            entity.Property(e => e.Custordernumber)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CUSTORDERNUMBER");
            entity.Property(e => e.Empidtrackin)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKIN");
            entity.Property(e => e.Empidtrackout)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("EMPIDTRACKOUT");
            entity.Property(e => e.Endmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("ENDMAINQTY");
            entity.Property(e => e.Endtime)
                .HasColumnType("DATE")
                .HasColumnName("ENDTIME");
            entity.Property(e => e.Engineer)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("ENGINEER");
            entity.Property(e => e.Eqpid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EQPID");
            entity.Property(e => e.Eqptype)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("EQPTYPE");
            entity.Property(e => e.Flag)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("FLAG");
            entity.Property(e => e.Flowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("FLOWSTEP");
            entity.Property(e => e.Focus)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("'N'\n")
                .IsFixedLength()
                .HasColumnName("FOCUS");
            entity.Property(e => e.ForecastType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FORECAST_TYPE");
            entity.Property(e => e.Foretime)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME");
            entity.Property(e => e.Foretime1)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME1");
            entity.Property(e => e.Foretime2)
                .HasColumnType("DATE")
                .HasColumnName("FORETIME2");
            entity.Property(e => e.G6g7)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("G6G7");
            entity.Property(e => e.Holdcode)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOLDCODE");
            entity.Property(e => e.Holdcode1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HOLDCODE1");
            entity.Property(e => e.Holdreas)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("HOLDREAS");
            entity.Property(e => e.Holdtimes)
                .HasColumnType("NUMBER")
                .HasColumnName("HOLDTIMES");
            entity.Property(e => e.Holdtype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("HOLDTYPE");
            entity.Property(e => e.Holduser)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("HOLDUSER");
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Locationtype)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("LOCATIONTYPE");
            entity.Property(e => e.LotLevel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOT_LEVEL");
            entity.Property(e => e.Lotcmnt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOTCMNT");
            entity.Property(e => e.Lotid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("LOTID");
            entity.Property(e => e.Lotparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("LOTPARMCOUNT");
            entity.Property(e => e.Lottype)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("LOTTYPE");
            entity.Property(e => e.Maxflowstep)
                .HasColumnType("NUMBER")
                .HasColumnName("MAXFLOWSTEP");
            entity.Property(e => e.ModifyReqdtime)
                .HasColumnType("DATE")
                .HasColumnName("MODIFY_REQDTIME");
            entity.Property(e => e.Module)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MODULE");
            entity.Property(e => e.NewQueuetime)
                .HasColumnType("DATE")
                .HasColumnName("NEW_QUEUETIME");
            entity.Property(e => e.NewQueuetimeDevfabhold)
                .HasColumnType("DATE")
                .HasColumnName("NEW_QUEUETIME_DEVFABHOLD");
            entity.Property(e => e.Newpriority)
                .HasColumnType("NUMBER")
                .HasColumnName("NEWPRIORITY");
            entity.Property(e => e.Outdate)
                .HasColumnType("DATE")
                .HasColumnName("OUTDATE");
            entity.Property(e => e.Parentid)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("PARENTID");
            entity.Property(e => e.Partid)
                .HasMaxLength(61)
                .IsUnicode(false)
                .HasColumnName("PARTID");
            entity.Property(e => e.Partname)
                .HasMaxLength(29)
                .IsUnicode(false)
                .HasColumnName("PARTNAME");
            entity.Property(e => e.Partversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("PARTVERSION");
            entity.Property(e => e.Pcode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PCODE");
            entity.Property(e => e.Photomax)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOMAX");
            entity.Property(e => e.Photosort)
                .HasColumnType("NUMBER")
                .HasColumnName("PHOTOSORT");
            entity.Property(e => e.Prcdstarttime)
                .HasColumnType("DATE")
                .HasColumnName("PRCDSTARTTIME");
            entity.Property(e => e.Priority)
                .HasColumnType("NUMBER")
                .HasColumnName("PRIORITY");
            entity.Property(e => e.Process)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("PROCESS");
            entity.Property(e => e.Processtype)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("PROCESSTYPE");
            entity.Property(e => e.Prodstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("PRODSTAGE");
            entity.Property(e => e.ProdstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("PRODSTAGE_SORT");
            entity.Property(e => e.Queuetime)
                .HasColumnType("DATE")
                .HasColumnName("QUEUETIME");
            entity.Property(e => e.Ratio)
                .HasColumnType("NUMBER")
                .HasColumnName("RATIO");
            entity.Property(e => e.Recpid)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("RECPID");
            entity.Property(e => e.Recpname)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("RECPNAME");
            entity.Property(e => e.Recpversion)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("RECPVERSION");
            entity.Property(e => e.Reference)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("REFERENCE");
            entity.Property(e => e.Reltime)
                .HasColumnType("DATE")
                .HasColumnName("RELTIME");
            entity.Property(e => e.Repdate)
                .HasColumnType("DATE")
                .HasColumnName("REPDATE");
            entity.Property(e => e.Replott)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("REPLOTT");
            entity.Property(e => e.Repstage)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("REPSTAGE");
            entity.Property(e => e.RepstageSort)
                .HasColumnType("NUMBER")
                .HasColumnName("REPSTAGE_SORT");
            entity.Property(e => e.Reqdtime)
                .HasColumnType("DATE")
                .HasColumnName("REQDTIME");
            entity.Property(e => e.Reworkcyclecount)
                .HasColumnType("NUMBER")
                .HasColumnName("REWORKCYCLECOUNT");
            entity.Property(e => e.Setparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("SETPARMCOUNT");
            entity.Property(e => e.Stage)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("STAGE");
            entity.Property(e => e.Stageheldtime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGEHELDTIME");
            entity.Property(e => e.Stageruntime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGERUNTIME");
            entity.Property(e => e.Stagestarttime)
                .HasColumnType("DATE")
                .HasColumnName("STAGESTARTTIME");
            entity.Property(e => e.Stagewaittime)
                .HasColumnType("NUMBER")
                .HasColumnName("STAGEWAITTIME");
            entity.Property(e => e.Startmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("STARTMAINQTY");
            entity.Property(e => e.Starttime)
                .HasColumnType("DATE")
                .HasColumnName("STARTTIME");
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STATE");
            entity.Property(e => e.Stateentrytime)
                .HasColumnType("DATE")
                .HasColumnName("STATEENTRYTIME");
            entity.Property(e => e.Taxis)
                .HasColumnType("NUMBER")
                .HasColumnName("TAXIS");
            entity.Property(e => e.Tempparmcount)
                .HasColumnType("NUMBER")
                .HasColumnName("TEMPPARMCOUNT");
            entity.Property(e => e.Theoct)
                .HasColumnType("NUMBER")
                .HasColumnName("THEOCT");
            entity.Property(e => e.TodayMoves)
                .HasColumnType("NUMBER")
                .HasColumnName("TODAY_MOVES");
            entity.Property(e => e.TodayPlansteps)
                .HasColumnType("NUMBER")
                .HasColumnName("TODAY_PLANSTEPS");
            entity.Property(e => e.TodaySteps)
                .HasColumnType("NUMBER")
                .HasColumnName("TODAY_STEPS");
            entity.Property(e => e.Totalheldtime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALHELDTIME");
            entity.Property(e => e.Totalruntime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALRUNTIME");
            entity.Property(e => e.Totalwaittime)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALWAITTIME");
            entity.Property(e => e.Trackinmainqty)
                .HasColumnType("NUMBER")
                .HasColumnName("TRACKINMAINQTY");
            entity.Property(e => e.Trackintime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKINTIME");
            entity.Property(e => e.Trackouttime)
                .HasColumnType("DATE")
                .HasColumnName("TRACKOUTTIME");
            entity.Property(e => e.Type)
                .HasColumnType("NUMBER")
                .HasColumnName("TYPE");
            entity.Property(e => e.Vflag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("VFLAG");
            entity.Property(e => e.YesterdayPlansteps)
                .HasColumnType("NUMBER")
                .HasColumnName("YESTERDAY_PLANSTEPS");
            entity.Property(e => e.YesterdaySteps)
                .HasColumnType("NUMBER")
                .HasColumnName("YESTERDAY_STEPS");
        });
        modelBuilder.HasSequence("APQP_ABNORMAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("APQP_SEQ").IsCyclic();
        modelBuilder.HasSequence("CHECKSEQ");
        modelBuilder.HasSequence("DAY_MASTER_SEQ");
        modelBuilder.HasSequence("EPC_CLI_COL_NAME_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_COL_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_ENV_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FDF_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_FMT_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_JOB_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_NODE_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_PROGR_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_REP_USERS_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_CLI_SVC_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("EPC_COLLECTION_ID");
        modelBuilder.HasSequence("EPC_MVIEW_ID");
        modelBuilder.HasSequence("EPC_VIEW_ID");
        modelBuilder.HasSequence("EVT_NOTIFY_SEQ");
        modelBuilder.HasSequence("EVT_OPERATORS_SEQ");
        modelBuilder.HasSequence("EVT_PROFILE_SEQ");
        modelBuilder.HasSequence("FACE_ABNORMITY_SEQ");
        modelBuilder.HasSequence("FUTA_SEQUENCE").IsCyclic();
        modelBuilder.HasSequence("MICROSOFTSEQDTPROPERTIES");
        modelBuilder.HasSequence("MONTH_MASTER_SEQ");
        modelBuilder.HasSequence("PM_APS3_CONFIRM_SEQ");
        modelBuilder.HasSequence("PM_APS3_DATA_SEQ");
        modelBuilder.HasSequence("PM_BASIC_DATA_SEQ");
        modelBuilder.HasSequence("QUARTER_MASTER_SEQ");
        modelBuilder.HasSequence("S_DIFF_DISPATCH_SEQ");
        modelBuilder.HasSequence("SMACTUALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMAGENTJOBSEQUENCE");
        modelBuilder.HasSequence("SMARCHIVESEQUENCE");
        modelBuilder.HasSequence("SMCONSOLESOSETTINGSEQUENCE");
        modelBuilder.HasSequence("SMDATABASESEQUENCE");
        modelBuilder.HasSequence("SMDBAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDEFAUTHSEQUENCE");
        modelBuilder.HasSequence("SMDISTRIBUTIONSETSEQUENCE");
        modelBuilder.HasSequence("SMFOLDERSEQUENCE");
        modelBuilder.HasSequence("SMFORMALPARAMETERSEQUENCE");
        modelBuilder.HasSequence("SMGLOBALCONFIGURATIONSEQUENCE");
        modelBuilder.HasSequence("SMHOSTAUTHSEQUENCE");
        modelBuilder.HasSequence("SMHOSTSEQUENCE");
        modelBuilder.HasSequence("SMINSTALLATIONSEQUENCE");
        modelBuilder.HasSequence("SMLOGMESSAGESEQUENCE");
        modelBuilder.HasSequence("SMMONTHLYENTRYSEQUENCE");
        modelBuilder.HasSequence("SMMONTHWEEKENTRYSEQUENCE");
        modelBuilder.HasSequence("SMOMSTRINGSEQUENCE");
        modelBuilder.HasSequence("SMP_BRM_ID").IsCyclic();
        modelBuilder.HasSequence("SMP_JOB_ID_").IsCyclic();
        modelBuilder.HasSequence("SMP_LONG_ID");
        modelBuilder.HasSequence("SMP_SERVICE_SEQ");
        modelBuilder.HasSequence("SMP_VTM_CHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMP_VTM_UDCHART_DEFN_SEQ");
        modelBuilder.HasSequence("SMPACKAGESEQUENCE");
        modelBuilder.HasSequence("SMPARALLELJOBSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELOPERATIONSEQUENCE");
        modelBuilder.HasSequence("SMPARALLELSTATEMENTSEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTATTRIBUTESEQUENCE");
        modelBuilder.HasSequence("SMPRODUCTSEQUENCE");
        modelBuilder.HasSequence("SMRELEASESEQUENCE");
        modelBuilder.HasSequence("SMRUNSEQUENCE");
        modelBuilder.HasSequence("SMSCHEDULESEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECLIENTSEQUENCE");
        modelBuilder.HasSequence("SMSHAREDORACLECONFIGSEQUENCE");
        modelBuilder.HasSequence("SMTABLESPACESEQUENCE");
        modelBuilder.HasSequence("SMTEMPORARYSEQUENCE");
        modelBuilder.HasSequence("SMVCENDPOINTSEQUENCE");
        modelBuilder.HasSequence("SMWEEKLYENTRYSEQUENCE");
        modelBuilder.HasSequence("TIME_SEQ");
        modelBuilder.HasSequence("VBZ$CHANGE_PLAN_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DB_OBJ_NAMES_SEQ");
        modelBuilder.HasSequence("VBZ$DIRECTIVES_SEQ");
        modelBuilder.HasSequence("VBZ$EXEMPLARS_SEQ");
        modelBuilder.HasSequence("VBZ$TRANS_ID_SEQ");
        modelBuilder.HasSequence("WEEK_MASTER_SEQ");
        modelBuilder.HasSequence("WHH_SEQ").IncrementsBy(10);
        modelBuilder.HasSequence("XP_JOURNAL_SEQ").IsCyclic();
        modelBuilder.HasSequence("XP_REP_CONTROL_SEQUENCE");
        modelBuilder.HasSequence("XP_SQL_ID_SEQUENCE");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
