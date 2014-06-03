using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrarySkema;
using ClassLibrarySkema.ModelLayer;

namespace GUISchemaPlanner.Controllers
{
    public class SchemaController : Controller
    {
        SchemaService service = new SchemaService();
        
        public ActionResult Teacher(string id)
        {
            Skema teacherSchema = service.CreateTeacherSkema(id);
            return View(teacherSchema);
        }


        public ActionResult Hold(string id)
        {
            Skema holdSchema = service.CreateHoldSkema(id);
            return View(holdSchema);
        }


        public ActionResult Course(string id)
        {
            Skema courseSchema = service.CreateKursusSkema(id);
            return View(courseSchema);
        }


        public ActionResult Room(string id)
        {
            Skema roomSchema = service.CreateLokaleSkema(id);
            return View(roomSchema);
        }

	}
}