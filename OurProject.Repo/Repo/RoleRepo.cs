using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.RoleDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class RoleRepo : RoleIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public RoleRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddRole(AddRoleDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<RoleEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(int id)
        {

            try
            {
                var result = dbContext.role.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllRoleDto> GetAllRole()
        {
            try
            {
                var result = dbContext.role.ToList();
                return mapper.Map<List<GetAllRoleDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateRole(AddRoleDto dto, int id)
        {
            try
            {
                var result = dbContext.role.FirstOrDefault(c => c.Id == id);
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
