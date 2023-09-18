using OurProject.Dto.UnitDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDto
{
   public class GetFullInformationAboutStudentsDto
    {
        public List<GetFullInformationDto> GetFullInformation { get; set; }
        public List<GetAllUnitDto> getAllUnitDtos { get; set; }
        public int SelectedUnitId { get; set; }
        public DateTime minDate { get; set; } = DateTime.Now;
        public DateTime maxDate { get; set; } = DateTime.Now;
        public string unitName { get; set; }
    }
}
