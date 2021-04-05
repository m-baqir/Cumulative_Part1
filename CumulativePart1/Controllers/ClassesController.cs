using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CumulativePart1.Models;

namespace CumulativePart1.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }
        /* // GET: Classes/List */
        public ActionResult List()
        {
            //instantiating a new controller
            ClassesDataController controller = new ClassesDataController();
            //Using the listclasses method from ClassesDataController to return a new list
            IEnumerable<Classes> Classes = controller.ListClasses();
            //return classes object to List view
            return View(Classes);
        }
        // //GET: Classes/show/{id}
        public ActionResult Show(int id)
        {
            //instantiating a new controller
            ClassesDataController controller = new ClassesDataController();
            //using findclass method to return a new class object
            Classes NewClass = controller.FindClass(id);

            //return NewClass object to Show View to render the webpage
            return View(NewClass);
        }
    }
}