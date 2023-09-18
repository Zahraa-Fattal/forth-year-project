using AutoMapper;
using DataBase.Entities;
using DataBase.SBResults;
using OurProject.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity, AddUserDto>();
            CreateMap<AddUserDto, UserEntity>();


            CreateMap<UserEntity, GetAllUserDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllUserDto, UserEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));

            CreateMap<GetSuperVisorInfoDto, GetSuperVisorInfoSBR>();
            CreateMap<GetSuperVisorInfoSBR, GetSuperVisorInfoDto>();

            CreateMap<GetStoreKeeperInfoDto, GetStoreKeeperInfoSBR>();
            CreateMap<GetStoreKeeperInfoSBR, GetStoreKeeperInfoDto>();
            
            CreateMap<GetFreeSuperVisorDto, GetFreeSuperVisorSBR>();
            CreateMap<GetFreeSuperVisorSBR, GetFreeSuperVisorDto>();
            
            CreateMap<GetFreeStoreKeeperDto, GetFreeStoreKeeperSBR>();
            CreateMap<GetFreeStoreKeeperSBR, GetFreeStoreKeeperDto>();
            
            CreateMap<GetEmployeeInfoSBR, GetEmployeeInfoDto>();
            CreateMap<GetEmployeeInfoDto, GetEmployeeInfoSBR>();
        }
    }
}
