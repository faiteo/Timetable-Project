using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrarySkema;
using ClassLibrarySkema.ModelLayer;
using System.Linq;
using System.Collections;

namespace UnitTestSchemaProject

{
    [TestClass]
    public class TestSchemaClasses
    {
        SchemaService service = new SchemaService();

        [TestInitialize]
        public void TestInitialize()
        {
            IMoodle moodle = new DumbMoodle();
            SchemaPlanner planner = new SchemaPlanner();
        }

       

        [TestMethod]
        public void TestCourseIDInSchema()
        {
            Skema kursusSkema = service.CreateKursusSkema("COBOL200");

            Assert.IsTrue(kursusSkema.LectureList.Count > 0, "No lecture list was returned");
            foreach (Lecture item in kursusSkema.LectureList)
            {
                Assert.IsTrue(item.Course.KursusKode == "COBOL200", "there is a course ID different from COBOL200");
                Console.WriteLine(item.Course.KursusKode);
            }

        }


        [TestMethod]
        public void TestHoldDInSchema()
        {
            Skema holdSkema = service.CreateHoldSkema("BEC2011");
            Assert.IsTrue(holdSkema.LectureList.Count > 0, "No lecturlist was returned");
            foreach (Lecture item in holdSkema.LectureList)
            {
                foreach (Hold item2 in item.Hold)
                {
                    Console.WriteLine(item2.HoldCode);
                    Assert.IsTrue(item.Hold.Contains(new Hold() { HoldCode = "BEC2011"}), "there is a hold code different from BEC2011");
                }
                
            }

        }

        [TestMethod]
        public void TestTeacherIDInSchema()
        {
            Skema teacherSkema = service.CreateTeacherSkema("PAN");
            Assert.IsTrue(teacherSkema.LectureList.Count > 0, "lecturelist is empty");

            foreach (Lecture item in teacherSkema.LectureList)
            {
                Console.WriteLine(item.Teacher);
                Assert.IsTrue(item.Teacher.LaererKode == "PAN", "There is a with an ID different from PAN");

            }
        }


        [TestMethod]
        public void TestLokaleIDInSchema()
        {
            Skema lokaleSkema = service.CreateLokaleSkema("BH112");
            Assert.IsTrue(lokaleSkema.LectureList.Count > 0, "lecturelist is empty");

            foreach (Lecture item in lokaleSkema.LectureList)
            {
                Console.WriteLine(item.Place.LokaleKode);
                Assert.IsTrue(item.Place.LokaleKode == "BH112", "There is a lokale with an ID different from BH112");

            }

        }

 
    }
}
