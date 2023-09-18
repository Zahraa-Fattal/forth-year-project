using OurProject.Dto.RoleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface RoleIRepo
    {
        public bool AddRole(AddRoleDto dto);
        public List<GetAllRoleDto> GetAllRole();
        public bool UpdateRole(AddRoleDto dto, int id);
        public bool DeleteRole(int id);

    }
}
