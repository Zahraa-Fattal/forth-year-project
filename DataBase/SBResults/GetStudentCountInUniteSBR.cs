using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetStudentCountInUniteSBR
    {
        public int UnitId { get; set; }
        public int StudentCount { get; set; }
        public string UnitName { get; set; }
    }
}
