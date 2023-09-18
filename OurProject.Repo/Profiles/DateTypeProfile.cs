using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.DateTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class DateTypeProfile:Profile
    {
        public DateTypeProfile()
        {
            CreateMap<DateTypeEntity, AddDateTypeDto>();
            CreateMap<AddDateTypeDto, DateTypeEntity>();


            CreateMap<DateTypeEntity, GetAllDateTypeDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllDateTypeDto, DateTypeEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));
        }
    }
}
