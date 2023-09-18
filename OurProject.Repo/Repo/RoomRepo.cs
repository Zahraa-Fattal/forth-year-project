using AutoMapper;
using DataBase;
using DataBase.Entities;
using OurProject.Dto.RoomDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo
{
    public class RoomRepo : RoomIRepo
    {
        private readonly IMapper mapper;
        private MyDbContext dbContext { get; set; }
        public RoomRepo(IMapper pmapper, MyDbContext _dbContext)
        {
            dbContext = _dbContext;
            mapper = pmapper;
        }
        public bool AddRoom(AddRoomDto dto)
        {
            try
            {
                dbContext.Add(mapper.Map<RoomEntity>(dto));
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRoom(int id)
        {
            try
            {
                var result = dbContext.rooms.FirstOrDefault(c => c.Id == id);
                dbContext.Remove(result);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<GetAllRoomDto> GetAllRoom()
        {
            try
            {
                var result = dbContext.rooms.ToList();
                return mapper.Map<List<GetAllRoomDto>>(result);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateRoom(AddRoomDto dto, int id)
        {
            try
            {
                var result = dbContext.rooms.FirstOrDefault(c => c.Id == id);
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
