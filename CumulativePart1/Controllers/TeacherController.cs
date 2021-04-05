using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativePart1.Models;

namespace CumulativePart1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        // GET: Teacher/List
        public ActionResult List()
        {
            //instantiating a new controller
            TeacherDataController controller = new TeacherDataController();
            // creating a new list of Teachers using listteachers function
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            //return Teachers list to list view
            return View(Teachers);
        }
        // GET: Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            //instantiating a new controller
            TeacherDataController controller = new TeacherDataController();
            //creating newteacher object with the findteacher function
            Teacher NewTeacher = controller.FindTeacher(id);

            //return newteacher object to show view
            return View(NewTeacher);
        }

    }
}