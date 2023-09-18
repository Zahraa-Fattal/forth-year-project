using AutoMapper;
using DataBase.Entities;
using OurProject.Dto.RoleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Repo.Profiles
{
   public class RoleProfile:Profile
    {
        public RoleProfile() 
        {
            CreateMap<RoleEntity, AddRoleDto>();
            CreateMap<AddRoleDto, RoleEntity>();


            CreateMap<RoleEntity, GetAllRoleDto>()
              .ForMember(des => des.id, src => src.MapFrom(c => c.Id));
            CreateMap<GetAllRoleDto, RoleEntity>()
             .ForMember(des => des.Id, src => src.MapFrom(c => c.id));
        }
    }
}
