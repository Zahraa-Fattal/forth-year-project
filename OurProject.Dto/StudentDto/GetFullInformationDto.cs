using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDto
{
  public  class GetFullInformationDto
    {
        public string studentName { get; set; }
        public string UniversityId { get; set; }
        public string NationalId { get; set; }
        public string PhoneNumber { get; set; }
        public int CityId { get; set; }
        public DateTime RecordedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string mainOrCountryName { get; set; }
        public string mainCityName { get; set; }
        public string roomName { get; set; }
        public string SuperVisorName { get; set; }
        public string StoreKeeperName { get; set; }
        public string studyBranchesName { get; set; }
    }
}
