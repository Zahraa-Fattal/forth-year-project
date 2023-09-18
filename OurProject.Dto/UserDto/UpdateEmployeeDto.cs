using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UserDto
{
  public  class UpdateEmployeeDto
    {
        public List<GetEmployeeInfoDto> getEmployeeInfoDtos { get; set; }
        public AddUserDto UserDto { get; set; }
        public int UserId { get; set; }
    }
}
