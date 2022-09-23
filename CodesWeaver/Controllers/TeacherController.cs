using CodesWeaver.Data;
using CodesWeaver.Models;
using CodesWeaver.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodesWeaver.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SessonKey") != null)
            {
                var Tcr = _context.teachers.ToList();
                var Std = _context.Students.ToList();
                var data = (from a in Tcr
                            join b in Std on a.StudentId equals b.Id
                            select new StudentTeacherVM
                            {
                                TeacherId = a.Id,
                                StudentName = b.StudentName,
                                StudentPhone = b.StudentPhone,
                                StudentDept = b.StudentDept,
                                TeacherName = a.TeacherName

                            }).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }


        }

        public IActionResult Create()
        {
            TakeData();
            return View();
        }
        private void TakeData()
        {
            List<Student> students = new List<Student>();
            students = _context.Students.ToList();
            ViewBag.student = students;
        }
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {

            _context.teachers.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            TakeData();
            var data = _context.teachers.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            
            _context.teachers.Update(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
       

