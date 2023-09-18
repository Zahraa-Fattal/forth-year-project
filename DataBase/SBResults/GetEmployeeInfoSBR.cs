using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetEmployeeInfoSBR
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string roleName { get; set; }
    }
}
