using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentAccessoriesDto
{
  public  class GetItemsByStudentIdDto
    {
        public string AccessoriesName { get; set; }
        public int StudentAccessoriesAmount { get; set; }
        public int AccessoriesId { get; set; }
    }
}
