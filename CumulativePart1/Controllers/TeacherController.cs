using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativePart1.Models;
using System.Diagnostics;

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
        public ActionResult List(string SearchKey = null)
        {
            //instantiating a new controller
            TeacherDataController controller = new TeacherDataController();
            // creating a new list of Teachers using listteachers function
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
            //return Teachers list to list view
            return View(Teachers);
        }
        // GET: Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            //instantiating a new controller
            TeacherDataController controller = new TeacherDataController();
            //creating newteacher object with the findteacher function
            Teacher SelectedTeacher = controller.FindTeacher(id);

            //return newteacher object to show view
            return View(SelectedTeacher);
        }
        // GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            //instantiating a new controller
            TeacherDataController controller = new TeacherDataController();
            //creating newteacher object with the findteacher function
            Teacher NewTeacher = controller.FindTeacher(id);

            //return newteacher object to show view
            return View(NewTeacher);
        }

        // POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("list");
        }

        //Get : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string teacherfname, string teacherlname, DateTime hiredate)
        {
            Debug.WriteLine("I have create");
            Debug.WriteLine(teacherfname);
            Debug.WriteLine(teacherlname);
            Debug.WriteLine(hiredate);
            //create new teacher object
            Teacher NewTeacher = new Teacher();
            NewTeacher.teacherfname = teacherfname;
            NewTeacher.teacherlname = teacherlname;
            NewTeacher.hiredate = hiredate;
            //send new object to datacontroller to execute sql query and add teacher to database
            TeacherDataController controller = new TeacherDataController();
            controller.CreateTeacher(NewTeacher);
            return RedirectToAction("List");
        }
        /// <summary>
        /// Routes Teacher Update Page. Displays information from the database.
        /// </summary>
        /// <param>Id of the teacher</param>
        /// <returns>an update teacher webpage which displays current information and asks for new information</returns>
        /// <example>GET : /Teacher/Update/5</example>
        public ActionResult Update(int id)
        {
            //new data controller initiated
            TeacherDataController controller = new TeacherDataController();
            //returns teacher information from FindTeacher method
            Teacher SelectedTeacher = controller.FindTeacher(id);
            
            return View(SelectedTeacher);
        }

        /// <summary>
        /// gets a post request from user with updated teacher information
        /// </summary>
        /// <param name="id">of teacher to update</param>
        /// <param name="teacherfname"> teacher first name</param>
        /// <param name="teacherlname"> teacher last name</param>
        /// <param name="hiredate">hire date</param>
        /// <returns>a webpage with current teacher information and allows new information to be submitted</returns>
        [HttpPost]
        public ActionResult Update(int id, string teacherfname, string teacherlname, DateTime hiredate)
        {
            //new teacher object
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.teacherfname = teacherfname;
            TeacherInfo.teacherlname = teacherlname;
            TeacherInfo.hiredate = hiredate;
            //calls the teacher data controller
            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);
            //returns to the particular teacher info page
            return RedirectToAction("Show/" + id);
        }
    }
}