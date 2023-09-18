using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.CityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
  public class CityProfile:Profile
    {
        public CityProfile()
        {
            CreateMap<CityEntity, AddCityDto>();
            CreateMap<AddCityDto, CityEntity>();


            CreateMap<CityEntity, GetAllCityDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllCityDto, CityEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));
        }
    }
}
