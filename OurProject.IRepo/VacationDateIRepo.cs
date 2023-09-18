using OurProject.Dto.VacationDateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
   public interface VacationDateIRepo
    {
        public bool AddVacationDate(AddVacationDateDto dto);
        public List<GetAllVacationDateDto> GetAllVacationDate();
        public bool UpdateVacationDate(AddVacationDateDto dto, int id);
        public bool DeleteVacationDate(int id);
    }
}
