using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetSpecificUnitSBR
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int SuperVisorId { get; set; }
        public string SuperVisorName { get; set; }
        public int StoreKeeperId { get; set; }
        public string StoreKeeperName { get; set; }
        public string Image { get; set; }
        public bool Gender { get; set; }
        public int studyBranchesId { get; set; }
        public string studyBrancheName { get; set; }
        public int unitStoresId { get; set; }
        public string unitStoreName { get; set; }
    }
}
