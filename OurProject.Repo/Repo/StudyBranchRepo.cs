using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.StudyBranchDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class StudyBranchRepo : StudyBranchIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public StudyBranchRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddStudyBranch(AddStudyBranchDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<StudyBranchEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudyBranch(int id)
        {
            try
            {
                var result = dbContext.studyBranches.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllStudyBranchDto> GetAllStudyBranch()
        {
            try
            {
                var result = dbContext.studyBranches.ToList();
                return mapper.Map<List<GetAllStudyBranchDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateStudyBranch(AddStudyBranchDto dto, int id)
        {
            try
            {
                var result = dbContext.studyBranches.FirstOrDefault(c => c.Id == id);
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
    }
}
