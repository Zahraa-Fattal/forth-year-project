using AutoMapper;
using DataBase;
using DataBase.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OurProject.Dto.UnitDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class UnitRepo : UnitIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public UnitRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddUnit(AddUnitDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<UnitEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public int AddUnitWithIdReturn(AddUnitDto dto)
        {
            try
            {
                var result= dbContext.Add(mapper.Map<UnitEntity>(dto));
                dbContext.SaveChanges();
                return result.Entity.Id;

               
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public bool DeleteUnit(int id)
        {
            try
            {
                var result = dbContext.units.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllUnitDto> GetAllUnit()
        {
            try
            {
                var result = dbContext.units.ToList();
                return mapper.Map<List<GetAllUnitDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateUnit(AddUnitDto dto, int id)
        {
            try
            {
                var result = dbContext.units.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
                    }  
                    if (dto.StudyBranchEntityId!=0)
                    {
                        result.StudyBranchEntityId = dto.StudyBranchEntityId;
                    }  
                    if (dto.UnitStoreFk!=0)
                    {
                        result.UnitStoreFk = dto.UnitStoreFk;
                    }
                    if (dto.UserSuperVisorFk != 0)
                    {
                        result.UserSuperVisorFk = dto.UserSuperVisorFk;
                    } 
                    if (dto.UserUnitStoreKeeperFk != 0)
                    {
                        result.UserUnitStoreKeeperFk = dto.UserUnitStoreKeeperFk;
                    }
                    if (!string.IsNullOrEmpty(dto.Image))
                    {
                        result.Image = dto.Image;
                    }

                    result.Gender = dto.Gender;
                    
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

        public List<GetAllUnitsInfoDto> GetAllUnitInfo()
        {
            try
            {
                string sql = "exec [dbo].[GetAllUnitsInfo]";

                var Result = dbContext.GetAllUnitsInfoSBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetAllUnitsInfoDto>>(Result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AddUnitDto GetOneUnit(int id)
        {
            try
            {
                var result = dbContext.units.FirstOrDefault(c => c.Id == id);
                return mapper.Map<AddUnitDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public GetSpecificUnitDto GetSpecificUnit(int unitId)
        {
            try
            {
                string sql = "exec [dbo].[GetSpecificUnit] @UniteId";
                List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@UniteId", Value = unitId}
            };
                var Result = dbContext.GetSpecificUnitSBRs.FromSqlRaw(sql, parms.ToArray()).ToList().FirstOrDefault();
                return mapper.Map<GetSpecificUnitDto>(Result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int GetUnitIdBySuperVisorId(int id)
        {
            try
            {
                var result = dbContext.units.FirstOrDefault(c=>c.UserSuperVisorFk==id);
                return result.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public int GetUnitIdByStoreKeeperId(int id)
        {
            try
            {
                var result = dbContext.units.FirstOrDefault(c => c.UserUnitStoreKeeperFk == id);
                return result.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        public string GetUnitNameByStoreKeeperId(int id)
        {
            try
            {
                var result = dbContext.units.FirstOrDefault(c => c.UserUnitStoreKeeperFk == id);
                return result.Name;
            }
            catch (Exception)
            {
                return "";
            }
        }
        public int GetUnitStoreIdByStoreKeeperId(int id)
        {
            try
            {
                var result = dbContext.units.FirstOrDefault(c => c.UserUnitStoreKeeperFk == id);
                return result.UnitStoreFk;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
