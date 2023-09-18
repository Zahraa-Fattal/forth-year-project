using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.StudentDateDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class StudentDateRepo : StudentDateIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public StudentDateRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext =_dbContext;
            mapper = pmapper;
        }
        public bool AddStudentDate(AddStudentDateDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<StudentDateEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudentDate(int id)
        {
            try
            {
                dbContext.studentDates.FirstOrDefault(c => c.StudentId == id);
                var result = dbContext.studentDates.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllStudentDateDto> GetAllStudentDate()
        {
            try
            {
                var result = dbContext.studentDates.ToList();
                return mapper.Map<List<GetAllStudentDateDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateStudentDate(AddStudentDateDto dto, int id)
        {
            try
            {
                var result = dbContext.studentDates.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.DateTypeId != 0)
                    {
                        result.DateTypeId = dto.DateTypeId;
                    }
                    if (dto.Price != 0)
                    {
                        result.Price = dto.Price;
                    }
                    if (dto.StudentId != 0)
                    {
                        result.StudentId = dto.StudentId;
                    }
                    if (dto.date != DateTime.MinValue)
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

        public GetAllStudentDateDto GetStudentDateByUserId(int studentId)
        {
            try
            {
                var result = dbContext.studentDates.FirstOrDefault(c=>c.StudentId==studentId);
                return mapper.Map<GetAllStudentDateDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
