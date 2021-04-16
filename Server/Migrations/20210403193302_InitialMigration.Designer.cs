﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Server.DataModels;

namespace Server.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210403193302_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Server.DataModels.Colony.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818119170L);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818119483L);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("Server.DataModels.Colony.Colony", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("text");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("uuid");

                    b.Property<string>("BroodChamberType")
                        .HasColumnType("text");

                    b.Property<string>("ColonyNumber")
                        .HasColumnType("text");

                    b.Property<string>("ColonySource")
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818135428L);

                    b.Property<string>("GeneticBreed")
                        .HasColumnType("text");

                    b.Property<int>("HiveNumber")
                        .HasColumnType("integer");

                    b.Property<string>("HiveType")
                        .HasColumnType("text");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uuid");

                    b.Property<long>("InstallDate")
                        .HasColumnType("bigint");

                    b.Property<string>("InstallationType")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818135764L);

                    b.Property<string>("Markings")
                        .HasColumnType("text");

                    b.Property<bool>("QueenExclude")
                        .HasColumnType("boolean");

                    b.Property<string>("QueenType")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("HostId");

                    b.ToTable("Colony");
                });

            modelBuilder.Entity("Server.DataModels.Colony.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818159620L);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818159965L);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Host");
                });

            modelBuilder.Entity("Server.DataModels.SpecialInspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ColonyId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818012527L);

                    b.Property<string[]>("Feeds")
                        .HasColumnType("text[]");

                    b.Property<string>("Growth")
                        .HasColumnType("text");

                    b.Property<string[]>("Harvest")
                        .HasColumnType("text[]");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818045550L);

                    b.Property<string[]>("TreatmentDetails")
                        .HasColumnType("text[]");

                    b.Property<string[]>("Treatments")
                        .HasColumnType("text[]");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uuid");

                    b.Property<string[]>("Wintering")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("ColonyId");

                    b.HasIndex("UserID");

                    b.ToTable("SpecialInspection");
                });

            modelBuilder.Entity("Server.DataModels.TypicalInspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Brood")
                        .HasColumnType("text");

                    b.Property<int>("BroodChambers")
                        .HasColumnType("integer");

                    b.Property<string>("BroodPattern")
                        .HasColumnType("text");

                    b.Property<string>("Cells")
                        .HasColumnType("text");

                    b.Property<Guid>("ColonyId")
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818091876L);

                    b.Property<bool>("Excluder")
                        .HasColumnType("boolean");

                    b.Property<string>("Fitness")
                        .HasColumnType("text");

                    b.Property<string[]>("Growth")
                        .HasColumnType("text[]");

                    b.Property<string>("HiveBottom")
                        .HasColumnType("text");

                    b.Property<string>("Honey")
                        .HasColumnType("text");

                    b.Property<int>("HoneyChamber")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string[]>("Issues")
                        .HasColumnType("text[]");

                    b.Property<string>("LastModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818092256L);

                    b.Property<string>("Mood")
                        .HasColumnType("text");

                    b.Property<bool>("MouseGuard")
                        .HasColumnType("boolean");

                    b.Property<bool>("PollenCollector")
                        .HasColumnType("boolean");

                    b.Property<string>("Population")
                        .HasColumnType("text");

                    b.Property<string[]>("Seasonal")
                        .HasColumnType("text[]");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("SwarmStatus")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uuid");

                    b.Property<string>("Vents")
                        .HasColumnType("text");

                    b.Property<bool>("WaspGuard")
                        .HasColumnType("boolean");

                    b.Property<string[]>("Weather")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("ColonyId");

                    b.HasIndex("UserID");

                    b.ToTable("TypicalInspection");
                });

            modelBuilder.Entity("Server.DataModels.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818107181L);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("LastModifiedBy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("System");

                    b.Property<long>("LastModifiedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(637530607818107503L);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Server.DataModels.Colony.Colony", b =>
                {
                    b.HasOne("Server.DataModels.Colony.Area", "Area")
                        .WithMany("Colonies")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.DataModels.Colony.Host", "Host")
                        .WithMany("Colonies")
                        .HasForeignKey("HostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("Server.DataModels.SpecialInspection", b =>
                {
                    b.HasOne("Server.DataModels.Colony.Colony", "Colony")
                        .WithMany()
                        .HasForeignKey("ColonyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.DataModels.User", "User")
                        .WithMany("SpecialInspections")
                        .HasForeignKey("UserID");

                    b.Navigation("Colony");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.DataModels.TypicalInspection", b =>
                {
                    b.HasOne("Server.DataModels.Colony.Colony", "Colony")
                        .WithMany()
                        .HasForeignKey("ColonyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.DataModels.User", "User")
                        .WithMany("TypicalInspections")
                        .HasForeignKey("UserID");

                    b.Navigation("Colony");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.DataModels.Colony.Area", b =>
                {
                    b.Navigation("Colonies");
                });

            modelBuilder.Entity("Server.DataModels.Colony.Host", b =>
                {
                    b.Navigation("Colonies");
                });

            modelBuilder.Entity("Server.DataModels.User", b =>
                {
                    b.Navigation("SpecialInspections");

                    b.Navigation("TypicalInspections");
                });
#pragma warning restore 612, 618
        }
    }
}
