using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetStudentInRoomSBR
    {
        public string studentName { get; set; }
        public int unitRoomsId { get; set; }
        public DateTime RecordedDate { get; set; }
        public int StudentCount { get; set; }
    }
}
