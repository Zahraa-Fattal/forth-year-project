using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetRoomsInUnitSBR
    {
        public int StudentCount { get; set; }
        public int unitRoomsId { get; set; }
        public string roomName { get; set; }
    }
}
