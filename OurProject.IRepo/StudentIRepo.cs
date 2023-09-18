using OurProject.Dto.StudentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface StudentIRepo
    {
        public bool AddStudent(AddStudentDto dto);
        public List<GetAllStudentDto> GetAllStudent();
        public GetAllStudentDto GetOneStudentByStudentId(int id);
        public bool UpdateOldStudent(AddStudentDto dto, int id);
        public bool UpdateStudent(AddStudentDto dto, int id);
        public bool UpdateStudent_IsDeleted(AddStudentDto dto, int id);
        public bool DeleteStudent(int id);
        public List<GetMainCityDto> GetMainCity();
        public List<GetCountryDto> GetCountry(int MainCityId);
        public GetStudentCountInUniteDto GetStudentCount(int StudyBranchId,bool Gender);
        public GetLastDateDto GetLastDate(int SuggestedUnitId);
        public int AddStudentWithIdReturn(AddStudentDto dto);
        public bool IsuserNameAvailable(string email);
        public GetAllStudentDto GetStudentByNationalId(string NationalId);
        public GetAllStudentDto GetStudentById(int Id);
        public List<GetAllUnRecordedStudentsDto> GetAllStudentsInfo(int UnitId);
        public GetSpecificStudentDto GetSpecificStudent(int StudentId);
        public List<GetAllRecorderStudentsDto> GetAllRecorderStudents(int UnitId);
        public List<GetAllRecorderStudentsDto> SearchForRecorderStudents(int UnitId, string nationalId);
        public List<GetFullInformationDto> GetFullInformation(int UnitId);

    }
}
