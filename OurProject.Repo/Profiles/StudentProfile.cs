using AutoMapper;
using DataBase.Entities;
using DataBase.SBResults;
using OurProject.Dto.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentEntity, AddStudentDto>();
            CreateMap<AddStudentDto, StudentEntity>();


            CreateMap<StudentEntity, GetAllStudentDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllStudentDto, StudentEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));


            CreateMap<GetCountryDto, GetCountrySBR>();
            CreateMap<GetCountrySBR, GetCountryDto>();

            CreateMap<GetMainCityDto, GetMainCitySBR>();
            CreateMap<GetMainCitySBR, GetMainCityDto>();


            CreateMap<GetStudentCountInUniteDto, GetStudentCountInUniteSBR>();
            CreateMap<GetStudentCountInUniteSBR, GetStudentCountInUniteDto>();

            CreateMap<GetLastDateDto, GetLastDateSBR>();
            CreateMap<GetLastDateSBR, GetLastDateDto>();  
            
            
            CreateMap<GetAllUnRecordedStudentsDto, GetAllUnRecordedStudentsSBR>();
            CreateMap<GetAllUnRecordedStudentsSBR, GetAllUnRecordedStudentsDto>();

            CreateMap<GetSpecificStudentDto, GetSpecificStudentSBR>();
            CreateMap<GetSpecificStudentSBR, GetSpecificStudentDto>();


            CreateMap<GetAllRecorderStudentsDto, GetAllRecorderStudentsSBR>();
            CreateMap<GetAllRecorderStudentsSBR, GetAllRecorderStudentsDto>(); 
            
            CreateMap<GetFullInformationDto, GetFullInformationSBR>();
            CreateMap<GetFullInformationSBR, GetFullInformationDto>();
        }
    }
}
