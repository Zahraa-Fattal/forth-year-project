using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.StoreDetailDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class StoreDetailRepo : StoreDetailIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public StoreDetailRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddStoreDetail(AddStoreDetailDto dto)
        {

            try
            {
                dbContext.Add(mapper.Map<StoreDetailEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStoreDetail(int id)
        {
            try
            {
                var result = dbContext.storeDetails.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllStoreDetailDto> GetAllStoreDetail()
        {
            try
            {
                var result = dbContext.storeDetails.ToList();
                return mapper.Map<List<GetAllStoreDetailDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateStoreDetail(AddStoreDetailDto dto, int id)
        {
            try
            {
                var result = dbContext.storeDetails.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.AccessoryId!=0)
                    {
                        result.AccessoryId = dto.AccessoryId;
                    } 
                    if (dto.Amount!=-1)
                    {
                        result.Amount -= dto.Amount;
                    } 
                    if (dto.UnitStoreId!=0)
                    {
                        result.UnitStoreId = dto.UnitStoreId;
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

        public bool UpdateStoreDetailNormal(AddStoreDetailDto dto, int id)
        {
            try
            {
                var result = dbContext.storeDetails.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.AccessoryId != 0)
                    {
                        result.AccessoryId = dto.AccessoryId;
                    }
                    if (dto.Amount != -1)
                    {
                        result.Amount = dto.Amount;
                    }
                    if (dto.UnitStoreId != 0)
                    {
                        result.UnitStoreId = dto.UnitStoreId;
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

        public bool UpdateStoreDetailForExitStudent(AddStoreDetailDto dto, int id)
        {
            try
            {
                var result = dbContext.storeDetails.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.AccessoryId != 0)
                    {
                        result.AccessoryId = dto.AccessoryId;
                    }
                    if (dto.Amount != -1)
                    {
                        result.Amount += dto.Amount;
                    }
                    if (dto.UnitStoreId != 0)
                    {
                        result.UnitStoreId = dto.UnitStoreId;
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
    }
}
