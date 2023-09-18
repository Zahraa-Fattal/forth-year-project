using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.StudyBranchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class StudyBranchProfile:Profile
    {
        public StudyBranchProfile()
        {
            CreateMap<StudyBranchEntity, AddStudyBranchDto>();
            CreateMap<AddStudyBranchDto, StudyBranchEntity>();


            CreateMap<StudyBranchEntity, GetAllStudyBranchDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllStudyBranchDto, StudyBranchEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));
        }
    }
}
