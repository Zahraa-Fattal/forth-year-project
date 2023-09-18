using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.Dto.UserDto
{
   public class GetStoreKeeperInfoDto
    {
        public int StoreKeeperId { get; set; }

        [Display(Name = "اسم أمين المستودع")]
        public string StoreKeeperName { get; set; }

        [Display(Name = "رقم الهاتف")]
        public string PhoneNumber { get; set; }

        [Display(Name = "اسم الوحدة التابع لها")]
        public string unitName { get; set; }

        [Display(Name = "تاريخ التعيين")]
        public DateTime Date { get; set; }

        [Display(Name = "صورة أمين المستودع")]
        public string Image { get; set; }
    }
}
