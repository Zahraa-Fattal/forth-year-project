using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.DateTypeDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class DateTypeRepo : DateTypeIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public DateTypeRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddDateType(AddDateTypeDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<DateTypeEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteDateType(int id)
        {
            try
            {
                var result = dbContext.dateTypes.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllDateTypeDto> GetAllDateType()
        {
            try
            {
                var result = dbContext.dateTypes.ToList();
                return mapper.Map<List<GetAllDateTypeDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateDateType(AddDateTypeDto dto, int id)
        {
            try
            {
                var result = dbContext.dateTypes.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
                    }
                    if (dto.Price != 0)
                    {
                        result.Price = dto.Price;
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
