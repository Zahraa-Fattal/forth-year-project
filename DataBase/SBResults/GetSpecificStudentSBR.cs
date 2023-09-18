using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
  public class GetSpecificStudentSBR
    {
        public int studentId { get; set; }
        public string studentName { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public string UniversityId { get; set; }
        public string PhoneNumber { get; set; }
        public int StudyBranchId { get; set; }
        public string studyBranchesName { get; set; }
        public int studentCityId { get; set; }
        public string mainOrCountryName { get; set; }
        public string mainCityName { get; set; }
        public string RoomName { get; set; }
        public int? unitRoomId { get; set; }
        public int? MainCity { get; set; }
        public bool Gender { get; set; }
        public int SuggestedUnitId { get; set; }
    }
}
