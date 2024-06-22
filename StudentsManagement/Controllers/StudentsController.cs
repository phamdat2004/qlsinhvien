using StudentsManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsManagement.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(string.Empty).OrderBy(x=>x.FullName).ToList();
            return View(obj);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student stu)
        {
            if(ModelState.IsValid)
            {
                StudentList stuList = new StudentList();
                stuList.AddStudent(stu);
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(string id = "")
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Edit(Student stu)
        {
            StudentList stuList = new StudentList();
            stuList.UpdateStudent(stu);
            return RedirectToAction("Index");
        }
        public ActionResult Details(string id = "")
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        public ActionResult Delete(string id = "")
        {
            StudentList stuList = new StudentList();
            List<Student> obj = stuList.getStudent(id);
            return View(obj.FirstOrDefault());
        }
        [HttpPost]
        public ActionResult Delete(Student stu)
        {
            StudentList stuList = new StudentList();
            stuList.DeleteStudent(stu);
            return RedirectToAction("Index");
        }
    }
}