﻿// <auto-generated />
using System;
using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataBase.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220513130606_fix-date")]
    partial class fixdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("DataBase.Entities.AccessoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("accessories");
                });

            modelBuilder.Entity("DataBase.Entities.CityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("MainCity")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MainCity");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("DataBase.Entities.DateTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("dateTypes");
                });

            modelBuilder.Entity("DataBase.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("DataBase.Entities.RoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("rooms");
                });

            modelBuilder.Entity("DataBase.Entities.StoreDetailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AccessoryId")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("UnitStoreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccessoryId");

                    b.HasIndex("UnitStoreId");

                    b.ToTable("storeDetails");
                });

            modelBuilder.Entity("DataBase.Entities.StudentAccessoriesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("Returned")
                        .HasColumnType("bit");

                    b.Property<int>("StoreDetailId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StoreDetailId");

                    b.HasIndex("StudentId");

                    b.ToTable("studentAccessories");
                });

            modelBuilder.Entity("DataBase.Entities.StudentDateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DateTypeId")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DateTypeId");

                    b.HasIndex("StudentId");

                    b.ToTable("studentDates");
                });

            modelBuilder.Entity("DataBase.Entities.StudentEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Recorded")
                        .HasColumnType("bit");

                    b.Property<int>("StudyBranchId")
                        .HasColumnType("int");

                    b.Property<int>("SuggestedUnitId")
                        .HasColumnType("int");

                    b.Property<int?>("UnitRoomFk")
                        .HasColumnType("int");

                    b.Property<string>("UniversityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("StudyBranchId");

                    b.HasIndex("UnitRoomFk");

                    b.ToTable("students");
                });

            modelBuilder.Entity("DataBase.Entities.StudyBranchEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("studyBranches");
                });

            modelBuilder.Entity("DataBase.Entities.UnitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudyBranchEntityId")
                        .HasColumnType("int");

                    b.Property<int>("UnitStoreFk")
                        .HasColumnType("int");

                    b.Property<int>("UserSuperVisorFk")
                        .HasColumnType("int");

                    b.Property<int>("UserUnitStoreKeeperFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudyBranchEntityId");

                    b.HasIndex("UnitStoreFk")
                        .IsUnique();

                    b.HasIndex("UserSuperVisorFk")
                        .IsUnique();

                    b.HasIndex("UserUnitStoreKeeperFk")
                        .IsUnique();

                    b.ToTable("units");
                });

            modelBuilder.Entity("DataBase.Entities.UnitRoomEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<int>("StudentCount")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.HasIndex("UnitId");

                    b.ToTable("unitRooms");
                });

            modelBuilder.Entity("DataBase.Entities.UnitStoreEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("unitStores");
                });

            modelBuilder.Entity("DataBase.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("DataBase.Entities.VacationDateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("vacationDates");
                });

            modelBuilder.Entity("DataBase.SBResults.GetAllUnitsInfoSBR", b =>
                {
                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreKeeperName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SuperVisorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyBrancheName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitStoreName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetAllUnitsInfoSBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetCountrySBR", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("countryName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetCountrySBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetFreeStoreKeeperSBR", b =>
                {
                    b.Property<int>("StoreKeeperId")
                        .HasColumnType("int");

                    b.Property<string>("StoreKeeperName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetFreeStoreKeeperSBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetFreeStoreSBR", b =>
                {
                    b.Property<int>("unitStoresId")
                        .HasColumnType("int");

                    b.Property<string>("unitStoresName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetFreeStoreSBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetFreeSuperVisorSBR", b =>
                {
                    b.Property<int>("SuperVisorId")
                        .HasColumnType("int");

                    b.Property<string>("SuperVisorName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetFreeSuperVisorSBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetMainCitySBR", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("mainCityName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetMainCitySBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetSpecificUnitSBR", b =>
                {
                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreKeeperId")
                        .HasColumnType("int");

                    b.Property<string>("StoreKeeperName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperVisorId")
                        .HasColumnType("int");

                    b.Property<string>("SuperVisorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<string>("UnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("studyBrancheName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("studyBranchesId")
                        .HasColumnType("int");

                    b.Property<string>("unitStoreName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("unitStoresId")
                        .HasColumnType("int");

                    b.ToTable("GetSpecificUnitSBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetStoreKeeperInfoSBR", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StoreKeeperId")
                        .HasColumnType("int");

                    b.Property<string>("StoreKeeperName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetStoreKeeperInfoSBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetStudentCountInUniteSBR", b =>
                {
                    b.Property<int>("StudentCount")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.ToTable("GetStudentCountInUniteSBRs");
                });

            modelBuilder.Entity("DataBase.SBResults.GetSuperVisorInfoSBR", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperVisorId")
                        .HasColumnType("int");

                    b.Property<string>("SuperVisorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("unitName")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("GetSuperVisorInfoSBRs");
                });

            modelBuilder.Entity("DataBase.Entities.CityEntity", b =>
                {
                    b.HasOne("DataBase.Entities.CityEntity", null)
                        .WithMany()
                        .HasForeignKey("MainCity")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("DataBase.Entities.StoreDetailEntity", b =>
                {
                    b.HasOne("DataBase.Entities.AccessoryEntity", "Accessory")
                        .WithMany()
                        .HasForeignKey("AccessoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.UnitStoreEntity", "UnitStore")
                        .WithMany()
                        .HasForeignKey("UnitStoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accessory");

                    b.Navigation("UnitStore");
                });

            modelBuilder.Entity("DataBase.Entities.StudentAccessoriesEntity", b =>
                {
                    b.HasOne("DataBase.Entities.StoreDetailEntity", "StoreDetail")
                        .WithMany()
                        .HasForeignKey("StoreDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.StudentEntity", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreDetail");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataBase.Entities.StudentDateEntity", b =>
                {
                    b.HasOne("DataBase.Entities.DateTypeEntity", "DateType")
                        .WithMany()
                        .HasForeignKey("DateTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.StudentEntity", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DateType");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DataBase.Entities.StudentEntity", b =>
                {
                    b.HasOne("DataBase.Entities.CityEntity", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.StudyBranchEntity", "StudyBranch")
                        .WithMany()
                        .HasForeignKey("StudyBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.UnitRoomEntity", null)
                        .WithMany()
                        .HasForeignKey("UnitRoomFk")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("City");

                    b.Navigation("StudyBranch");
                });

            modelBuilder.Entity("DataBase.Entities.UnitEntity", b =>
                {
                    b.HasOne("DataBase.Entities.StudyBranchEntity", "StudyBranch")
                        .WithMany()
                        .HasForeignKey("StudyBranchEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.UnitStoreEntity", null)
                        .WithOne()
                        .HasForeignKey("DataBase.Entities.UnitEntity", "UnitStoreFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.UserEntity", null)
                        .WithOne()
                        .HasForeignKey("DataBase.Entities.UnitEntity", "UserSuperVisorFk")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.UserEntity", null)
                        .WithOne()
                        .HasForeignKey("DataBase.Entities.UnitEntity", "UserUnitStoreKeeperFk")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("StudyBranch");
                });

            modelBuilder.Entity("DataBase.Entities.UnitRoomEntity", b =>
                {
                    b.HasOne("DataBase.Entities.RoomEntity", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataBase.Entities.UnitEntity", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("DataBase.Entities.UserEntity", b =>
                {
                    b.HasOne("DataBase.Entities.RoleEntity", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
