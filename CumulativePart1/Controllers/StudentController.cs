using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativePart1.Models;

namespace CumulativePart1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        // GET: Student/List
        public ActionResult List()
        {
            //instantiating a new controller
            StudentDataController controller = new StudentDataController();
            //Using the liststudents function from StudentDataController to return a new list
            IEnumerable<Student> Students = controller.ListStudents();
            //return student object to List view
            return View(Students);
        }
        // GET: Student/Show/{id}
        public ActionResult Show(int id)
        {
            //instantiating a new controller
            StudentDataController controller = new StudentDataController();
            //using findstudent function to return a newstudent object
            Student NewStudent = controller.FindStudent(id);

            //return newstudent object to show view
            return View(NewStudent);
        }
    }
}