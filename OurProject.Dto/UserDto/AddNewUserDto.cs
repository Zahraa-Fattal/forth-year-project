using OurProject.Dto.RoleDto;
using OurProject.Dto.UnitDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UserDto
{
   public class AddNewUserDto
    {
        public AddUserDto userDto { get; set; }
        public List<GetAllRoleDto> getAllRoles { get; set; }
    }
}
