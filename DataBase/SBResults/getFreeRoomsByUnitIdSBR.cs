using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class getFreeRoomsByUnitIdSBR
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StudentCount { get; set; }
    }
}
