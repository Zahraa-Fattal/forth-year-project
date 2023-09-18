using OurProject.Dto.StudyBranchDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDto
{
   public class AddAppointmentDto
    {
        public AddStudentDto studentDto { get; set; }
        public List<GetAllStudyBranchDto> studyBranchs { get; set; }
        public List<GetCountryDto> countries { get; set; }
        public List<GetMainCityDto> GetMainCities { get; set; }
        public int MainCity { get; set; }
        public int Country { get; set; }
    }
}
