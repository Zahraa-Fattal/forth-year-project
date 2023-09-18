using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDto
{
   public class GetAllUnRecordedStudentsDto
    {
        public int studentId { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string UniversityId { get; set; }
        public string Image { get; set; }
        public DateTime date { get; set; }
    }
}
