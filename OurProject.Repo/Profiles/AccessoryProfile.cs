using AutoMapper;
using DataBase.Entities;
using DataBase.SBResults;
using OurProject.Dto.AccessoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class AccessoryProfile:Profile
    {
        public AccessoryProfile() 
        {
            CreateMap<AccessoryEntity, AddAccessoryDto>();
            CreateMap<AddAccessoryDto, AccessoryEntity>(); 
            
            CreateMap<AccessoryEntity, GetAllAccessoryDto>();
            CreateMap<GetAllAccessoryDto, AccessoryEntity>();


            CreateMap<RoleEntity, GetAllAccessoryDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllAccessoryDto, RoleEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));

            CreateMap<GetAccessoriesDetailsDto, GetAccessoriesDetailsSBR>();
            CreateMap<GetAccessoriesDetailsSBR, GetAccessoriesDetailsDto>();
        }
    }
}
