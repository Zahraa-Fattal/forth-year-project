using OurProject.Dto.AccessoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
   public interface AccessoryIRepo
    {
        public bool AddAccessory(AddAccessoryDto dto);
        public List<GetAllAccessoryDto> GetAllAccessory();
        public bool UpdateAccessory(AddAccessoryDto dto, int id);
        public bool DeleteAccessory(int id);
        public List<GetAccessoriesDetailsDto> GetAccessoriesDetails(int unitStoreId);
        public int AddAccessoryWithIdReturn(AddAccessoryDto dto);

    }
}
