using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string NationalId { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public int SuggestedUnitId { get; set; }

        [Required]
        public string UniversityId { get; set; }

        public string Image { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        public bool Recorded { get; set; }

        public bool IsDeleted { get; set; } = false;
        [Required]
        public DateTime RecordedDate { get; set; } 
        [Required]
        public DateTime AccessoriesDate { get; set; }

        public int? UnitRoomFk { get; set; } 
        public int OldUnitRoomFk { get; set; }

        //[Required]
        //[ForeignKey("UnitRooms")]
        //public int UnitRoomId { get; set; }
        //public virtual UnitRoomEntity UnitRoom { get; set; }

        [Required]
        [ForeignKey("StudyBranchs")]
        public int StudyBranchId { get; set; }
        public virtual StudyBranchEntity StudyBranch { get; set; }

        [Required]
        [ForeignKey("Cities")]
        public int CityId { get; set; }
        public virtual CityEntity City { get; set; }




    }
}
