using OurProject.Dto.StoreDetailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface StoreDetailIRepo
    {
        public bool AddStoreDetail(AddStoreDetailDto dto);
        public List<GetAllStoreDetailDto> GetAllStoreDetail();
        public bool UpdateStoreDetail(AddStoreDetailDto dto, int id);
        public bool DeleteStoreDetail(int id);
        public bool UpdateStoreDetailNormal(AddStoreDetailDto dto, int id);
        public bool UpdateStoreDetailForExitStudent(AddStoreDetailDto dto, int id);

    }
}
