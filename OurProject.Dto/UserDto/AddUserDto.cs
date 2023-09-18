using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UserDto
{
    public class AddUserDto
    {
        [Required()]
        [MaxLength(30)]
        public String Name { get; set; }

        [Required(ErrorMessage = "الرجاء إدخال اسم المستخدم")]
        [MaxLength(50)]
        [MinLength(3, ErrorMessage = "الرجاء إدخال اسم المستخدم بطول 3 محارف")]
        public String UserName { get; set; }

        public String Password { get; set; }

        public String Image { get; set; }

        //[Required(ErrorMessage = "الرجاء إدخال اسم المستخدم")]
        //[MaxLength(10)]
        //[MinLength(10, ErrorMessage = "الرجاء إدخال رقم الهاتف بطول 10 ارقام")]
        //public String PhoneNumber { get; set; }

        [Required(ErrorMessage = "الرجاء ادخال رقم الهاتف")]
        [RegularExpression(@"^09([0-9]{8})$", ErrorMessage = "الرجاء ادخال رقم الهاتف بطول 10 ارقام ويبدأ ب 09")]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage ="",ErrorMessageResourceType =null)]
        //public DateTime Date { get; set; }

        [Required(ErrorMessage = "Expiration Date is required")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }


        public int RoleId { get; set; }
    }
}
