using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
  public  class GetItemsInStoreUnitSBR
    {
        public string AccessoriesName { get; set; }
        public int StoreDetailsAmount { get; set; }
        public int StoreDetailsId { get; set; }
        public int? studentAmount { get; set; } = 0;
    }
}
