using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
  public  class GetFreeStoreSBR
    {
        public int unitStoresId { get; set; }
        public string unitStoresName { get; set; }
    }
}
