using OurProject.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface UserIRepo
    {
        public bool AddUser(AddUserDto dto);
        public int AddUserWithIdReturn(AddUserDto dto);
        public List<GetAllUserDto> GetAllUser();
        public bool UpdateUser(AddUserDto dto, int id);
        public bool DeleteUser(int id);
        public GetAllUserDto GetUser(UserLogInDto LogInDto);
        public bool IsuserNameAvailable(string userName);
        public List<GetSuperVisorInfoDto> GetSuperVisorInfo();
        public List<GetStoreKeeperInfoDto> GetStoreKeeperInfo();
        public List<GetFreeSuperVisorDto> GetFreeSuperVisor();
        public List<GetFreeStoreKeeperDto> GetFreeStoreKeeper();
        public List<GetEmployeeInfoDto> GetEmployeeInfo();


    }
}
