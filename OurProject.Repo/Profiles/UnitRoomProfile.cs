using AutoMapper;
using DataBase.Entities;
using DataBase.SBResults;
using OurProject.Dto.UnitRoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class UnitRoomProfile:Profile
    {
        public UnitRoomProfile()
        {
            CreateMap<UnitRoomEntity, AddUnitRoomDto>();
            CreateMap<AddUnitRoomDto, UnitRoomEntity>();


            CreateMap<UnitRoomEntity, GetAllUnitRoomDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllUnitRoomDto, UnitRoomEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));


            CreateMap<getFreeRoomsByUnitIdDto, getFreeRoomsByUnitIdSBR>();
            CreateMap<getFreeRoomsByUnitIdSBR, getFreeRoomsByUnitIdDto>();


            CreateMap<GetRoomsInUnitDto, GetRoomsInUnitSBR>();
            CreateMap<GetRoomsInUnitSBR, GetRoomsInUnitDto>();


            CreateMap<GetStudentInRoomDto, GetStudentInRoomSBR>();
            CreateMap<GetStudentInRoomSBR, GetStudentInRoomDto>();
        }
    }
}
