using AutoMapper;
using DataBase.Entities;
using DataBase.SBResults;
using OurProject.Dto.StudentAccessoriesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class StudentAccessoriesProfile:Profile
    {
        public StudentAccessoriesProfile()
        {
            CreateMap<StudentAccessoriesEntity, AddStudentAccessoriesDto>();
            CreateMap<AddStudentAccessoriesDto, StudentAccessoriesEntity>();


            CreateMap<StudentAccessoriesEntity, GetAllStudentAccessoriesDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllStudentAccessoriesDto, StudentAccessoriesEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));

            CreateMap<GetItemsInStoreUnitDto, GetItemsInStoreUnitSBR>();
            CreateMap<GetItemsInStoreUnitSBR, GetItemsInStoreUnitDto>();

            CreateMap<GetItemsByStudentIdDto, GetItemsByStudentIdSBR>();
            CreateMap<GetItemsByStudentIdSBR, GetItemsByStudentIdDto>();

            CreateMap<GetStudentThatHasItemsDto, GetStudentThatHasItemsSBR>();
            CreateMap<GetStudentThatHasItemsSBR, GetStudentThatHasItemsDto>();
        }
    }
}
