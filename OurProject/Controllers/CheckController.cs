using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OurProject.Dto.StudentDto;
using OurProject.Dto.UnitRoomDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject.Controllers
{

    public class CheckController : Controller
    {
        public static IWebHostEnvironment _environment;
        private readonly UserIRepo _userIRepo;
        private readonly StudentIRepo _studentIRepo;
        private readonly StudentDateIRepo _studentDateIRepo;
        private readonly UnitIRepo _unitIRepo;
        private readonly UnitRoomIRepo _unitRoomIRepo;
        public CheckController(IWebHostEnvironment environment, UserIRepo userIRepo
            , StudentIRepo studentIRepo, StudentDateIRepo studentDateIRepo, UnitIRepo unitIRepo
            , UnitRoomIRepo unitRoomIRepo)
        {
            _environment = environment;
            _userIRepo = userIRepo;
            _studentIRepo = studentIRepo;
            _studentDateIRepo = studentDateIRepo;
            _unitIRepo = unitIRepo;
            _unitRoomIRepo = unitRoomIRepo;
        }
        [HttpGet]
        public bool CheckUserName(string username)
        {
            var x= _userIRepo.IsuserNameAvailable(username);
            return x;
        }
        [HttpGet]
        public JsonResult CheckStudentEmail(string Email,string NationalNumber)
        {
            CheckEmailAndNationalIdDto checkEmailAndNational = new CheckEmailAndNationalIdDto();
            var oldStudent = _studentIRepo.GetStudentByNationalId(NationalNumber);
            if (oldStudent!=null)
            {
                checkEmailAndNational.national = false;
                if (oldStudent.IsDeleted == true)
                {
                    checkEmailAndNational.national = true;
                }

            }
       
            else
            {
                checkEmailAndNational.national = true;
            }
            if (string.IsNullOrEmpty(Email))
            {
                checkEmailAndNational.email = false;
            }
            else
            {
                checkEmailAndNational.email = _studentIRepo.IsuserNameAvailable(Email);
            }
            
            return new JsonResult(checkEmailAndNational);
        }
        [HttpGet]
        public JsonResult GetDate(string NationalNumber)
        {
            var student = _studentIRepo.GetStudentByNationalId(NationalNumber);
            if (student==null)
            {
                return null;
            }
           var SuggestedUnit= _unitIRepo.GetOneUnit(student.SuggestedUnitId);
           var studentDate= _studentDateIRepo.GetStudentDateByUserId(student.id);
            ReturnFinalValueDto returnFinalValueDto = new ReturnFinalValueDto() 
            {
                finalDate= studentDate.date.ToString("dd/MM/yyyy hh:mm tt"),
                unitName= SuggestedUnit.Name,
                studentName=student.Name
            };
            return new JsonResult(returnFinalValueDto);
        }
        [HttpPost]
        public string GetUnitValidation([FromBody] GetUnitValidationDto getUnitValidationDto)
        {
            string SuggestedUnit;
            if (getUnitValidationDto.mail)
            {
                if (_studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, getUnitValidationDto.mail)==null)
                {
                    return null;
                }
                else
                {
                 SuggestedUnit = _studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, true).UnitName;
                }
            }
            else
            {
                if (_studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, false) == null)
                {
                    return null;
                }
                else
                {
                SuggestedUnit = _studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, false).UnitName;
                }

            }

       
            return SuggestedUnit;
        }
        [HttpPost]
        public JsonResult GetRoomValidation([FromBody] GetUnitValidationDto getUnitValidationDto)
        {
            GetStudentCountInUniteDto SuggestedUnit;
            if (getUnitValidationDto.mail)
            {
                if (_studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, getUnitValidationDto.mail) == null)
                {
                    return null;
                }
                else
                {
                    SuggestedUnit = _studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, true);
                }
            }
            else
            {
                if (_studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, false) == null)
                {
                    return null;
                }
                else
                {
                    SuggestedUnit = _studentIRepo.GetStudentCount(getUnitValidationDto.StudyBranch, false);
                }

            }
            var result =_unitRoomIRepo.GetAllFreeUnitRoom(SuggestedUnit.UnitId);
            GetFreeRoomValidation getFreeRoomValidation = new GetFreeRoomValidation() 
            {
                getFreeRoomsByUnitIdDtos=result,
                newSugestedUnitId=SuggestedUnit.UnitId
            };
            var x = new JsonResult(getFreeRoomValidation);


            return x;
        }
    }
}
