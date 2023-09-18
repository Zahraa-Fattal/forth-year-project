using AutoMapper;
using DataBase;
using DataBase.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OurProject.Dto.UnitRoomDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class UnitRoomRepo : UnitRoomIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public UnitRoomRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddUnitRoom(AddUnitRoomDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<UnitRoomEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUnitRoom(int id)
        {
            try
            {
                var result = dbContext.unitRooms.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllUnitRoomDto> GetAllUnitRoom()
        {
            try
            {
                var result = dbContext.unitRooms.ToList();
                return mapper.Map<List<GetAllUnitRoomDto>>(result);
            }
            catch (Exception)
            {
                return null;
               
            }
        }
        public AddUnitRoomDto GetUnitRoomById(int id)
        {
            try
            {
                var result = dbContext.unitRooms.FirstOrDefault(c=>c.Id==id);
                return mapper.Map<AddUnitRoomDto>(result);
            }
            catch (Exception)
            {
                return null;

            }
        }
        public List<getFreeRoomsByUnitIdDto> GetAllFreeUnitRoom(int UnitId)
        {
            try
            {
                string sql = "exec [dbo].[getFreeRoomsByUnitId] @UnitId";
                List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@UnitId", Value = UnitId}
            };
                var Result = dbContext.GetFreeRoomsByUnitIdSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<getFreeRoomsByUnitIdDto>>(Result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool UpdateUnitRoom(AddUnitRoomDto dto, int id)
        {
            try
            {
                var result = dbContext.unitRooms.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    if (dto.RoomId!=0)
                    {
                        result.RoomId = dto.RoomId;
                    }
                    if (dto.StudentCount != -1)
                    {
                        result.StudentCount = dto.StudentCount;
                    }
                    if (dto.UnitId != 0)
                    {
                        result.UnitId = dto.UnitId;
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

        public bool UpdateUnitRoomForExitStudent( int id)
        {
            try
            {
                var result = dbContext.unitRooms.FirstOrDefault(c => c.Id == id);
                if (result != null)
                {
                    result.StudentCount --;
                  
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
        public List<GetRoomsInUnitDto> GetRoomsInUnit(int unitId)
        {
            try
            {
                string sql = "exec [dbo].[GetRoomsInUnit] @UnitId";
                List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@UnitId", Value = unitId}
            };
                var Result = dbContext.GetRoomsInUnitSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetRoomsInUnitDto>>(Result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetStudentInRoomDto> GetStudentInRoom(int unitId, int unitRoomId)
        {
            try
            {
                string sql = "exec [dbo].[GetStudentInRoom] @UnitId, @UnitRoomId";
                List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@UnitId", Value = unitId},
                new SqlParameter { ParameterName = "@UnitRoomId", Value = unitRoomId}
            };
                var Result = dbContext.GetStudentInRoomSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetStudentInRoomDto>>(Result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetRoomsInUnitDto> GetRoomsInUnitByDate(int unitId, DateTime minDate, DateTime maxDate)
        {
            try
            {
                string sql = "exec [dbo].[GetRoomInUnitByDate] @unitId,@minDate,@maxDate";
                List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@unitId", Value = unitId},
                new SqlParameter { ParameterName = "@minDate", Value = minDate},
                new SqlParameter { ParameterName = "@maxDate", Value = maxDate}
            };
                var Result = dbContext.GetRoomsInUnitSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetRoomsInUnitDto>>(Result);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<GetStudentInRoomDto> GetStudentInRoomByDate(int unitId, int unitRoomId, DateTime minDate, DateTime maxDate)
        {
            try
            {
                string sql = "exec [dbo].[GetStudentInRoomByDate] @unitId, @unitRoomId,@minDate,@maxDate";
                List<SqlParameter> parms = new List<SqlParameter>
            {
                // Create parameter(s)    
                new SqlParameter { ParameterName = "@unitId", Value = unitId},
                new SqlParameter { ParameterName = "@unitRoomId", Value = unitRoomId},
                new SqlParameter { ParameterName = "@minDate", Value = minDate},
                new SqlParameter { ParameterName = "@maxDate", Value = maxDate}
            };
                var Result = dbContext.GetStudentInRoomSBRs.FromSqlRaw(sql, parms.ToArray()).ToList();
                return mapper.Map<List<GetStudentInRoomDto>>(Result);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
