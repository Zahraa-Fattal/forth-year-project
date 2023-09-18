using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.RoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class RoomProfile:Profile
    {
        public RoomProfile()
        {
            CreateMap<RoomEntity, AddRoomDto>();
            CreateMap<AddRoomDto, RoomEntity>();


            CreateMap<RoomEntity, GetAllRoomDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllRoomDto, RoomEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));
        }
    }
}
