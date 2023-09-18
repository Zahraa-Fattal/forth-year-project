using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentAccessoriesDto
{
   public class AddItemsToStudentDto
    {
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public List<AddStudentAccessoriesDto> addStudentAccessoriesDtos { get; set; }
        public List<AddStudentAccessoriesDto> addExtraStudentAccessoriesDtos { get; set; }
        public List<GetItemsInStoreUnitDto> getItemsInStoreUnitDtos { get; set; }
        public List<GetItemsInStoreUnitDto> getExtraItemsInStoreUnitDtos { get; set; }
    }
}
