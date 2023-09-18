using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDto
{
   public class GetStudentCountInUniteDto
    {
        public int UnitId { get; set; }
        public int StudentCount { get; set; }
        public string UnitName { get; set; }
    }
}
