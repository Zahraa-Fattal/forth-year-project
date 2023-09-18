using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
   public class VacationDateEntity
    {
        public int Id { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
