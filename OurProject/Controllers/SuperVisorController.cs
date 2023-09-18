using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OurProject.Dto.StudentDto;
using OurProject.Dto.UnitRoomDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OurProject.Controllers
{
    public class SuperVisorController : Controller
    {
        private readonly ILogger<SuperVisorController> _logger;
        private readonly UnitRoomIRepo _unitRoomIRepo;
        private readonly UnitIRepo _unitIRepo;
        private readonly StudyBranchIRepo _studyBranchIRepo;
        private readonly StudentIRepo _studentIRepo;
        private readonly StudentAccessoriesIRepo _studentAccessoriesIRepo;

        public SuperVisorController
          (
          ILogger<SuperVisorController> logger, UnitRoomIRepo unitRoomIRepo, UnitIRepo unitIRepo
            , StudyBranchIRepo studyBranchIRepo, StudentIRepo studentIRepo, StudentAccessoriesIRepo studentAccessoriesIRepo
          )
        {
            _logger = logger;
            _unitRoomIRepo = unitRoomIRepo;
            _unitIRepo = unitIRepo;
            _studyBranchIRepo = studyBranchIRepo;
            _studentIRepo = studentIRepo;
            _studentAccessoriesIRepo = studentAccessoriesIRepo;
        }
        public IActionResult FilterStudents(StudentDisplayDto studentDisplayDto)
        {
            if (string.IsNullOrEmpty(studentDisplayDto.NationalId))
            {
                studentDisplayDto.UnRecordedStudentsDto = _studentIRepo.GetAllStudentsInfo(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id));
                return View("StudentDisplayView", studentDisplayDto);
            }
            else
            {
                studentDisplayDto.UnRecordedStudentsDto = _studentIRepo.GetAllStudentsInfo(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id)).FindAll(x => x.NationalId == studentDisplayDto.NationalId);
                return View("StudentDisplayView", studentDisplayDto);
            }
        }
        public IActionResult HomeBtn()
        {
            StudentDisplayDto studentDisplayDto = new StudentDisplayDto();
            studentDisplayDto.UnRecordedStudentsDto = _studentIRepo.GetAllStudentsInfo(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id));
            return View("StudentDisplayView", studentDisplayDto);
        }
        public IActionResult AddStudent(int id)
        {
            bool ok = false;
            AssignStudentDto assignStudentDto = new AssignStudentDto()
            {
                FreeRoomDtos = _unitRoomIRepo.GetAllFreeUnitRoom(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id)),
                getAllStudyBranchDtos = _studyBranchIRepo.GetAllStudyBranch(),
                getCountryDtos=_studentIRepo.GetCountry(1),
                getMainCityDtos=_studentIRepo.GetMainCity(),
                SpecificStudentDto=_studentIRepo.GetSpecificStudent(id),
            };
            if (assignStudentDto.SpecificStudentDto.unitRoomId.HasValue)
            {
                for (int i = 0; i < assignStudentDto.FreeRoomDtos.Count; i++)
                {
                    if (assignStudentDto.FreeRoomDtos[i].Id == assignStudentDto.SpecificStudentDto.unitRoomId.Value)
                    {
                        ok = true;
                    }
                }
                if (!ok)
                {
                    getFreeRoomsByUnitIdDto getFreeRoomsByUnitIdDto = new getFreeRoomsByUnitIdDto()
                    {
                        Id = assignStudentDto.SpecificStudentDto.unitRoomId.Value,
                        Name = assignStudentDto.SpecificStudentDto.RoomName
                    };
                    assignStudentDto.FreeRoomDtos.Add(getFreeRoomsByUnitIdDto);
                    assignStudentDto.FreeRoomDtos.OrderBy(x => x.Name);
                }
            }
     
           
            return View("AddStudentView",assignStudentDto);
        }
        public IActionResult AddStudentBtn(AssignStudentDto assignStudentDto)
        {
            if (assignStudentDto.Contry!=-1)
            {
                assignStudentDto.addStudentDto.CityId = assignStudentDto.Contry;
            }
            else
            {
                assignStudentDto.addStudentDto.CityId = assignStudentDto.mainCity;
            }
            
            var SuggestedUnit = _studentIRepo.GetStudentCount(assignStudentDto.addStudentDto.StudyBranchId, assignStudentDto.addStudentDto.Gender);
            if (SuggestedUnit!=null)
            {
                
                assignStudentDto.addStudentDto.SuggestedUnitId = SuggestedUnit.UnitId;
            }
            assignStudentDto.addStudentDto.Recorded = true;
            assignStudentDto.addStudentDto.RecordedDate = DateTime.Now;
            if (_studentIRepo.UpdateStudent(assignStudentDto.addStudentDto,assignStudentDto.StudentId))
            {
                if (_unitRoomIRepo.GetUnitRoomById(assignStudentDto.addStudentDto.UnitRoomFk.Value)!=null)
                {
                    var result = _unitRoomIRepo.GetUnitRoomById(assignStudentDto.addStudentDto.UnitRoomFk.Value);
                    var oldRoom = _unitRoomIRepo.GetUnitRoomById(assignStudentDto.OldRoomId);


                    if (assignStudentDto.OldRoomId != assignStudentDto.addStudentDto.UnitRoomFk.Value)
                    {
                        result.StudentCount++;
                        if (oldRoom!=null)
                        {
                            oldRoom.StudentCount--;

                        }
                    }
                    if (_unitRoomIRepo.UpdateUnitRoom(result, assignStudentDto.addStudentDto.UnitRoomFk.Value)
                        && _unitRoomIRepo.UpdateUnitRoom(oldRoom, assignStudentDto.OldRoomId))
                    {
                        using (StreamReader streamReader = new StreamReader(@"C:\Users\Wael\Desktop\OurProject\OurProject\wwwroot\AddStudentGoogleTemplet.txt"))
                        {
                            string bodyGoogle = streamReader.ReadToEnd();
                            bodyGoogle = bodyGoogle.Replace("name", assignStudentDto.addStudentDto.Name);
                            bodyGoogle = bodyGoogle.Replace("x", SuggestedUnit.UnitName);

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
                            mailMessage.To.Add(assignStudentDto.Email);

                            smtpClient.Send(mailMessage);
                        };
                    }
                }
            
               
                
                StudentDisplayDto studentDisplayDto = new StudentDisplayDto();
                studentDisplayDto.UnRecordedStudentsDto = _studentIRepo.GetAllStudentsInfo(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id));
                Program.JavascriptToRun = "toastr.success('تم التعديل بنجاح')";
                return View("StudentDisplayView", studentDisplayDto);
            }
            else
            {
                StudentDisplayDto studentDisplayDto = new StudentDisplayDto();
                studentDisplayDto.UnRecordedStudentsDto = _studentIRepo.GetAllStudentsInfo(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id));
                Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية التعديل')";
                return View("StudentDisplayView", studentDisplayDto);
            }
        } 
        public IActionResult DisplayRoom()
        {
            DisplayRoomDto displayRoomDto = new DisplayRoomDto() 
            {
                getRoomsInUnitDtos=_unitRoomIRepo.GetRoomsInUnit(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id)),
                getStudentInRoomDtos = new List<List<GetStudentInRoomDto>>(),
                unitName=_unitIRepo.GetSpecificUnit(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id)).UnitName
            };
            for (int i = 0; i < displayRoomDto.getRoomsInUnitDtos.Count; i++)
            {
                List<GetStudentInRoomDto> x = _unitRoomIRepo.GetStudentInRoom(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id), displayRoomDto.getRoomsInUnitDtos[i].unitRoomsId) ;
                displayRoomDto.getStudentInRoomDtos.Add(x);
            }
            Program.RoomListDto.getRoomsInUnitDtos = displayRoomDto.getRoomsInUnitDtos;
            Program.RoomListDto.getStudentInRoomDtos = displayRoomDto.getStudentInRoomDtos;

            return View("RoomView", displayRoomDto);
        } 
        public IActionResult StudentsFilter(DisplayRoomDto dto)
        {
            DisplayRoomDto displayRoomDto = new DisplayRoomDto()
            {
                getRoomsInUnitDtos = _unitRoomIRepo.GetRoomsInUnitByDate(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id),dto.minDate,dto.maxDate),
                getStudentInRoomDtos = new List<List<GetStudentInRoomDto>>()
            };
            for (int i = 0; i < displayRoomDto.getRoomsInUnitDtos.Count; i++)
            {
                List<GetStudentInRoomDto> x = _unitRoomIRepo.GetStudentInRoomByDate(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id), displayRoomDto.getRoomsInUnitDtos[i].unitRoomsId,dto.minDate,dto.maxDate);
                displayRoomDto.getStudentInRoomDtos.Add(x);
            }
            Program.RoomListDto.getRoomsInUnitDtos = displayRoomDto.getRoomsInUnitDtos;
            Program.RoomListDto.getStudentInRoomDtos = displayRoomDto.getStudentInRoomDtos;
            if (Program.IsFilterd)
            {
                DisplayRoomDto FilterDto = new DisplayRoomDto()
                {
                    getRoomsInUnitDtos = new List<GetRoomsInUnitDto>(),

                    getStudentInRoomDtos = new List<List<GetStudentInRoomDto>>()
                };
                if (dto.SelectedStudentNumber == 1)
                {
                    FilterDto.getRoomsInUnitDtos = displayRoomDto.getRoomsInUnitDtos.FindAll(c => c.StudentCount == 1);
                    for (int i = 0; i < FilterDto.getRoomsInUnitDtos.Count; i++)
                    {
                        List<GetStudentInRoomDto> x = _unitRoomIRepo.GetStudentInRoomByDate(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id), displayRoomDto.getRoomsInUnitDtos[i].unitRoomsId, dto.minDate, dto.maxDate);
                        FilterDto.getStudentInRoomDtos.Add(x);
                    }
                    return View("RoomView", FilterDto);
                }
                else if (dto.SelectedStudentNumber == 2)
                {
                    FilterDto.getRoomsInUnitDtos = displayRoomDto.getRoomsInUnitDtos.FindAll(c => c.StudentCount == 2);
                    for (int i = 0; i < FilterDto.getRoomsInUnitDtos.Count; i++)
                    {
                        List<GetStudentInRoomDto> x = _unitRoomIRepo.GetStudentInRoomByDate(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id), displayRoomDto.getRoomsInUnitDtos[i].unitRoomsId, dto.minDate, dto.maxDate);
                        FilterDto.getStudentInRoomDtos.Add(x);
                    }
                    return View("RoomView", FilterDto);
                }
             
                else
                {
                    FilterDto.getRoomsInUnitDtos = displayRoomDto.getRoomsInUnitDtos.FindAll(c => c.StudentCount == 3);
                    for (int i = 0; i < FilterDto.getRoomsInUnitDtos.Count; i++)
                    {
                        List<GetStudentInRoomDto> x = _unitRoomIRepo.GetStudentInRoomByDate(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id), displayRoomDto.getRoomsInUnitDtos[i].unitRoomsId, dto.minDate, dto.maxDate);
                        FilterDto.getStudentInRoomDtos.Add(x);
                    }
                    return View("RoomView", FilterDto);
                }
            }
            return View("RoomView", displayRoomDto);
        } 
        public IActionResult FilterByStudentCount(DisplayRoomDto dto)
        {
            Program.IsFilterd = true;
            DisplayRoomDto displayRoomDto = new DisplayRoomDto()
            {
                getRoomsInUnitDtos = new List<GetRoomsInUnitDto>(),
                
                getStudentInRoomDtos = new List<List<GetStudentInRoomDto>>()
            };
         
            if (dto.SelectedStudentNumber==1)
            {
                displayRoomDto.getRoomsInUnitDtos= Program.RoomListDto.getRoomsInUnitDtos.FindAll(c => c.StudentCount == 1);
                for (int i = 0; i < Program.RoomListDto.getStudentInRoomDtos.Count; i++)
                {
                    if (Program.RoomListDto.getStudentInRoomDtos[i].FindAll(c => c.StudentCount == 1).Count!=0)
                    {
                        displayRoomDto.getStudentInRoomDtos.Add(Program.RoomListDto.getStudentInRoomDtos[i].FindAll(c => c.StudentCount == 1));
                    }
                }
                return View("RoomView", displayRoomDto);
            }
            else if (dto.SelectedStudentNumber == 2)
            {
                displayRoomDto.getRoomsInUnitDtos = Program.RoomListDto.getRoomsInUnitDtos.FindAll(c => c.StudentCount == 2);
                for (int i = 0; i < Program.RoomListDto.getStudentInRoomDtos.Count; i++)
                {
                    if (Program.RoomListDto.getStudentInRoomDtos[i].FindAll(c => c.StudentCount == 2).Count != 0)
                    {
                        displayRoomDto.getStudentInRoomDtos.Add(Program.RoomListDto.getStudentInRoomDtos[i].FindAll(c => c.StudentCount == 2));
                    }
                }
                return View("RoomView", displayRoomDto);
            }
            else if (dto.SelectedStudentNumber == -1)
            {
                Program.IsFilterd = false;
                return View("RoomView", Program.RoomListDto);
            }
            else
            {
                displayRoomDto.getRoomsInUnitDtos = Program.RoomListDto.getRoomsInUnitDtos.FindAll(c => c.StudentCount == 3);
                for (int i = 0; i < Program.RoomListDto.getStudentInRoomDtos.Count; i++)
                {
                    if (Program.RoomListDto.getStudentInRoomDtos[i].FindAll(c => c.StudentCount == 3).Count != 0)
                    {
                        displayRoomDto.getStudentInRoomDtos.Add(Program.RoomListDto.getStudentInRoomDtos[i].FindAll(c => c.StudentCount == 3));
                    }
                }
                return View("RoomView", displayRoomDto);
            }
        }
        
        public IActionResult DeleteStudents()
        {
            StudentDisplayDto studentDisplayDto = new StudentDisplayDto();
            studentDisplayDto.UnRecordedStudentsDto = _studentIRepo.GetAllStudentsInfo(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id));
            for (int i = 0; i < studentDisplayDto.UnRecordedStudentsDto.Count; i++)
            {
                var studentAccessories = _studentAccessoriesIRepo.GetStudentAccessoriesByStudentId(studentDisplayDto.UnRecordedStudentsDto[i].studentId);
                if (studentAccessories.Count!=0)
                {
       
                    Program.JavascriptToRun = "toastr.error('لا يمكن اتمام عملية الحذف بسبب وجود طالب او اكثر يمتلكون أدوات')";
                    return View("StudentDisplayView", studentDisplayDto);
                }
                AddStudentDto addStudentDto = new AddStudentDto()
                {
                    UnitRoomFk=null,
                    IsDeleted=true
                };
                var student = _studentIRepo.GetOneStudentByStudentId(studentDisplayDto.UnRecordedStudentsDto[i].studentId);
                if (student.UnitRoomFk != null)
                {
                    _unitRoomIRepo.UpdateUnitRoomForExitStudent(student.UnitRoomFk.Value);

                }
                _studentIRepo.UpdateStudent_IsDeleted(addStudentDto, studentDisplayDto.UnRecordedStudentsDto[i].studentId);
        

            }
            return RedirectToAction("successDelete", "SuperVisor");
        } 
        public IActionResult successDelete()
        {
            StudentDisplayDto studentDisplayDto = new StudentDisplayDto();
            studentDisplayDto.UnRecordedStudentsDto = _studentIRepo.GetAllStudentsInfo(_unitIRepo.GetUnitIdBySuperVisorId(Program.CurrentUser.id));
            Program.JavascriptToRun = "toastr.success('تمت عملية حذف الطلاب بنجاح')";
            return View("StudentDisplayView", studentDisplayDto);
        }
        public IActionResult Index()
        {
            return View("AddStudentView");
        }
    }
}
