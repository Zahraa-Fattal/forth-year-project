using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UnitDto
{
    public class AddUnitDto
    {
        [Required(ErrorMessage = "الرجاء إدخال اسم الوحدة")]
        [MaxLength(30)]
        [MinLength(3, ErrorMessage = "الرجاء إدخال اسم المستخدم بطول 3 محارف")]
        public String Name { get; set; }

        public String Image { get; set; }

        public bool Gender { get; set; }

        public int UserSuperVisorFk { get; set; }

      
        public int UserUnitStoreKeeperFk { get; set; }

        
        public int UnitStoreFk { get; set; }

       
        public int StudyBranchEntityId { get; set; }
    }
}
