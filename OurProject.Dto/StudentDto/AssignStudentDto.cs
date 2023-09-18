using OurProject.Dto.StudyBranchDto;
using OurProject.Dto.UnitRoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDto
{
   public class AssignStudentDto
    {
        public AddStudentDto addStudentDto { get; set; }
        public GetSpecificStudentDto SpecificStudentDto { get; set; }
        public List<GetAllStudyBranchDto> getAllStudyBranchDtos { get; set; }
        public List<GetMainCityDto> getMainCityDtos { get; set; }
        public List<GetCountryDto> getCountryDtos{ get; set; }
        public List<getFreeRoomsByUnitIdDto> FreeRoomDtos { get; set; }
        public int mainCity { get; set; }
        public int Contry { get; set; }
        public int StudentId { get; set; }
        public int OldRoomId { get; set; }
        public string Email { get; set; }
        public int  SuggestedUnitId { get; set; }
    }
}
