using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodesWeaver.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int ID { get; internal set; }
        public string StudentName { get; set; }
        public string StudentPhone { get; set; }
        public string StudentDept { get; set; }
        public string StudentImage { get; set; }
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public List<string> Programming { get; internal set; }
    }
}
