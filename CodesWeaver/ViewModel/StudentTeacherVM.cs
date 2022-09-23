using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodesWeaver.ViewModel
{
    public class StudentTeacherVM
    {
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentDept { get; set; }
        public string TeacherName { get; set; }
        public string TeacherPhone { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public IFormFile StudentImage { get; set; }
        public string TeacherEmail { get; set; }

    }
}
