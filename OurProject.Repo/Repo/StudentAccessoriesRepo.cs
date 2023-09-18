using AutoMapper;
using DataBase;
using DataBase.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OurProject.Dto.StudentAccessoriesDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class StudentAccessoriesRepo : StudentAccessoriesIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public StudentAccessoriesRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddStudentAccessories(AddStudentAccessoriesDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<StudentAccessoriesEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudentAccessories(int id)
        {
            try
            {
                var result = dbContext.studentAccessories.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllStudentAccessoriesDto> GetAllStudentAccessories()
        {
            try
            {
                var result = dbContext.studentAccessories.ToList();
                return mapper.Map<List<GetAllStudentAccessoriesDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<GetAllStudentAccessoriesDto> GetStudentAccessoriesByStudentId(int studentId)
        {
            try
            {
                var result = dbContext.studentAccessories.Where(x=>x.StudentId==studentId).ToList();
                return mapper.Map<List<GetAllStudentAccessoriesDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateStudentAccessories(AddStudentAccessoriesDto dto, int id)
        {
            try
            {
                var result = dbContext.studentAccessories.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.Amount!=-1)
                    {
                        result.Amount += dto.Amount;
                    } 
                 

                    result.Returned = dto.Returned;

                    if (dto.StoreDetailId!=0)
                    {
                        result.StoreDetailId = dto.StoreDetailId;
                    }
                    if (dto.StudentId!=0)
                    {
                        result.StudentId = dto.StudentId;
                    }
                    dbContext.Update(result);
                    dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int? GetStudentAccessoriesIdIfExists(int StudentId,int StoreDetailId)
        {
            try
            {
               var result= dbContext.studentAccessories.FirstOrDefault(x => x.StudentId == StudentId && x.StoreDetailId == StoreDetailId);
                if (result!=null)
                {
                    return result.Id;
                }
                else
                {
                    return -1;  
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GetItemsInStoreUnitDto> GetItemsInStoreUnit(int StoreUnitId,int StudentId)
        {
            try
            {
                string sql = "exec [dbo].[GetItemsInStoreUnit]  @StoreUnitId,@StudentId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@StoreUnitId", Value = StoreUnitId},
                  new SqlParameter { ParameterName = "@StudentId", Value = StudentId}
                };
                var result = dbContext.GetItemsInStoreUnitSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetItemsInStoreUnitDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetItemsInStoreUnitDto> GetExtraItemsInStoreUnit(int StoreUnitId, int StudentId)
        {
            try
            {
                string sql = "exec [dbo].[GetExtraItemInStoreUnit] @StoreUnitId,@StudentId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@StoreUnitId", Value = StoreUnitId},
                  new SqlParameter { ParameterName = "@StudentId", Value = StudentId}
                };
                var result = dbContext.GetItemsInStoreUnitSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetItemsInStoreUnitDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<GetItemsByStudentIdDto> GetItemsByStudentId(int UnitStore, int StudentId)
        {
            try
            {
                string sql = "exec [dbo].[GetItemsByStudentId]  @StoreUnitId,@StudentId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@StoreUnitId", Value = UnitStore},
                  new SqlParameter { ParameterName = "@StudentId", Value = StudentId}
                };
                var result = dbContext.GetItemsByStudentIdSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetItemsByStudentIdDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetStudentThatHasItemsDto> GetStudentThatHasItems(int UnitStore)
        {
            try
            {
                string sql = "exec [dbo].[GetStudentThatHasItems]  @StoreUnitId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@StoreUnitId", Value = UnitStore}
                };
                var result = dbContext.GetStudentThatHasItemsSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetStudentThatHasItemsDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetStudentThatHasItemsDto> GetStudentThatHasItemsByDate(int UnitStore, DateTime MinDate, DateTime MaxDate)
        {
            try
            {
                string sql = "exec [dbo].[GetStudentThatHasItemsByDate]  @StoreUnitId,@minDate,@maxDate";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@StoreUnitId", Value = UnitStore},
                  new SqlParameter { ParameterName = "@minDate", Value = MinDate},
                  new SqlParameter { ParameterName = "@maxDate", Value = MaxDate}
                };
                var result = dbContext.GetStudentThatHasItemsSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetStudentThatHasItemsDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
