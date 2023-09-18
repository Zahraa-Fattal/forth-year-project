using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OurProject.Dto.StudentDto;
using OurProject.Dto.UnitDto;
using OurProject.Dto.UnitRoomDto;
using OurProject.Dto.UserDto;
using OurProject.IRepo;
using OurProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OurProject.Controllers
{
    public class ManegerController : Controller
    {
        private readonly ILogger<ManegerController> _logger;
        private readonly UnitIRepo _unitIRepo;
        private readonly UserIRepo _userIRepo;
        private readonly RoleIRepo _roleIRepo;
        private readonly StudyBranchIRepo _studyBranchIRepo;
        private readonly UnitStoreIRepo _unitStoreIRepo;
        private readonly StudentIRepo _StudentIRepo;
        private readonly RoomIRepo _RoomIRepo;
        private readonly UnitRoomIRepo _UnitRoomIRepo;
        public ManegerController
           (
           ILogger<ManegerController> logger, UnitIRepo unitIRepo
            , UserIRepo userIRepo, RoleIRepo roleIRepo, StudyBranchIRepo studyBranchIRepo
            , UnitStoreIRepo unitStoreIRepo, StudentIRepo StudentIRepo, RoomIRepo RoomIRepo
            , UnitRoomIRepo UnitRoomIRepo
           )
        {
            _logger = logger;
            _unitIRepo = unitIRepo;
            _userIRepo = userIRepo;
            _roleIRepo = roleIRepo;
            _studyBranchIRepo = studyBranchIRepo;
            _unitStoreIRepo = unitStoreIRepo;
            _StudentIRepo = StudentIRepo;
            _RoomIRepo = RoomIRepo;
            _UnitRoomIRepo = UnitRoomIRepo;
        }
        public IActionResult HomeBtn()
        {
            var x = _unitIRepo.GetAllUnitInfo();
            Program.JavascriptToRun = "";
            return View("MainManegerView", x);
        }
     
        public IActionResult SuperVisorSettingBtn()
        {
            UpdateSuperVisorDto updateSuperVisorDto = new UpdateSuperVisorDto()
            {
                getSuperVisorInfos = _userIRepo.GetSuperVisorInfo(),
            };
            Program.JavascriptToRun = "";
            return View("SuperVisorSettingView", updateSuperVisorDto);
        }   
        public IActionResult UpdateSuperVisor(UpdateSuperVisorDto updateSuperVisorDto)
        {

            if (_userIRepo.UpdateUser(updateSuperVisorDto.UserDto, updateSuperVisorDto.UserId)) 
            {
                UpdateSuperVisorDto superVisorDto  = new UpdateSuperVisorDto()
                {
                    getSuperVisorInfos = _userIRepo.GetSuperVisorInfo(),
                };
                Program.JavascriptToRun = "toastr.success('تم التعديل بنجاح')";
                return View("SuperVisorSettingView", superVisorDto);
            }
            else
            {
                UpdateSuperVisorDto superVisorDto = new UpdateSuperVisorDto()
                {
                    getSuperVisorInfos = _userIRepo.GetSuperVisorInfo(),
                };
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية التعديل')";
                return View("SuperVisorSettingView", superVisorDto);
            }


        }
        public IActionResult DeleteSuperVisor(UpdateEmployeeDto dto)
        {
            if (_userIRepo.DeleteUser(dto.UserId))
            {
                UpdateEmployeeDto result = new UpdateEmployeeDto()
                {
                    getEmployeeInfoDtos = _userIRepo.GetEmployeeInfo(),
                };
                Program.JavascriptToRun = "toastr.success('تم الحذف بنجاح')";
                return View("EmployeeSettingView", result);
            }
            else
            {
                UpdateEmployeeDto result = new UpdateEmployeeDto()
                {
                    getEmployeeInfoDtos = _userIRepo.GetEmployeeInfo(),
                };
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية الحذف')";
                return View("EmployeeSettingView", result);
            }


        }
        public IActionResult AddUserBtn()
        {
            AddNewUserDto addNewUserDto = new AddNewUserDto
            {
                getAllRoles = _roleIRepo.GetAllRole(),
                
            };
            addNewUserDto.getAllRoles=addNewUserDto.getAllRoles.FindAll(x => x.id != 1);
            Program.JavascriptToRun = "";
            return View("AddUserView", addNewUserDto);
        } 
        public IActionResult AddUser(AddNewUserDto newUserDto)
        {
           
            Random random = new Random();
            newUserDto.userDto.Password = random.Next(1, int.MaxValue).ToString();
            if (newUserDto.userDto.RoleId == 2)
            {
                if (_userIRepo.AddUser(newUserDto.userDto))
                {
                    using (StreamReader streamReader = new StreamReader(@"C:\Users\Wael\Desktop\OurProject\OurProject\wwwroot\googleTemplet.txt"))
                    {
                        string bodyGoogle = streamReader.ReadToEnd();
                        bodyGoogle = bodyGoogle.Replace("username", newUserDto.userDto.UserName);
                        bodyGoogle = bodyGoogle.Replace("password", newUserDto.userDto.Password);
                        bodyGoogle = bodyGoogle.Replace("name", newUserDto.userDto.Name);
                        bodyGoogle = bodyGoogle.Replace("role", "مشرف");
                    
                    var smtpClient = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("wael.badawi2000@gmail.com", "trylithcjgbfblzm"),
                        EnableSsl = true,
                    };
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress("wael.badawi2000@gmail.com"),
                        Subject = "السكن الجامعي",
                        Body = bodyGoogle,
                        IsBodyHtml = true,
                    };
                    mailMessage.To.Add(newUserDto.userDto.UserName);

                    smtpClient.Send(mailMessage);
                };
                UpdateSuperVisorDto superVisorDto = new UpdateSuperVisorDto()
                    {
                        getSuperVisorInfos = _userIRepo.GetSuperVisorInfo(),
                    };
                    Program.JavascriptToRun = "toastr.success('تم إضافة مشرف جديد بنجاح')";
                    return View("SuperVisorSettingView", superVisorDto);
                }
            }
           else if (newUserDto.userDto.RoleId == 3)
            {
                if (_userIRepo.AddUser(newUserDto.userDto))
                {
                    using (StreamReader streamReader = new StreamReader(@"C:\Users\Wael\Desktop\OurProject\OurProject\wwwroot\googleTemplet.txt"))
                    {
                        string bodyGoogle = streamReader.ReadToEnd();
                        bodyGoogle = bodyGoogle.Replace("username", newUserDto.userDto.UserName);
                        bodyGoogle = bodyGoogle.Replace("password", newUserDto.userDto.Password);
                        bodyGoogle = bodyGoogle.Replace("name", newUserDto.userDto.Name);
                        bodyGoogle = bodyGoogle.Replace("role", "أمين مستودع");

                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential("wael.badawi2000@gmail.com", "trylithcjgbfblzm"),
                            EnableSsl = true,
                        };
                        var mailMessage = new MailMessage
                        {
                            From = new MailAddress("wael.badawi2000@gmail.com"),
                            Subject = "السكن الجامعي",
                            Body = bodyGoogle,
                            IsBodyHtml = true,
                        };
                        
                        mailMessage.To.Add(newUserDto.userDto.UserName);
                        smtpClient.Send(mailMessage);
                    };
                    UpdateStoreKeeperDto updateStoreKeeperDto = new UpdateStoreKeeperDto()
                    {
                        getStoreKeeperInfos = _userIRepo.GetStoreKeeperInfo(),
                    };
                    Program.JavascriptToRun = "toastr.success('تم إضافة أمين مستودع جديد بنجاح')";
                    return View("StoreKeeperSettingView", updateStoreKeeperDto);
                }
            }
           
            AddNewUserDto addNewUserDto = new AddNewUserDto
            {
                getAllRoles = _roleIRepo.GetAllRole(),
            };
            addNewUserDto.getAllRoles = addNewUserDto.getAllRoles.FindAll(x => x.id != 1);
            Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية الإضافة')";
            return View("AddUserView", addNewUserDto);
        }  
        public IActionResult StoreKeeperSettingBtn()
        {
            UpdateStoreKeeperDto updateStoreKeeperDto = new UpdateStoreKeeperDto()
            {
                getStoreKeeperInfos = _userIRepo.GetStoreKeeperInfo(),
            };
            Program.JavascriptToRun = "";
            return View("StoreKeeperSettingView", updateStoreKeeperDto);
        }
        public IActionResult UpdateStoreKeeper(UpdateStoreKeeperDto updateStoreKeeperDto)
        {

            if (_userIRepo.UpdateUser(updateStoreKeeperDto.UserDto, updateStoreKeeperDto.UserId))
            {
                UpdateStoreKeeperDto storeKeeperDto = new UpdateStoreKeeperDto()
                {
                    getStoreKeeperInfos = _userIRepo.GetStoreKeeperInfo(),
                    
            };
                Program.JavascriptToRun ="toastr.success('تم التعديل بنجاح')";
                return View("StoreKeeperSettingView", storeKeeperDto);
            }
            else
            {
                UpdateStoreKeeperDto storeKeeperDto = new UpdateStoreKeeperDto()
                {
                    getStoreKeeperInfos = _userIRepo.GetStoreKeeperInfo(),
                };
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية التعديل')";
                return View("StoreKeeperSettingView", storeKeeperDto);
            }


        }
        public IActionResult DeleteStoreKeeper(UpdateStoreKeeperDto updateStoreKeeperDto)
        {
            if (_userIRepo.DeleteUser(updateStoreKeeperDto.UserId))
            {
                UpdateStoreKeeperDto storeKeeperDto = new UpdateStoreKeeperDto()
                {
                    getStoreKeeperInfos = _userIRepo.GetStoreKeeperInfo(),
                };
                Program.JavascriptToRun ="toastr.success('تم الحذف بنجاح')";
                return View("StoreKeeperSettingView", storeKeeperDto);
            }
            else
            {
                UpdateStoreKeeperDto storeKeeperDto = new UpdateStoreKeeperDto()
                {
                    getStoreKeeperInfos = _userIRepo.GetStoreKeeperInfo(),
                };
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية الحذف')";
                return View("StoreKeeperSettingView", storeKeeperDto);
            }


        }
        public IActionResult AddUnitBtn()
        {
            AddNewUnitDto addNewUnitDto = new AddNewUnitDto
            {
                StoreKeepers = _userIRepo.GetFreeStoreKeeper(),
                SuperVisors = _userIRepo.GetFreeSuperVisor(),
                studyBranchs = _studyBranchIRepo.GetAllStudyBranch(),
                unitStores = _unitStoreIRepo.GetFreeStore()
            };
            Program.JavascriptToRun ="";
            return View("AddUnitView", addNewUnitDto);
        }
        public IActionResult AddUnit(AddNewUnitDto newUnitDto)
        {
            if (newUnitDto.male)
            {
                newUnitDto.UnitDto.Gender = true;
            }
            else
            {
                newUnitDto.UnitDto.Gender = false;

            }
            int unitId = _unitIRepo.AddUnitWithIdReturn(newUnitDto.UnitDto);
            if (unitId!=-1)
            {
               var allRoom= _RoomIRepo.GetAllRoom();
                AddUnitRoomDto UnitRoom = new AddUnitRoomDto();
                for (int i = 0; i < allRoom.Count; i++)
                {
                    UnitRoom.RoomId = allRoom[i].id;
                    UnitRoom.StudentCount = 0;
                    UnitRoom.UnitId = unitId;
                    _UnitRoomIRepo.AddUnitRoom(UnitRoom);
                }
                Program.JavascriptToRun = "toastr.success('تم إضافة وحدة جديدة بنجاح')";
                return View("MainManegerView", _unitIRepo.GetAllUnitInfo());
            }
            else
            {
                AddNewUnitDto addNewUnitDto = new AddNewUnitDto
                {
                    StoreKeepers = _userIRepo.GetFreeStoreKeeper(),
                    SuperVisors = _userIRepo.GetFreeSuperVisor(),
                    studyBranchs = _studyBranchIRepo.GetAllStudyBranch(),
                    unitStores = _unitStoreIRepo.GetFreeStore()
                };
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية الإضافة')";
                return View("AddUnitView", addNewUnitDto);
            }
           
        }  
        public IActionResult EditUnit(int id)
        {
            UpdateUnitDto addNewUnitDto = new UpdateUnitDto
            {
                StoreKeepers = _userIRepo.GetFreeStoreKeeper(),
                SuperVisors = _userIRepo.GetFreeSuperVisor(),
                studyBranchs = _studyBranchIRepo.GetAllStudyBranch(),
                unitStores = _unitStoreIRepo.GetFreeStore(),
                UnitDto= _unitIRepo.GetSpecificUnit(id)
            };
            Program.JavascriptToRun = "";
            return View("EditUnitView", addNewUnitDto);
        }    
        public IActionResult UpdateUnit(UpdateUnitDto updateUnitDto)
        {
            if (updateUnitDto.male)
            {
                updateUnitDto.AddUnitDto.Gender = updateUnitDto.male;
            }
            else
            {
                updateUnitDto.AddUnitDto.Gender = false;
            }
            if (_unitIRepo.UpdateUnit(updateUnitDto.AddUnitDto, updateUnitDto.UnitId))
            {
                Program.JavascriptToRun = "toastr.success('تم نعديل الوحدة بنجاح')";
                return View("MainManegerView", _unitIRepo.GetAllUnitInfo());
            }
            else
            {
                UpdateUnitDto addNewUnitDto = new UpdateUnitDto
                {
                    StoreKeepers = _userIRepo.GetFreeStoreKeeper(),
                    SuperVisors = _userIRepo.GetFreeSuperVisor(),
                    studyBranchs = _studyBranchIRepo.GetAllStudyBranch(),
                    unitStores = _unitStoreIRepo.GetFreeStore(),
                    UnitDto = _unitIRepo.GetSpecificUnit(updateUnitDto.UnitId)
                };
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عمليةالتعديل')";
                return View("EditUnitView", addNewUnitDto);
            }

        }
        
        public IActionResult StartDeleteStudents()
        {
            Program.IsDeleteBegin = true;
            var x = _unitIRepo.GetAllUnitInfo();
            Program.JavascriptToRun = "toastr.success('تم البدء بعملية حذف الطلاب')";
            return View("MainManegerView", x);
        }
        public IActionResult EndDeleteStudents()
        {
            Program.IsDeleteBegin = false;
            var x = _unitIRepo.GetAllUnitInfo();
            Program.JavascriptToRun = "toastr.success('تم أنهاء عملية حذف الطلاب')";
            return View("MainManegerView", x);
        }
        public IActionResult ShowFullInformation()
        {
            GetFullInformationAboutStudentsDto dto = new GetFullInformationAboutStudentsDto()
            {
                getAllUnitDtos=_unitIRepo.GetAllUnit(),
                GetFullInformation=new List<GetFullInformationDto>()
                ,unitName=""
            };
            return View("FullInformationView",dto);
        } 
        public IActionResult FilterBySelectedUnit(GetFullInformationAboutStudentsDto dto)
        {
            if (dto.SelectedUnitId!=-1)
            {
                GetFullInformationAboutStudentsDto result = new GetFullInformationAboutStudentsDto()
                {
                    getAllUnitDtos = _unitIRepo.GetAllUnit(),
                    GetFullInformation = _StudentIRepo.GetFullInformation(dto.SelectedUnitId),
                    unitName = _unitIRepo.GetSpecificUnit(dto.SelectedUnitId).UnitName
                };
                return View("FullInformationView", result);
            }
            else
            {
                GetFullInformationAboutStudentsDto result = new GetFullInformationAboutStudentsDto()
                {
                    getAllUnitDtos = _unitIRepo.GetAllUnit(),
                    GetFullInformation = _StudentIRepo.GetFullInformation(dto.SelectedUnitId),
                };
                return View("FullInformationView", result);
            }
         
        }  
        public IActionResult FilterByDate(GetFullInformationAboutStudentsDto dto)
        {
            GetFullInformationAboutStudentsDto result = new GetFullInformationAboutStudentsDto()
            {
                getAllUnitDtos = _unitIRepo.GetAllUnit(),
                GetFullInformation = _StudentIRepo.GetFullInformation(dto.SelectedUnitId).FindAll(x=>x.RecordedDate>=dto.minDate && x.RecordedDate<=dto.maxDate),
                unitName = _unitIRepo.GetSpecificUnit(dto.SelectedUnitId).UnitName

            };
            return View("FullInformationView", result);
        } 
        public IActionResult EmployeeInfo()
        {
            UpdateEmployeeDto dto = new UpdateEmployeeDto() 
            {
                getEmployeeInfoDtos=_userIRepo.GetEmployeeInfo(),
               
            };
            return View("EmployeeSettingView", dto);
        }
        public IActionResult UpdateEmployee(UpdateEmployeeDto dto)
        {
            if (_userIRepo.UpdateUser(dto.UserDto, dto.UserId))
            {
                UpdateEmployeeDto result = new UpdateEmployeeDto()
                {
                    getEmployeeInfoDtos = _userIRepo.GetEmployeeInfo(),
                };
                Program.JavascriptToRun = "toastr.success('تم التعديل بنجاح')";
                return View("EmployeeSettingView", result);
            }
            else
            {
                UpdateEmployeeDto result = new UpdateEmployeeDto()
                {
                    getEmployeeInfoDtos = _userIRepo.GetEmployeeInfo(),
                };
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية التعديل')";
                return View("EmployeeSettingView", result);
            }
        } 
      
        public IActionResult x()
        {
            return View("xView");
        }
    }
}
