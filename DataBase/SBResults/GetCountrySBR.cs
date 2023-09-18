using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.SBResults
{
    [Keyless]
   public class GetCountrySBR
    {
        public int Id { get; set; }
        public string countryName { get; set; }
    }
}
