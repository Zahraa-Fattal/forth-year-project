using AutoMapper;
using DataBase;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using OurProject.Dto.UnitStoreDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class UnitStoreRepo : UnitStoreIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public UnitStoreRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext =_dbContext;
            mapper = pmapper;
        }
        public bool AddUnitStore(AddUnitStoreDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<UnitStoreEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUnitStore(int id)
        {
            try
            {
                var result = dbContext.unitStores.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllUnitStoreDto> GetAllUnitStore()
        {
            try
            {
                var result = dbContext.unitStores.ToList();
                return mapper.Map<List<GetAllUnitStoreDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateUnitStore(AddUnitStoreDto dto, int id)
        {
            try
            {
                var result = dbContext.unitStores.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
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

        public List<GetFreeStoreDto> GetFreeStore()
        {
            try
            {
                string sql = "exec [dbo].[GetFreeStore]";
                var Result = dbContext.GetFreeStoreSBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetFreeStoreDto>>(Result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
