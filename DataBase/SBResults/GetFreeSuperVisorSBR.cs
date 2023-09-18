using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetFreeSuperVisorSBR
    {
        public int SuperVisorId { get; set; }
        public string SuperVisorName { get; set; }
       
    }
}
