using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetAllRecorderStudentsSBR
    {
        public int studentId { get; set; }
        public string StudentName { get; set; }
        public string NationalId { get; set; }
        public string UniversityId { get; set; }
        public string Image { get; set; }
    }
}
