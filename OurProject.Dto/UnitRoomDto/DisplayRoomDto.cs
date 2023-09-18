using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UnitRoomDto
{
   public class DisplayRoomDto
    {
        public List<GetRoomsInUnitDto> getRoomsInUnitDtos { get; set; }
        public List<List<GetStudentInRoomDto>> getStudentInRoomDtos { get; set; }
        public DateTime minDate { get; set; } = DateTime.Now;
        public DateTime maxDate { get; set; } = DateTime.Now;
        public int SelectedStudentNumber { get; set; }
        public string unitName { get; set; }
    }
}
