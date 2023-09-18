using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.CityDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class CityRepo : CityIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public CityRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }

        public bool AddCity(AddCityDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<CityEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllCityDto> GetAllCity()
        {
            try
            {
                var result = dbContext.cities.ToList();
                return mapper.Map<List<GetAllCityDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateCity(AddCityDto dto, int id)
        {
            try
            {
                var result = dbContext.cities.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
                    }
                    if (dto.MainCity!=0)
                    {
                        result.MainCity = dto.MainCity;
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

        public bool DeleteCity(int id)
        {
            try
            {
                var result = dbContext.cities.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
