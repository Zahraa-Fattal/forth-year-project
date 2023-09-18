using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.StudentDateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
  public class StudentDateProfile:Profile
    {
        public StudentDateProfile()
        {
            CreateMap<StudentDateEntity, AddStudentDateDto>();
            CreateMap<AddStudentDateDto, StudentDateEntity>();


            CreateMap<StudentDateEntity, GetAllStudentDateDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllStudentDateDto, StudentDateEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));
        }
    }
}
