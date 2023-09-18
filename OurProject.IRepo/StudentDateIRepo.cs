﻿using OurProject.Dto.StudentDateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurProject.IRepo
{
    public interface StudentDateIRepo
    {
        public bool AddStudentDate(AddStudentDateDto dto);
        public List<GetAllStudentDateDto> GetAllStudentDate();
        public bool UpdateStudentDate(AddStudentDateDto dto, int id);
        public bool DeleteStudentDate(int id);

        public GetAllStudentDateDto GetStudentDateByUserId(int studentId);

    }
}
