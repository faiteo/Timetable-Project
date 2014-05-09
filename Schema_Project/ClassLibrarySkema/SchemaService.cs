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
        /// <summary>
        /// used to create a schema for a given hold/group
        /// </summary>
        /// <param name="holdKode">id of the hold/group we want the schema for</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a group/hold</returns>
        public Skema CreateHoldSkema(string holdKode)
        {
            Skema ResultSkema = new Skema();



            //Hold hold = moodle.Hold.First(h => h.HoldCode == holdKode);
            //List<Lecture> inputList = skemaObj.LectureList;
            //foreach (var item in inputList)
            //{
            //    if(item.Module.KursusObj.HoldObjs.Contains(hold))
            //    {
            //        ResultSkema.LectureList.Add(item);
            //    }
            //}
            return ResultSkema;
        }


        /// <summary>
        /// used to create a teacher's schema
        /// </summary>
        /// <param name="teacherID">the id of the teacher we want the schema for</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a given teacher</returns>
        public Skema CreateTeacherSkema(string teacherID)
        {
            Skema ResultSkema = new Skema();
            //List<Lecture> inputList = skemaObj.LectureList;
            //foreach (var item in inputList)
            //{
            //    if (item.Module.KursusObj.LaererObj.LaererKode == teacherID)
            //    {
            //        ResultSkema.LectureList.Add(item);
            //    }
            //}
            return ResultSkema;
        }


        /// <summary>
        /// used to create the schema of a given lokale 
        /// </summary>
        /// <param name="lokaleID">id of the lokale</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a given lokale</returns>
        public Skema CreateLokaleSkema(string lokaleID)
        {
            Skema ResultSkema = new Skema();
            //List<Lecture> inputList = skemaObj.LectureList;
            //foreach (var item in inputList)
            //{
            //    if (item.Place.LokaleKode == lokaleID)
            //    {
            //        ResultSkema.LectureList.Add(item);
            //    }
            //}
            return ResultSkema;
        }


        /// <summary>
        /// used to create a schema for a given kursus
        /// </summary>
        /// <param name="lokaleID">id of the kursus</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a given kursus</returns>
        public Skema CreateKursusSkema(string courseCode)
        {
            Skema ResultSkema = new Skema();

            //List<Lecture> inputList = skemaObj.LectureList;
            //foreach (var item in inputList)
            //{
            //    if (item.Module.KursusObj.KursusKode == kursusID)
            //    {
            //        ResultSkema.LectureList.Add(item);
            //    }
            //}
            return ResultSkema;
        }
       
        
    }
}
