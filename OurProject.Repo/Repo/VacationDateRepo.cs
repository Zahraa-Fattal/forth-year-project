using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.VacationDateDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Repo
{
    public class VacationDateRepo : VacationDateIRepo
    {

        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public VacationDateRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }

        public bool AddVacationDate(AddVacationDateDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<VacationDateEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteVacationDate(int id)
        {
            try
            {
                var result = dbContext.vacationDates.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllVacationDateDto> GetAllVacationDate()
        {
            try
            {
                var result = dbContext.vacationDates.ToList();
                return mapper.Map<List<GetAllVacationDateDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateVacationDate(AddVacationDateDto dto, int id)
        {
            try
            {
                var result = dbContext.vacationDates.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.date!=DateTime.MinValue)
                    {
                        result.date = dto.date;
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
