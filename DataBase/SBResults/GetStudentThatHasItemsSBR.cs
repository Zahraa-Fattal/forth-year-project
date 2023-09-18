using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
    public  class GetStudentThatHasItemsSBR
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime AccessoriesDate { get; set; }
    }
}
