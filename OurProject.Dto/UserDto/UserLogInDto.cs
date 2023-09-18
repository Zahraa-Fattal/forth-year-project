using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UserDto
{
   public class UserLogInDto
    {
        [Required(ErrorMessage = "الرجاء إدخال اسم المستخدم")]
        [MaxLength(50)]
        [MinLength(4, ErrorMessage = "الرجاء إدخال اسم المستخدم بطول 4 محارف")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال كلمة السر")]
        [MaxLength(20)]
        [MinLength(4, ErrorMessage = "الرجاء إدخال كلمة السر بطول 4 محارف")]
        public string Password { get; set; }
    }
}
