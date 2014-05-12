using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ClassLibrarySkema.ModelLayer;


namespace ClassLibrarySkema
{
    public class SchemaService
    {
        MasterSchema masterschema;

        public SchemaService()
        {
            IMoodle moodle = new DumbMoodle();
            SchemaPlanner planner = new SchemaPlanner();
            this.masterschema = planner.GenerateSchema(moodle);
        }
        /// <summary>
        /// used to create a schema for a given hold/group
        /// </summary>
        /// <param name="holdKode">id of the hold/group we want the schema for</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a group/hold</returns>
        public Skema CreateHoldSkema(string holdKode)
        {
            Skema resultSkema = new Skema();
            //List<Hold> holdList = null;
            foreach (SchemaCourse item in masterschema.SchemaCourse)
            {
                //holdList = item.Course.HoldObjs;
                if (CheckHoldInList(item.Course.HoldObjs, holdKode)) 
                {
                    foreach (LectureTime lt in item.LectureTimes)
                    {
                        Lecture lecture = new Lecture()
                        {
                            Time = lt,
                            Place = item.Place,
                            Course = item.Course,
                            Teacher = item.Course.LaererObj,
                            Hold = item.Course.HoldObjs
                        }; 
                        resultSkema.LectureList.Add(lecture);
                    }
                }
                //holdList = null;
            }
            return resultSkema;
        }
 
    


        private bool CheckHoldInList(List<Hold> listOfHold, string holdCode)
        {
            //bool result = false;
            foreach (Hold item in listOfHold)
            {
                if (item.HoldCode == holdCode)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="teacherID"></param>
        /// <param name="skemaObj"></param>
        /// <returns></returns>
        public Skema CreateTeacherSkema(string teacherID)
        {
            Skema resultSkema = new Skema();
            foreach (SchemaCourse item in masterschema.SchemaCourse)
            {
                if(item.Course.LaererObj.LaererKode == teacherID)
                    foreach(LectureTime lt in item.LectureTimes)
                    {
                        Lecture lecture = new Lecture()
                        {
                            Time = lt,
                            Place = item.Place,
                            Course = item.Course,
                            Teacher = item.Course.LaererObj,
                            Hold = item.Course.HoldObjs
                        };
                        resultSkema.LectureList.Add(lecture);
                    }
            }
            return resultSkema;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="lokaleID"></param>
        /// <param name="skemaObj"></param>
        /// <returns></returns>
        public Skema CreateLokaleSkema(string lokaleID)
        {
            Skema resultSkema = new Skema();
            foreach(SchemaCourse item in masterschema.SchemaCourse)
            {
                if(item.Place.LokaleKode == lokaleID)
                    foreach (LectureTime lt in item.LectureTimes)
                    {
                        Lecture lecture = new Lecture()
                        {
                            Time = lt,
                            Place = item.Place,
                            Course = item.Course,
                            Teacher = item.Course.LaererObj,
                            Hold = item.Course.HoldObjs
                        };
                        resultSkema.LectureList.Add(lecture);
                    }
            }
            return resultSkema;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lokaleID"></param>
        /// <param name="skemaObj"></param>
        /// <returns></returns>
        public Skema CreateKursusSkema(string courseCode)
        {
            Skema resultSkema = new Skema();

            foreach (SchemaCourse item in masterschema.SchemaCourse)
            {
                if(item.Course.KursusKode == courseCode)
                {
                    foreach (LectureTime item2 in item.LectureTimes)
                    {
                        Lecture lecture = new Lecture()
                        {
                            Time = item2,
                            Place = item.Place,
                            Course = item.Course,
                            Teacher = item.Course.LaererObj,
                            Hold = item.Course.HoldObjs
                        };
                        resultSkema.LectureList.Add(lecture);
                    }
                }
            }
            return resultSkema; 
        }
       
        
    }
}
