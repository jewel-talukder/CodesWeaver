using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodesWeaver.Models
{
    public class Teacher : Student
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public string TeacherPhone { get; set; }
        public DateTime TeacherEmail { get; set; }
        public int StudentId { get; set; }
    }
}
