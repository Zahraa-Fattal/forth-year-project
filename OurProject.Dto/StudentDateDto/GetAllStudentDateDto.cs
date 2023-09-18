using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.StudentDateDto
{
     public class GetAllStudentDateDto
    {

        public int id { get; set; }
        public float Price { get; set; }


        public int StudentId { get; set; }


        public DateTime date { get; set; }


    public int DateTypeId { get; set; }
    }
}
