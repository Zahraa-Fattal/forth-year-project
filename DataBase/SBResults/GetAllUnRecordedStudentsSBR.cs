using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetAllUnRecordedStudentsSBR
    {
        public int studentId { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string UniversityId { get; set; }
        public string Image { get; set; }
        public DateTime date { get; set; }
    }
}
