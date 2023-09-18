using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetAccessoriesDetailsSBR
    {
        public int StoreDetailsId { get; set; }
        public int AccessoriesId { get; set; }
        public int Amount { get; set; }
        public string ItemName { get; set; }
        public string Image { get; set; }
    }
}
