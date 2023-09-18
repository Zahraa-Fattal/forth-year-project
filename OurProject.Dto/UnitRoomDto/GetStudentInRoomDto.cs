using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UnitRoomDto
{
   public class GetStudentInRoomDto
    {
        public string studentName { get; set; }
        public int unitRoomsId { get; set; }
        public DateTime RecordedDate { get; set; }
        public int StudentCount { get; set; }
    }
}
