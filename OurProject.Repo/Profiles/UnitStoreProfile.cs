using AutoMapper;
using DataBase.Entities;
using DataBase.SBResults;
using OurProject.Dto.UnitStoreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class UnitStoreProfile:Profile
    {
        public UnitStoreProfile()
        {
            CreateMap<UnitStoreEntity, AddUnitStoreDto>();
            CreateMap<AddUnitStoreDto, UnitStoreEntity>();


            CreateMap<UnitStoreEntity, GetAllUnitStoreDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllUnitStoreDto, UnitStoreEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));

            CreateMap<GetFreeStoreDto, GetFreeStoreSBR>();
            CreateMap<GetFreeStoreSBR, GetFreeStoreDto>();
        }
    }
}
