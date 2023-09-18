using OurProject.Dto.UnitRoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface UnitRoomIRepo
    {
        public bool AddUnitRoom(AddUnitRoomDto dto);
        public List<GetAllUnitRoomDto> GetAllUnitRoom();
        public bool UpdateUnitRoom(AddUnitRoomDto dto, int id);
        public bool UpdateUnitRoomForExitStudent( int id);
        public bool DeleteUnitRoom(int id);
        public List<getFreeRoomsByUnitIdDto> GetAllFreeUnitRoom(int UnitId);
        public AddUnitRoomDto GetUnitRoomById(int id);
        public List<GetRoomsInUnitDto> GetRoomsInUnit(int unitId);
        public List<GetRoomsInUnitDto> GetRoomsInUnitByDate(int unitId,DateTime minDate,DateTime maxDate);
        public List<GetStudentInRoomDto> GetStudentInRoom(int unitId,int unitRoomId);
        public List<GetStudentInRoomDto> GetStudentInRoomByDate(int unitId,int unitRoomId, DateTime minDate, DateTime maxDate);

    }
}
