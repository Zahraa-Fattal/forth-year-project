using OurProject.Dto.UnitDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface UnitIRepo
    {
        public bool AddUnit(AddUnitDto dto);
        public int AddUnitWithIdReturn(AddUnitDto dto);
        public List<GetAllUnitDto> GetAllUnit();
        public AddUnitDto GetOneUnit(int id);
        public GetSpecificUnitDto GetSpecificUnit(int unitId);
        public bool UpdateUnit(AddUnitDto dto, int id);
        public bool DeleteUnit(int id);
        public List<GetAllUnitsInfoDto> GetAllUnitInfo();
        public int GetUnitIdBySuperVisorId(int id);
        public int GetUnitIdByStoreKeeperId(int id);
        public int GetUnitStoreIdByStoreKeeperId(int id);
        public string GetUnitNameByStoreKeeperId(int id);

    }
}
