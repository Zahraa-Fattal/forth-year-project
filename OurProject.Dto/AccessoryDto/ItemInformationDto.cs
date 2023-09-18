using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.AccessoryDto
{
  public  class ItemInformationDto
    {
        public List<GetAccessoriesDetailsDto> getAccessoriesDetailsDtos { get; set; }
        public AddAccessoryDto AddAccessoryDto { get; set; }
        public int Amount { get; set; }
        public int StoreDetailsId { get; set; }
        public int AccessoriesId { get; set; }
    }
}
