using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OurProject.Dto.StudentDto;
using OurProject.Dto.UserDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject.Controllers
{
    public class SignInController : Controller
    {
        private readonly ILogger<SignInController> _logger;
        private readonly UserIRepo _userIRepo;
        private readonly StudentIRepo _studentIRepo;
        private readonly UnitIRepo _unitIRepo;
        private readonly StudyBranchIRepo _studyBranchIRepo;

        public SignInController
            (
            ILogger<SignInController> logger, UserIRepo userRepo
            , UnitIRepo unitIRepo, StudentIRepo studentIRepo, StudyBranchIRepo studyBranchIRepo
            )
        {
            _logger = logger;
            _userIRepo = userRepo;
            _unitIRepo = unitIRepo;
            _studentIRepo = studentIRepo;
            _studyBranchIRepo = studyBranchIRepo;
        }
        public IActionResult SignInBtn(UserLogInDto logInDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("SignInView");
            //}
            var user = _userIRepo.GetUser(logInDto);
            if (user != null)
            {
                Program.CurrentUser = user;
                if (user.RoleId == 1)
                {
                    Program.JavascriptToRun = "";
                    return View("~/Views/Maneger/MainManegerView.cshtml", _unitIRepo.GetAllUnitInfo());
                }
                if (user.RoleId == 2)
                {
                   int unitId= _unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id);
                    if (unitId==-1)
                    {
                        Program.JavascriptToRun = "toastr.error('عذرا هذا المستخدم ليس تابع لوحدة معينة')";
                        return View("SignInView");
                    }
                    else
                    {
                        StudentDisplayDto dto = new StudentDisplayDto();
                        Program.Studentlist = _studentIRepo.GetAllStudentsInfo(unitId);
                        dto.UnRecordedStudentsDto = Program.Studentlist;
                        Program.JavascriptToRun = "";
                        return View("~/Views/SuperVisor/StudentDisplayView.cshtml",dto);
                    }
                }
                if (user.RoleId == 3)
                {
                    int unitId = _unitIRepo.GetUnitIdByStoreKeeperId(Program.CurrentUser.id);
                    if (unitId == -1)
                    {
                        Program.JavascriptToRun = "toastr.error('عذرا هذا المستخدم ليس تابع لوحدة معينة')";
                        return View("SignInView");
                    }
                    else
                    {
                        StudentDisplayDto dto = new StudentDisplayDto();
                        Program.RecordedStudentlist = _studentIRepo.GetAllRecorderStudents(unitId);
                        dto.RecordedStudentsDto = Program.RecordedStudentlist;
                        Program.JavascriptToRun = "";
                        return View("~/Views/StoreKeeper/StudentDisplayView.cshtml", dto);
                    }
                }
                else 
                {
                    return Unauthorized();
                }
            }
            else 
            {
                Program.JavascriptToRun = "toastr.error('تأكد من البريد الألكتروني وكلمة السر')";
                return View("SignInView");
            }
          
               
            
        }

        public IActionResult StudentSignInBtn()
        {
            try
            {
                AddAppointmentDto addAppointmentDto = new AddAppointmentDto()
                {
                    studyBranchs = _studyBranchIRepo.GetAllStudyBranch(),
                    GetMainCities = _studentIRepo.GetMainCity(),
                    countries = _studentIRepo.GetCountry(1),
                };
                return View("~/Views/Student/AppointmentBookView.cshtml", addAppointmentDto);
            }
            catch (Exception e)
            {

                throw;
            }
        } 
        [HttpGet]
        public JsonResult  GetCountry(int id)
        {
           var result= _studentIRepo.GetCountry(id);
            var x = new JsonResult(result);
            return x;
        }
    }
}
