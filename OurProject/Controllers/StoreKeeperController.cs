using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OurProject.Dto.AccessoryDto;
using OurProject.Dto.StoreDetailDto;
using OurProject.Dto.StudentAccessoriesDto;
using OurProject.Dto.StudentDto;
using OurProject.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurProject.Controllers
{
    public class StoreKeeperController : Controller
    {
        private readonly ILogger<StoreKeeperController> _logger;
        private readonly AccessoryIRepo _accessoryIRepo;
        private readonly StudentIRepo _studentIRepo;
        private readonly UnitIRepo _unitIRepo;
        private readonly StudentAccessoriesIRepo _studentAccessoriesIRepo;
        private readonly StoreDetailIRepo _storeDetailIRepo;

        public StoreKeeperController
         (
         ILogger<StoreKeeperController> logger, AccessoryIRepo accessoryIRepo, UnitIRepo unitIRepo
            , StudentIRepo studentIRepo, StudentAccessoriesIRepo studentAccessoriesIRepo, StoreDetailIRepo storeDetailIRepo
         )
        {
            _logger = logger;
            _accessoryIRepo = accessoryIRepo;
            _unitIRepo = unitIRepo;
            _studentIRepo = studentIRepo;
            _studentAccessoriesIRepo = studentAccessoriesIRepo;
            _storeDetailIRepo = storeDetailIRepo;
        }
        public IActionResult DisplayItems()
        {
            ItemInformationDto itemInformationDto = new ItemInformationDto() {
            getAccessoriesDetailsDtos = _accessoryIRepo.GetAccessoriesDetails(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id))
            };
            Program.JavascriptToRun = "";
            return View("ItemInformationView",itemInformationDto);
        }   
        public IActionResult DisplayItemsSuccess()
        {
            ItemInformationDto itemInformationDto = new ItemInformationDto() {
            getAccessoriesDetailsDtos = _accessoryIRepo.GetAccessoriesDetails(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id))
            };
            Program.JavascriptToRun = "toastr.success('تم الإضافة بنجاح')";
            return View("ItemInformationView",itemInformationDto);
        }   
        public IActionResult DisplayItemsError()
        {
            ItemInformationDto itemInformationDto = new ItemInformationDto() {
            getAccessoriesDetailsDtos = _accessoryIRepo.GetAccessoriesDetails(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id))
            };
            Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية الادخال الرجاء المحاولة لاحقا')";
            return View("ItemInformationView",itemInformationDto);
        } 
        public IActionResult HomeBtn()
        {
            StudentDisplayDto dto = new StudentDisplayDto()
            { 
                RecordedStudentsDto = _studentIRepo.GetAllRecorderStudents(_unitIRepo.GetUnitIdByStoreKeeperId(Program.CurrentUser.id))
            };
            Program.JavascriptToRun = "";
            return View("StudentDisplayView", dto);
        }
        public IActionResult HomeSuccessBtn()
        {
            StudentDisplayDto dto = new StudentDisplayDto()
            {
                RecordedStudentsDto = _studentIRepo.GetAllRecorderStudents(_unitIRepo.GetUnitIdByStoreKeeperId(Program.CurrentUser.id))
            };
            Program.JavascriptToRun = "toastr.success('تم الإضافة بنجاح')";
            return View("StudentDisplayView", dto);
        }
        public IActionResult HomeErrorBtn()
        {
            StudentDisplayDto dto = new StudentDisplayDto()
            {
                RecordedStudentsDto = _studentIRepo.GetAllRecorderStudents(_unitIRepo.GetUnitIdByStoreKeeperId(Program.CurrentUser.id))
            };
            Program.JavascriptToRun = "toastr.error('حدث خطأ في عملية الادخال الرجاء المحاولة لاحقا')";
            return View("StudentDisplayView", dto);
        }
        public IActionResult SearchStudents(StudentDisplayDto studentDisplayDto)
        {
            if (string.IsNullOrEmpty(studentDisplayDto.NationalId))
            {
                studentDisplayDto.RecordedStudentsDto = _studentIRepo.GetAllRecorderStudents(_unitIRepo.GetUnitIdByStoreKeeperId(Program.CurrentUser.id));
                return View("StudentDisplayView", studentDisplayDto);
            }
            else
            {
               var result = _studentIRepo.GetAllRecorderStudents(_unitIRepo.GetUnitIdByStoreKeeperId(Program.CurrentUser.id)).FindAll(x=>x.NationalId==studentDisplayDto.NationalId);
                studentDisplayDto.RecordedStudentsDto = result;
                return View("StudentDisplayView", studentDisplayDto);
            }
        }
        public IActionResult AddStudent(int id)
        {
            AddItemsToStudentDto addItemsToStudentDto = new AddItemsToStudentDto()
            {
                StudentId = id,
                StudentName = _studentIRepo.GetStudentById(id).Name,
                getItemsInStoreUnitDtos=_studentAccessoriesIRepo.GetItemsInStoreUnit(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id),id),
                getExtraItemsInStoreUnitDtos= _studentAccessoriesIRepo.GetExtraItemsInStoreUnit(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id), id)


            };
            Program.JavascriptToRun = "";
            return View("AddItemsToStudentView",addItemsToStudentDto);
        }
        public IActionResult AddItemToStudentBtn(AddItemsToStudentDto addItemsToStudentDto)
        {
            AddStudentDto addStudentDto = new AddStudentDto() {
                AccessoriesDate=DateTime.Now,
                Recorded=true,
                CityId=0,
                Image=null,
                Name=null,
                NationalId=null,
                StudyBranchId=0,
                UnitRoomFk=0,
                UniversityId=null,
                PhoneNumber=null,
                SuggestedUnitId=0,
                RecordedDate=DateTime.MinValue
            };
            AddStoreDetailDto addStoreDetailDto = new AddStoreDetailDto();
            List<AddStudentAccessoriesDto> Extraresult=new List<AddStudentAccessoriesDto>();
            var result = addItemsToStudentDto.addStudentAccessoriesDtos.FindAll(x=>x.Amount!=-1);
            if (addItemsToStudentDto.addExtraStudentAccessoriesDtos!=null)
            {
                 Extraresult = addItemsToStudentDto.addExtraStudentAccessoriesDtos.FindAll(x => x.Amount != -1);

            }
            for (int i = 0; i < result.Count; i++)
            {
                addStudentDto.Gender = _studentIRepo.GetOneStudentByStudentId(result[i].StudentId).Gender;
                _studentIRepo.UpdateStudent(addStudentDto, result[i].StudentId);
                int? StudentAccessoriesId = _studentAccessoriesIRepo.GetStudentAccessoriesIdIfExists(result[i].StudentId, result[i].StoreDetailId);
                if (StudentAccessoriesId==null)
                {
                    return RedirectToAction("HomeErrorBtn", "StoreKeeper");
                }
                else if (StudentAccessoriesId == -1)
                {
                    if (!_studentAccessoriesIRepo.AddStudentAccessories(result[i]))
                    {
                        return RedirectToAction("HomeErrorBtn", "StoreKeeper");
                    }
                  
                }
               else 
                {
                    if (!_studentAccessoriesIRepo.UpdateStudentAccessories(result[i], StudentAccessoriesId.Value))
                    {
                        return RedirectToAction("HomeErrorBtn", "StoreKeeper");
                    }
                }
                

                addStoreDetailDto.Amount = result[i].Amount;
                    _storeDetailIRepo.UpdateStoreDetail(addStoreDetailDto, result[i].StoreDetailId);
                
            }

            for (int i = 0; i < Extraresult.Count; i++)
            {
                addStudentDto.Gender = _studentIRepo.GetOneStudentByStudentId(Extraresult[i].StudentId).Gender;
                _studentIRepo.UpdateStudent(addStudentDto, Extraresult[i].StudentId);
                int? StudentAccessoriesId = _studentAccessoriesIRepo.GetStudentAccessoriesIdIfExists(Extraresult[i].StudentId, Extraresult[i].StoreDetailId);
                if (StudentAccessoriesId == null)
                {
                    return RedirectToAction("HomeErrorBtn", "StoreKeeper");
                }
                else if (StudentAccessoriesId == -1)
                {
                    if (!_studentAccessoriesIRepo.AddStudentAccessories(Extraresult[i]))
                    {
                        return RedirectToAction("HomeErrorBtn", "StoreKeeper");
                    }

                }
                else
                {
                    if (!_studentAccessoriesIRepo.UpdateStudentAccessories(Extraresult[i], StudentAccessoriesId.Value))
                    {
                        return RedirectToAction("HomeErrorBtn", "StoreKeeper");
                    }
                }


                addStoreDetailDto.Amount = Extraresult[i].Amount;
                _storeDetailIRepo.UpdateStoreDetail(addStoreDetailDto, Extraresult[i].StoreDetailId);

            }

            return RedirectToAction("HomeSuccessBtn", "StoreKeeper");
        }
        public IActionResult ShowItemsAndStudent()
        {
            ShowStudentThatHasItems showStudentThatHasItems = new ShowStudentThatHasItems()
            {
                getStudentThatHasItemsDtos = _studentAccessoriesIRepo.GetStudentThatHasItems(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id)),
                getItemsByStudentIdDtos = new List<List<GetItemsByStudentIdDto>>(),
                getAccessoriesDetailsDtos = _accessoryIRepo.GetAccessoriesDetails(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id)),
                UnitName=_unitIRepo.GetUnitNameByStoreKeeperId(Program.CurrentUser.id)

        };
            for (int i = 0; i < showStudentThatHasItems.getStudentThatHasItemsDtos.Count; i++)
            {
                var x = _studentAccessoriesIRepo.GetItemsByStudentId(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id), showStudentThatHasItems.getStudentThatHasItemsDtos[i].StudentId);
                showStudentThatHasItems.getItemsByStudentIdDtos.Add(x);
            }
            return View("ShowItemsAndStudentsView",showStudentThatHasItems);
        }
        public IActionResult ShowItemsAndStudentByDate(ShowStudentThatHasItems dto)
        {
            ShowStudentThatHasItems showStudentThatHasItems = new ShowStudentThatHasItems()
            {
                getStudentThatHasItemsDtos = _studentAccessoriesIRepo.GetStudentThatHasItemsByDate(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id),dto.minDate,dto.maxDate),
                getItemsByStudentIdDtos = new List<List<GetItemsByStudentIdDto>>(),
                getAccessoriesDetailsDtos = _accessoryIRepo.GetAccessoriesDetails(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id)),
            };
            for (int i = 0; i < showStudentThatHasItems.getStudentThatHasItemsDtos.Count; i++)
            {
                var x = _studentAccessoriesIRepo.GetItemsByStudentId(_unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id), showStudentThatHasItems.getStudentThatHasItemsDtos[i].StudentId);
                showStudentThatHasItems.getItemsByStudentIdDtos.Add(x);
            }
            return View("ShowItemsAndStudentsView", showStudentThatHasItems);
        }
        public IActionResult AddNewItem(ItemInformationDto dto)
        {
        
            int ItemId=_accessoryIRepo.AddAccessoryWithIdReturn(dto.AddAccessoryDto);
            if (ItemId!=-1)
            {
                AddStoreDetailDto addStoreDetailDto = new AddStoreDetailDto()
                { 
                  AccessoryId=ItemId,
                  Amount=dto.Amount,
                  UnitStoreId= _unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id)
                };
                if (_storeDetailIRepo.AddStoreDetail(addStoreDetailDto))
                {
                    return RedirectToAction("DisplayItemsSuccess", "StoreKeeper");
                }
                else
                {
                    _accessoryIRepo.DeleteAccessory(ItemId);
                    return RedirectToAction("DisplayItemsError", "StoreKeeper");
                }
                
            }
            return RedirectToAction("DisplayItemsError", "StoreKeeper");
        } 
        public IActionResult UpdateItem(ItemInformationDto dto)
        {
            if (_accessoryIRepo.UpdateAccessory(dto.AddAccessoryDto, dto.AccessoriesId))
            {
                AddStoreDetailDto addStoreDetailDto = new AddStoreDetailDto()
                {
                    AccessoryId = dto.AccessoriesId,
                    Amount = dto.Amount,
                    UnitStoreId = _unitIRepo.GetUnitStoreIdByStoreKeeperId(Program.CurrentUser.id)
                };
                if (_storeDetailIRepo.UpdateStoreDetailNormal(addStoreDetailDto, dto.StoreDetailsId))
                {
                    return RedirectToAction("DisplayItemsSuccess", "StoreKeeper");
                }
                else 
                {
                    return RedirectToAction("DisplayItemsError", "StoreKeeper");
                }
            }
            return RedirectToAction("DisplayItemsError", "StoreKeeper");
        }
        
        public IActionResult DeleteStudents()
        {

            List<GetAllRecorderStudentsDto> RecordedStudentsDto = _studentIRepo.GetAllRecorderStudents(_unitIRepo.GetUnitIdByStoreKeeperId(Program.CurrentUser.id));
    
            for (int i = 0; i < RecordedStudentsDto.Count; i++)
            {
              var studentAccessories=  _studentAccessoriesIRepo.GetStudentAccessoriesByStudentId(RecordedStudentsDto[i].studentId);
                for (int j = 0; j < studentAccessories.Count; j++)
                {
                    AddStoreDetailDto addStoreDetailDto = new AddStoreDetailDto()
                    {
                        AccessoryId = 0,
                        UnitStoreId = 0,
                        Amount = studentAccessories[j].Amount
                    };
                    _storeDetailIRepo.UpdateStoreDetailForExitStudent(addStoreDetailDto, studentAccessories[j].StoreDetailId);
                    _studentAccessoriesIRepo.DeleteStudentAccessories( studentAccessories[j].id);
                  
                }
            }
            StudentDisplayDto dto = new StudentDisplayDto()
            {
                RecordedStudentsDto = RecordedStudentsDto
            };
            Program.JavascriptToRun = "toastr.success('تم عملية حذف الادوات بنجاح')";
            return View("StudentDisplayView", dto);
        }  
        public IActionResult Index()
        {
            return View();
        }

    }
}
