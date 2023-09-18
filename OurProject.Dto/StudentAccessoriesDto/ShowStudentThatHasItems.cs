using OurProject.Dto.AccessoryDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentAccessoriesDto
{
   public class ShowStudentThatHasItems
    {
        public List<List<GetItemsByStudentIdDto>> getItemsByStudentIdDtos { get; set; }
        public List<GetStudentThatHasItemsDto> getStudentThatHasItemsDtos { get; set; }
        public List<GetAccessoriesDetailsDto> getAccessoriesDetailsDtos { get; set; }
        public DateTime minDate { get; set; } = DateTime.Now;
        public DateTime maxDate { get; set; } = DateTime.Now;
        public string UnitName { get; set; }
    }
}
