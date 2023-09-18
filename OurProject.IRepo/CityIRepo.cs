using OurProject.Dto.CityDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface CityIRepo
    {
        public bool AddCity(AddCityDto dto);
        public List<GetAllCityDto> GetAllCity();
        public bool UpdateCity(AddCityDto dto, int id);
        public bool DeleteCity(int id);

    }
}
