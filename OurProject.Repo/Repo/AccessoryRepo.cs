
using AutoMapper;
using DataBase;
using DataBase.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OurProject.Dto.AccessoryDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class AccessoryRepo : AccessoryIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public AccessoryRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddAccessory(AddAccessoryDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<AccessoryEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteAccessory(int id)
        {
            try
            {
                var result = dbContext.accessories.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllAccessoryDto> GetAllAccessory()
        {
            try
            {
                var result = dbContext.accessories.ToList();
                return mapper.Map<List<GetAllAccessoryDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateAccessory(AddAccessoryDto dto, int id)
        {
            try
            {
                var result = dbContext.accessories.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
                    }
                    if (!string.IsNullOrEmpty(dto.Image))
                    {
                        result.Image = dto.Image;
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

        public List<GetAccessoriesDetailsDto> GetAccessoriesDetails(int unitStoreId)
        {
            try
            {
                string sql = "exec [dbo].[GetAccessoriesDetails] @unitStoreId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@unitStoreId", Value = unitStoreId}
                };
                var result = dbContext.GetAccessoriesDetailsSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetAccessoriesDetailsDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public int AddAccessoryWithIdReturn(AddAccessoryDto dto)
        {
            try
            {
                var result = dbContext.Add(mapper.Map<AccessoryEntity>(dto));
                dbContext.SaveChanges();
                return (result.Entity.Id);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
            
    }
}
