using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentAccessoriesDto
{
   public class GetItemsInStoreUnitDto
    {
        public string AccessoriesName { get; set; }
        public int StoreDetailsAmount { get; set; }
        public int StoreDetailsId { get; set; }
        public int studentAmount { get; set; }
    }
}
