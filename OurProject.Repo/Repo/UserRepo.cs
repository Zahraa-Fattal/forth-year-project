using AutoMapper;
using DataBase;
using DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using OurProject.Dto.UserDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class UserRepo : UserIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public UserRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext =_dbContext;
            mapper = pmapper;
        }
        public bool AddUser(AddUserDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<UserEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var result = dbContext.user.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllUserDto> GetAllUser()
        {
            try
            {
                var result = dbContext.user.ToList();
                return mapper.Map<List<GetAllUserDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateUser(AddUserDto dto, int id)
        {
            try
            {
                var result = dbContext.user.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.RoleId != 0)
                    {
                        result.RoleId = dto.RoleId;
                    }
                    if (!string.IsNullOrEmpty(dto.Image))
                    {
                        result.Image = dto.Image;
                    } 
                    if (!string.IsNullOrEmpty(dto.Password))
                    {
                        result.Password = dto.Password;
                    } 
                    if (!string.IsNullOrEmpty(dto.PhoneNumber))
                    {
                        result.PhoneNumber = dto.PhoneNumber;
                    } 
                    if (!string.IsNullOrEmpty(dto.UserName))
                    {
                        result.UserName = dto.UserName;
                    }
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
                    }
                    if (dto.Date!=DateTime.MinValue)
                    {
                        result.Date = dto.Date;
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

        public GetAllUserDto GetUser(UserLogInDto LogInDto)
        {
            try
            {
                var result = dbContext.user.FirstOrDefault(x => x.UserName.ToLower() == LogInDto.UserName.ToLower() && x.Password.ToLower() == LogInDto.Password.ToLower());
                return mapper.Map<GetAllUserDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetSuperVisorInfoDto> GetSuperVisorInfo()
        {
            try
            {
                string sql = "exec [dbo].[GetSuperVisorInfo]";
                var Result = dbContext.GetSuperVisorInfoSBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetSuperVisorInfoDto>>(Result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int AddUserWithIdReturn(AddUserDto dto)
        {
            try
            {
               var result= dbContext.Add(mapper.Map<UserEntity>(dto));
                dbContext.SaveChanges();
                return result.Entity.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public List<GetStoreKeeperInfoDto> GetStoreKeeperInfo()
        {
            try
            {
                string sql = "exec [dbo].[GetStoreKeeperInfo]";
                var Result = dbContext.GetStoreKeeperInfoSBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetStoreKeeperInfoDto>>(Result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GetFreeSuperVisorDto> GetFreeSuperVisor()
        {
            try
            {
                string sql = "exec [dbo].[GetFreeSuperVisor]";
                var Result = dbContext.GetFreeSuperVisorSBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetFreeSuperVisorDto>>(Result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public List<GetEmployeeInfoDto> GetEmployeeInfo()
        {
            try
            {
                string sql = "exec [dbo].[GetEmployeeInfo]";
                var Result = dbContext.GetEmployeeInfoSBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetEmployeeInfoDto>>(Result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GetFreeStoreKeeperDto> GetFreeStoreKeeper()
        {
            try
            {
                string sql = "exec [dbo].[GetFreeStoreKeeper]";
                var Result = dbContext.GetFreeStoreKeeperSBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetFreeStoreKeeperDto>>(Result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool IsuserNameAvailable(string userName)
        {
            try
            {
                var result = dbContext.user.FirstOrDefault(x => x.UserName == userName);
                if (result == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
