using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OurProject.Dto.StudentDateDto;
using OurProject.Dto.StudentDto;
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
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly StudentIRepo _studentIRepo;
        private readonly VacationDateIRepo _vacationDateIRepo;
        private readonly StudentDateIRepo _studentDateIRepo;
        private readonly StudyBranchIRepo _studyBranchIRepo;

        public StudentController
           (
           ILogger<StudentController> logger, StudentIRepo studentIRepo, VacationDateIRepo vacationDateIRepo
            , StudentDateIRepo studentDateIRepo, StudyBranchIRepo studyBranchIRepo
           )
        {
            _logger = logger;
            _studentIRepo = studentIRepo;
            _vacationDateIRepo = vacationDateIRepo;
            _studentDateIRepo = studentDateIRepo;
            _studyBranchIRepo = studyBranchIRepo;
        }
        [HttpPost]
        public JsonResult BookDate([FromBody] AddStudentDto addStudentDto)
        {
            try
            {
                var vacation = _vacationDateIRepo.GetAllVacationDate();

                var SuggestedUnit = _studentIRepo.GetStudentCount(addStudentDto.StudyBranchId, addStudentDto.Gender);
                if (SuggestedUnit != null)
                {
                    addStudentDto.SuggestedUnitId = SuggestedUnit.UnitId;
                   
                    var lastdateDto = _studentIRepo.GetLastDate(addStudentDto.SuggestedUnitId);
                    DateTime date = DateTime.Now;
                    if (lastdateDto != null)
                    {
                        if (lastdateDto.MaxDate.Date < date.Date)
                        {
                            date = date.AddDays(1);
                            date = date.AddHours((-date.Hour) + 9);
                            date = date.AddMinutes((-date.Minute));
                            if (date.Hour == 3)
                            {
                                date = date.AddDays(1);
                                date = date.AddHours((-date.Hour) + 9);
                                date = date.AddMinutes((-date.Minute));
                                if (date.DayOfWeek == DayOfWeek.Friday)
                                {
                                    date = date.AddDays(2);
                                }
                                else if (date.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    date = date.AddDays(1);
                                }
                            }
                        }
                        else
                        {
                            lastdateDto.MaxDate = lastdateDto.MaxDate.AddMinutes(15);
                            if (lastdateDto.MaxDate.Hour == 3)
                            {
                                lastdateDto.MaxDate = lastdateDto.MaxDate.AddDays(1);
                                lastdateDto.MaxDate = lastdateDto.MaxDate.AddHours((-lastdateDto.MaxDate.Hour) + 9);
                                lastdateDto.MaxDate = lastdateDto.MaxDate.AddMinutes((-lastdateDto.MaxDate.Minute));
                                if (lastdateDto.MaxDate.DayOfWeek == DayOfWeek.Friday)
                                {
                                    lastdateDto.MaxDate = lastdateDto.MaxDate.AddDays(2);
                                }
                                else if (lastdateDto.MaxDate.DayOfWeek == DayOfWeek.Saturday)
                                {
                                    lastdateDto.MaxDate = lastdateDto.MaxDate.AddDays(1);
                                }
                            }
                            date = lastdateDto.MaxDate;
                        }

                    }
                    else
                    {
                        date = date.AddDays(1);
                        date = date.AddHours((-date.Hour) + 9);
                        date = date.AddMinutes((-date.Minute));
                        if (date.DayOfWeek == DayOfWeek.Friday)
                        {
                            date = date.AddDays(2);
                        }
                        else if (date.DayOfWeek == DayOfWeek.Saturday)
                        {
                            date = date.AddDays(1);
                        }
                    }
                    foreach (var item in vacation)
                    {
                        if (date.Date == item.date.Date)
                        {
                            date = date.AddDays(1);
                        }
                    }
                    if (date.DayOfWeek == DayOfWeek.Friday)
                    {
                        date = date.AddDays(2);
                    }
                    else if (date.DayOfWeek == DayOfWeek.Saturday)
                    {
                        date = date.AddDays(1);
                    }
                   var oldStudent= _studentIRepo.GetStudentByNationalId(addStudentDto.NationalId);
                    if (oldStudent!=null && oldStudent.IsDeleted==true)
                    {
                        _studentIRepo.UpdateOldStudent(addStudentDto, oldStudent.id);
                        AddStudentDateDto addStudentDateDto = new AddStudentDateDto
                        {
                            date = date,
                            DateTypeId = 1,
                            Price = 0,
                            StudentId = oldStudent.id
                        };

                        if (_studentDateIRepo.UpdateStudentDate(addStudentDateDto,_studentDateIRepo.GetStudentDateByUserId(oldStudent.id).id))
                        {
                            using (StreamReader streamReader = new StreamReader(@"C:\Users\Wael\Desktop\OurProject\OurProject\wwwroot\StudentGoogleTemplet.txt"))
                            {
                                string bodyGoogle = streamReader.ReadToEnd();
                                bodyGoogle = bodyGoogle.Replace("name", addStudentDto.Name);
                                bodyGoogle = bodyGoogle.Replace("unit", SuggestedUnit.UnitName);
                                bodyGoogle = bodyGoogle.Replace("date", date.ToString("dd/MM/yyyy hh:mm tt"));

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
                                mailMessage.To.Add(addStudentDto.Email);

                                smtpClient.Send(mailMessage);
                            };
                            ReturnFinalValueDto returnFinalValueDto = new ReturnFinalValueDto()
                            {
                                finalDate = date.ToString("dd/MM/yyyy hh:mm tt"),
                                unitName = SuggestedUnit.UnitName
                            };
                            return new JsonResult(returnFinalValueDto);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        int studentId = _studentIRepo.AddStudentWithIdReturn(addStudentDto);
                        AddStudentDateDto addStudentDateDto = new AddStudentDateDto
                        {
                            date = date,
                            DateTypeId = 1,
                            Price = 0,
                            StudentId = studentId
                        };

                        if (_studentDateIRepo.AddStudentDate(addStudentDateDto))
                        {
                            using (StreamReader streamReader = new StreamReader(@"C:\Users\Wael\Desktop\OurProject\OurProject\wwwroot\StudentGoogleTemplet.txt"))
                            {
                                string bodyGoogle = streamReader.ReadToEnd();
                                bodyGoogle = bodyGoogle.Replace("name", addStudentDto.Name);
                                bodyGoogle = bodyGoogle.Replace("unit", SuggestedUnit.UnitName);
                                bodyGoogle = bodyGoogle.Replace("date", date.ToString("dd/MM/yyyy hh:mm tt"));

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
                                mailMessage.To.Add(addStudentDto.Email);

                                smtpClient.Send(mailMessage);
                            };
                            ReturnFinalValueDto returnFinalValueDto = new ReturnFinalValueDto()
                            {
                                finalDate = date.ToString("dd/MM/yyyy hh:mm tt"),
                                unitName = SuggestedUnit.UnitName
                            };
                            return new JsonResult(returnFinalValueDto);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    

                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }

        }
        public IActionResult ShowPaperAndTerms()
        {
            return View("PaperAndTermsView");
            
        } 
     
        public IActionResult AppointmentHomeBtn()
        {
            try
            {
                AddAppointmentDto addAppointmentDto = new AddAppointmentDto()
                {
                    studyBranchs = _studyBranchIRepo.GetAllStudyBranch(),
                    GetMainCities = _studentIRepo.GetMainCity(),
                    countries = _studentIRepo.GetCountry(1),
                };
                return View("AppointmentBookView", addAppointmentDto);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        public IActionResult ShowDateInformation()
        {
            return View("DateInformationView");

        }
        public IActionResult x()
        {
            return View("PaperAndTermsView");
        }
    }
}
