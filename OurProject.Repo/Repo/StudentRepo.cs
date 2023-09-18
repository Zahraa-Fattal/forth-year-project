using AutoMapper;
using DataBase;
using DataBase.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OurProject.Dto.StudentDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class StudentRepo : StudentIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public StudentRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddStudent(AddStudentDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<StudentEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllStudentDto> GetAllStudent()
        {
            try
            {
                var result = dbContext.students.ToList();
                return mapper.Map<List<GetAllStudentDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public GetAllStudentDto GetOneStudentByStudentId(int id)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(c => c.Id == id);
                return mapper.Map<GetAllStudentDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool UpdateOldStudent(AddStudentDto dto, int id)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.CityId != 0)
                    {
                        result.CityId = dto.CityId;
                    }

                    result.Gender = dto.Gender;

                    if (!string.IsNullOrEmpty(dto.Image))
                    {
                        result.Image = dto.Image;
                    }
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
                    }
                    if (!string.IsNullOrEmpty(dto.NationalId))
                    {
                        result.NationalId = dto.NationalId;
                    }

                    result.Recorded = dto.Recorded;

                    if (dto.StudyBranchId != 0)
                    {
                        result.StudyBranchId = dto.StudyBranchId;
                    }
               
                    if (!string.IsNullOrEmpty(dto.UniversityId))
                    {
                        result.UniversityId = dto.UniversityId;
                    }
                    if (!string.IsNullOrEmpty(dto.PhoneNumber))
                    {
                        result.PhoneNumber = dto.PhoneNumber;
                    }
                    if (dto.SuggestedUnitId != 0)
                    {
                        result.SuggestedUnitId = dto.SuggestedUnitId;
                    }
                   
                    if (!string.IsNullOrEmpty(dto.Email))
                    {
                        result.Email = dto.Email;
                    }
                    result.IsDeleted = dto.IsDeleted;
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
        public bool UpdateStudent(AddStudentDto dto, int id)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.CityId != 0)
                    {
                        result.CityId = dto.CityId;
                    }
                    
                    result.Gender = dto.Gender;

                    if (!string.IsNullOrEmpty(dto.Image))
                    {
                        result.Image = dto.Image;
                    }
                    if (!string.IsNullOrEmpty(dto.Name))
                    {
                        result.Name = dto.Name;
                    }  
                    if (!string.IsNullOrEmpty(dto.NationalId))
                    {
                        result.NationalId = dto.NationalId;
                    }  

                    result.Recorded = dto.Recorded;

                    if (dto.StudyBranchId!=0)
                    {
                        result.StudyBranchId = dto.StudyBranchId;
                    } 
                    if (dto.UnitRoomFk!=0)
                    {
                        result.UnitRoomFk = dto.UnitRoomFk;
                    } 
                    if (!string.IsNullOrEmpty(dto.UniversityId))
                    {
                        result.UniversityId = dto.UniversityId;
                    }
                    if (!string.IsNullOrEmpty(dto.PhoneNumber))
                    {
                        result.PhoneNumber = dto.PhoneNumber;
                    }
                    if (dto.SuggestedUnitId!=0)
                    {
                        result.SuggestedUnitId = dto.SuggestedUnitId;
                    }  
                    if (dto.RecordedDate!=DateTime.MinValue)
                    {
                        result.RecordedDate = dto.RecordedDate;
                    } 
                    if (dto.AccessoriesDate!=DateTime.MinValue)
                    {
                        result.AccessoriesDate = dto.AccessoriesDate;
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

        public bool UpdateStudent_IsDeleted(AddStudentDto dto, int id)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (result.UnitRoomFk != null)
                    {
                        result.OldUnitRoomFk = result.UnitRoomFk.Value;
                    }

                    if (dto.UnitRoomFk != 0)
                    {
                        result.UnitRoomFk = dto.UnitRoomFk;
                    }
                   
                    result.IsDeleted = dto.IsDeleted;
               
                 
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
        public List<GetMainCityDto> GetMainCity()
        {
            try
            {
                string sql = "exec [dbo].[GetMainCity]";
                var result = dbContext.GetMainCitySBRs.FromSqlRaw(sql).ToList();
                return mapper.Map<List<GetMainCityDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GetCountryDto> GetCountry(int MainCityId)
        {
            try
            {
                string sql = "exec [dbo].[GetCountry]  @MainCityId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@MainCityId", Value = MainCityId}
                };
                var result = dbContext.GetCountrySBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetCountryDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public GetStudentCountInUniteDto GetStudentCount(int StudyBranchId, bool Gender)
        {
            try
            {
                string sql = "exec [dbo].[GetStudentCountInUnite] @StudyBranchId, @Gender";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@StudyBranchId", Value = StudyBranchId},
                  new SqlParameter { ParameterName = "@Gender", Value = Gender}
                };
                var result = dbContext.GetStudentCountInUniteSBRs.FromSqlRaw(sql, parms.ToArray()).ToList().FirstOrDefault();
                return mapper.Map<GetStudentCountInUniteDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public GetLastDateDto GetLastDate(int SuggestedUnitId)
        {
            try
            {
                string sql = "exec [dbo].[GetLastDate] @UnitId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@UnitId", Value = SuggestedUnitId}
                };
                var result = dbContext.GetLastDateSBRs.FromSqlRaw(sql, parms.ToArray()).ToList().FirstOrDefault();
                return mapper.Map<GetLastDateDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int AddStudentWithIdReturn(AddStudentDto dto)
        {
            try
            {
                var result = dbContext.Add(mapper.Map<StudentEntity>(dto));
                dbContext.SaveChanges();
                return (result.Entity.Id);
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public bool IsuserNameAvailable(string email)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(x => x.Email == email);
                if (result == null)
                {
                    return true;
                }
                else if (result.IsDeleted==true)
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

        public GetAllStudentDto GetStudentByNationalId(string NationalId)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(x => x.NationalId.ToLower() == NationalId.ToLower());
                return mapper.Map<GetAllStudentDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public GetAllStudentDto GetStudentById(int Id)
        {
            try
            {
                var result = dbContext.students.FirstOrDefault(x => x.Id == Id);
                return mapper.Map<GetAllStudentDto>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GetAllUnRecordedStudentsDto> GetAllStudentsInfo(int UnitId)
        {
            try
            {
                string sql = "exec [dbo].[GetAllStudentsInfo] @UnitId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@UnitId", Value = UnitId}
                };
                var result = dbContext.GetAllUnRecordedStudentsSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetAllUnRecordedStudentsDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public GetSpecificStudentDto GetSpecificStudent(int StudentId)
        {
            try
            {
                string sql = "exec [dbo].[GetSpecificStudent] @studentId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@studentId", Value = StudentId}
                };
                var result = dbContext.GetSpecificStudentSBRs.FromSqlRaw(sql, parms.ToArray()).ToList().FirstOrDefault();
                return mapper.Map<GetSpecificStudentDto>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetAllRecorderStudentsDto> GetAllRecorderStudents(int UnitId)
        {
            try
            {
                string sql = "exec [dbo].[GetAllRecorderStudents] @uniteId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@uniteId", Value = UnitId}
                };
                var result = dbContext.GetAllRecorderStudentsSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetAllRecorderStudentsDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<GetAllRecorderStudentsDto> SearchForRecorderStudents(int UnitId,string nationalId)
        {
            try
            {
                string sql = "exec [dbo].[GetAllRecorderStudents] @uniteId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@uniteId", Value = UnitId}
                };
                var result = dbContext.GetAllRecorderStudentsSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
              var x= result.FindAll(x => x.NationalId == nationalId);
                return mapper.Map<List<GetAllRecorderStudentsDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<GetFullInformationDto> GetFullInformation(int UnitId)
        {
            try
            {
                string sql = "exec [dbo].[GetFullInformation] @unitId";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                  // Create parameter(s)    
                  new SqlParameter { ParameterName = "@unitId", Value = UnitId}
                };
                var result = dbContext.GetFullInformation.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetFullInformationDto>>(result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
