using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UnitRoomDto
{
  public  class GetFreeRoomValidation
    {
        public List<getFreeRoomsByUnitIdDto> getFreeRoomsByUnitIdDtos { get; set; }
        public int newSugestedUnitId { get; set; }
    }
}
