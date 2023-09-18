using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.StoreDetailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class StoreDetailProfile:Profile
    {
        public StoreDetailProfile()
        {
            CreateMap<StoreDetailEntity, AddStoreDetailDto>();
            CreateMap<AddStoreDetailDto, StoreDetailEntity>();


            CreateMap<StoreDetailEntity, GetAllStoreDetailDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllStoreDetailDto, StoreDetailEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));
        }
    }
}
