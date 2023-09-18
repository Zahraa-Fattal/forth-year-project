using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UserDto
{
   public class UpdateStoreKeeperDto
    {
        public List<GetStoreKeeperInfoDto> getStoreKeeperInfos { get; set; }
        public AddUserDto UserDto { get; set; }
        public int UserId { get; set; }
    }
}
