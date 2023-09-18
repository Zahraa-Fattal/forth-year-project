using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
  [Keyless]
  public  class GetItemsByStudentIdSBR
    {
        public string AccessoriesName { get; set; }
        public int StudentAccessoriesAmount { get; set; }
        public int AccessoriesId { get; set; }
    }
}
