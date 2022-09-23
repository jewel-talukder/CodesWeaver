using CodesWeaver.Data;
using CodesWeaver.Models;
using CodesWeaver.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CodesWeaver.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public StudentController(DataContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SessonKey") != null)
            {
                var data = _context.Students.ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("Login", "Auth");
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentTeacherVM studentTeacher)
        {
            string uniqueFileName = UploadedFile(studentTeacher);
            Student student  = new Student
            {
                StudentName = studentTeacher.StudentName,
                StudentPhone = studentTeacher.StudentPhone,
                StudentDept = studentTeacher.StudentDept,
                StudentImage = uniqueFileName
            };
            _context.Students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        private string UploadedFile(StudentTeacherVM model)
        {
            string uniqueFileName = null;

            if (model.StudentImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.StudentImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.StudentImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public IActionResult Edit(int id)
        {
            List<string> nameList = new List<string>() { "Pranaya", "Kumar" };
            IEnumerable<char> methodSyntax = (IEnumerable<char>)nameList.SelectMany(x => x);
            List<Teacher> teachers = new List<Teacher>();
            var x = _context.teachers.SelectMany(c=>c.TeacherName).ToList();
            var data = _context.Students.Find(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = _context.Students.Find(id);
            return View(data);
        }
        public IActionResult Delete(int id)
        {
            var data = _context.Students.Find(id);
            _context.Students.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
