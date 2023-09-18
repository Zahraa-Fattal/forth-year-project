using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UserDto
{
   public class GetSuperVisorInfoDto
    {
        public int SuperVisorId { get; set; }
        [Display(Name = "اسم المشرف")]
        public string SuperVisorName { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        [Display(Name = "اسم الوحدة التابع لها")]
        public string unitName { get; set; }

        [Display(Name = "تاريخ التعيين")]
        public DateTime Date { get; set; }

        [Display(Name = "صورة المستخدم")]
        public string Image { get; set; }
    }
}
