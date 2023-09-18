using DataBase.Entities;
using DataBase.SBResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class MyDbContext:DbContext
    {
        public DbSet<RoleEntity> role { get; set; }
        public DbSet<UserEntity> user { get; set; }
        public DbSet<AccessoryEntity> accessories { get; set; }
        public DbSet<CityEntity> cities { get; set; }
        public DbSet<DateTypeEntity> dateTypes { get; set; }
        public DbSet<RoomEntity> rooms { get; set; }
        public DbSet<StoreDetailEntity> storeDetails { get; set; }
        public DbSet<StudentEntity> students { get; set; }
        public DbSet<StudentAccessoriesEntity> studentAccessories { get; set; }
        public DbSet<StudentDateEntity> studentDates { get; set; }
        public DbSet<StudyBranchEntity> studyBranches { get; set; }
        public DbSet<UnitRoomEntity> unitRooms { get; set; }
        public DbSet<UnitEntity> units { get; set; }
        public DbSet<UnitStoreEntity> unitStores { get; set; }
        public DbSet<VacationDateEntity> vacationDates { get; set; }
        public virtual DbSet<GetAllUnitsInfoSBR> GetAllUnitsInfoSBRs { get; set; }
        public virtual DbSet<GetSuperVisorInfoSBR> GetSuperVisorInfoSBRs { get; set; }
        public virtual DbSet<GetStoreKeeperInfoSBR> GetStoreKeeperInfoSBRs { get; set; }
        public virtual DbSet<GetFreeSuperVisorSBR>  GetFreeSuperVisorSBRs { get; set; }
        public virtual DbSet<GetFreeStoreKeeperSBR>  GetFreeStoreKeeperSBRs { get; set; }
        public virtual DbSet<GetFreeStoreSBR>  GetFreeStoreSBRs { get; set; }
        public virtual DbSet<GetSpecificUnitSBR>  GetSpecificUnitSBRs { get; set; }
        public virtual DbSet<GetCountrySBR>  GetCountrySBRs { get; set; }
        public virtual DbSet<GetMainCitySBR>  GetMainCitySBRs { get; set; }
        public virtual DbSet<GetStudentCountInUniteSBR>  GetStudentCountInUniteSBRs { get; set; }
        public virtual DbSet<GetLastDateSBR>  GetLastDateSBRs { get; set; }
        public virtual DbSet<GetAllUnRecordedStudentsSBR>  GetAllUnRecordedStudentsSBRs { get; set; }
        public virtual DbSet<GetSpecificStudentSBR>  GetSpecificStudentSBRs { get; set; }
        public virtual DbSet<getFreeRoomsByUnitIdSBR>  GetFreeRoomsByUnitIdSBRs { get; set; }
        public virtual DbSet<GetRoomsInUnitSBR>  GetRoomsInUnitSBRs { get; set; }
        public virtual DbSet<GetStudentInRoomSBR>  GetStudentInRoomSBRs { get; set; }
        public virtual DbSet<GetAllRecorderStudentsSBR>  GetAllRecorderStudentsSBRs { get; set; }
        public virtual DbSet<GetAccessoriesDetailsSBR>  GetAccessoriesDetailsSBRs { get; set; }
        public virtual DbSet<GetItemsInStoreUnitSBR>  GetItemsInStoreUnitSBRs { get; set; }
        public virtual DbSet<GetItemsByStudentIdSBR>  GetItemsByStudentIdSBRs { get; set; }
        public virtual DbSet<GetStudentThatHasItemsSBR>  GetStudentThatHasItemsSBRs { get; set; }
        public virtual DbSet<GetFullInformationSBR>  GetFullInformation { get; set; }
        public virtual DbSet<GetEmployeeInfoSBR>  GetEmployeeInfoSBRs { get; set; }

        private readonly IConfiguration config;
        private string key { get; set; }
        public MyDbContext(IConfiguration _config) 
        {
            config = _config;
            key = config.GetSection("ConnectionStrings").GetSection("Key").Value.ToString();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder Builder)
        {
            base.OnConfiguring(Builder);
         
            Builder.UseSqlServer(key);

        }

        protected  override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            //  //one-to-many
            //  Builder.Entity<User>()
            //  .HasOne<Role>()
            //  .WithMany()
            //  .HasForeignKey(b => b.RoleFk);

            //  Builder.Entity<Unit>()
            // .HasOne<StudyBranch>()
            // .WithMany()
            // .HasForeignKey(b => b.StudeyBranchFk);

            //  Builder.Entity<StoreDetails>()
            // .HasOne<Accessories>()
            // .WithMany()
            // .HasForeignKey(b => b.AccessoriesFk);


            //  Builder.Entity<StoreDetails>()
            // .HasOne<UnitStore>()
            // .WithMany()
            // .HasForeignKey(b => b.UnitStoreFk);

            // Builder.Entity<StudentAccessories>()
            // .HasOne<StoreDetails>()
            // .WithMany()
            // .HasForeignKey(b => b.StoreDetailsFk);

            //  Builder.Entity<UnitRoom>()
            // .HasOne<Room>()
            // .WithMany()
            // .HasForeignKey(b => b.UnitFk);

            //  Builder.Entity<UnitRoom>()
            // .HasOne<Unit>()
            // .WithMany()
            // .HasForeignKey(b => b.UnitFk);


            //  Builder.Entity<StudentDate>()
            // .HasOne<DateType>()
            // .WithMany()
            // .HasForeignKey(b => b.DateTypeFk);

            Builder.Entity<StudentEntity>()
           .HasOne<UnitRoomEntity>()
           .WithMany()
           .HasForeignKey(b => b.UnitRoomFk)
           .OnDelete(DeleteBehavior.NoAction);

            // // Builder.Entity<Student>()
            // //.HasOne<StudyBranch>()                  
            // //.WithMany()                             
            // //.HasForeignKey(b => b.StudentBranchFk);

            //  Builder.Entity<Student>()
            // .HasOne<City>()
            // .WithMany()
            // .HasForeignKey(b => b.CityFk);

            //  Builder.Entity<StudentAccessories>()
            // .HasOne<Student>()
            // .WithMany()
            // .HasForeignKey(b => b.StudentFk);

            Builder.Entity<CityEntity>()
           .HasOne<CityEntity>()
           .WithMany()
           .HasForeignKey(b => b.MainCity)
           .OnDelete(DeleteBehavior.NoAction);

            //  Builder.Entity<StudentDate>()
            //.HasOne<TimeSlote>()
            //.WithMany()
            //.HasForeignKey(b => b.TimeSloteFk);

            //one-to-one
            Builder.Entity<UnitEntity>()
            .HasOne<UserEntity>()
            .WithOne()
            .HasForeignKey<UnitEntity>(b => b.UserSuperVisorFk)
            .OnDelete(DeleteBehavior.NoAction);

            Builder.Entity<UnitEntity>()
           .HasOne<UserEntity>()
           .WithOne()
           .HasForeignKey<UnitEntity>(b => b.UserUnitStoreKeeperFk)
           .OnDelete(DeleteBehavior.NoAction);

            Builder.Entity<UnitEntity>()
           .HasOne<UnitStoreEntity>()
           .WithOne()
           .HasForeignKey<UnitEntity>(b => b.UnitStoreFk);

        }

    }
}
