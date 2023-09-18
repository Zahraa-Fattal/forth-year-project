using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UnitDto
{
   public class GetAllUnitsInfoDto
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string Image { get; set; }
        public string SuperVisorName { get; set; }
        public string StoreKeeperName { get; set; }
        public bool Gender { get; set; }
        public string studyBrancheName { get; set; }
        public string unitStoreName { get; set; }
        public int StudentCount { get; set; }
    }
}
