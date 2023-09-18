using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetMainCitySBR
    {
        public int Id { get; set; }
        public string mainCityName { get; set; }
    }
}
