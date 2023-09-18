using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDto
{
   public class StudentDisplayDto
    {
        public List<GetAllUnRecordedStudentsDto> UnRecordedStudentsDto { get; set; }
        public List<GetAllRecorderStudentsDto> RecordedStudentsDto { get; set; }
        public string NationalId { get; set; }
        public int StudentId { get; set; }
    }
}
