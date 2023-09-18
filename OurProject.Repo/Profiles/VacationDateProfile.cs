using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.VacationDateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class VacationDateProfile:Profile
    {

        public VacationDateProfile()
        {
            CreateMap<VacationDateEntity, AddVacationDateDto>();
            CreateMap<AddVacationDateDto, VacationDateEntity>();


            CreateMap<VacationDateEntity, GetAllVacationDateDto>();
            CreateMap<GetAllVacationDateDto, VacationDateEntity>();
        }
    }
}
