using OurProject.Dto.StudentAccessoriesDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface StudentAccessoriesIRepo
    {
        public bool AddStudentAccessories(AddStudentAccessoriesDto dto);
        public List<GetAllStudentAccessoriesDto> GetAllStudentAccessories();
        public List<GetAllStudentAccessoriesDto> GetStudentAccessoriesByStudentId(int studentId);
        public bool UpdateStudentAccessories(AddStudentAccessoriesDto dto, int id);
        public bool DeleteStudentAccessories(int id);
        public List<GetItemsInStoreUnitDto> GetItemsInStoreUnit(int StoreUnitId,int StudentId);
        public List<GetItemsInStoreUnitDto> GetExtraItemsInStoreUnit(int StoreUnitId, int StudentId);
        public int? GetStudentAccessoriesIdIfExists(int StudentId, int StoreDetailId);
        public List<GetItemsByStudentIdDto> GetItemsByStudentId(int UnitStore, int StudentId);
        public List<GetStudentThatHasItemsDto> GetStudentThatHasItems(int UnitStore);
        public List<GetStudentThatHasItemsDto> GetStudentThatHasItemsByDate(int UnitStore,DateTime MinDate,DateTime MaxDate);

    }
}
