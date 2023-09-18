using AutoMapper;
using DataBase.Entities;
using DataBase.SBResults;
using OurProject.Dto.UnitDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class UnitProfile:Profile
    {
        public UnitProfile()
        {
            CreateMap<UnitEntity, AddUnitDto>();
            CreateMap<AddUnitDto, UnitEntity>();


            CreateMap<UnitEntity, GetAllUnitDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllUnitDto, UnitEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));

            CreateMap<GetAllUnitsInfoDto, GetAllUnitsInfoSBR>();
            CreateMap<GetAllUnitsInfoSBR, GetAllUnitsInfoDto>();


            CreateMap<GetSpecificUnitDto, GetSpecificUnitSBR>();
            CreateMap<GetSpecificUnitSBR, GetSpecificUnitDto>();
        }
    }
}
