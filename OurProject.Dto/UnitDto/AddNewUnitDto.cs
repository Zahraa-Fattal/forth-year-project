using OurProject.Dto.StudyBranchDto;
using OurProject.Dto.UnitStoreDto;
using OurProject.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UnitDto
{
   public class AddNewUnitDto
    {
        public AddUnitDto UnitDto { get; set; }

        public List<GetFreeSuperVisorDto> SuperVisors { get; set; }

        public List<GetFreeStoreKeeperDto> StoreKeepers { get; set; }

        public List<GetAllStudyBranchDto> studyBranchs { get; set; }

        public List<GetFreeStoreDto> unitStores { get; set; }
        public bool male { get; set; }
        public bool female { get; set; }
    }
}
