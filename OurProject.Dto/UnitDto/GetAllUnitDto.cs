using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UnitDto
{
    public class GetAllUnitDto
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Image { get; set; }
        public bool Gender { get; set; }

        public int UserSuperVisorFk { get; set; }
        public int UserUnitStoreKeeperFk { get; set; }

        public int UnitStoreFk { get; set; }

        public int StudyBranchEntityId { get; set; }
    }
}
