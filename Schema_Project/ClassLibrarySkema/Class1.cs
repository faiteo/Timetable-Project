using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using ClassLibrarySkema.ModelLayer;


namespace ClassLibrarySkema
{
    public class Class1
    {
        /// <summary>
        /// used to create a schema for a given hold/group
        /// </summary>
        /// <param name="holdKode">id of the hold/group we want the schema for</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a group/hold</returns>
        public Skema CreateHoldSkema(string holdKode, Skema skemaObj)
        {
            Skema ResultSkema = new Skema();
            List<Lecture> inputList = skemaObj.LectureList;
            foreach (var item in inputList)
            {
                if(item.HoldObj.HoldCode == holdKode)
                {
                    ResultSkema.LectureList.Add(item);
                }
            }
            return ResultSkema;
        }


        /// <summary>
        /// used to create a teacher's schema
        /// </summary>
        /// <param name="teacherID">the id of the teacher we want the schema for</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a given teacher</returns>
        public Skema CreateTeacherSkema(string teacherID, Skema skemaObj)
        {
            Skema ResultSkema = new Skema();
            List<Lecture> inputList = skemaObj.LectureList;
            foreach (var item in inputList)
            {
                if (item.LaererObj.LaererKode == teacherID)
                {
                    ResultSkema.LectureList.Add(item);
                }
            }
            return ResultSkema;
        }


        /// <summary>
        /// used to create the schema of a given lokale 
        /// </summary>
        /// <param name="lokaleID">id of the lokale</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a given lokale</returns>
        public Skema CreateLokaleSkema(string lokaleID, Skema skemaObj)
        {
            Skema ResultSkema = new Skema();
            List<Lecture> inputList = skemaObj.LectureList;
            foreach (var item in inputList)
            {
                if (item.LokaleObj.LokaleKode == lokaleID)
                {
                    ResultSkema.LectureList.Add(item);
                }
            }
            return ResultSkema;
        }


        /// <summary>
        /// used to create a schema for a given kursus
        /// </summary>
        /// <param name="lokaleID">id of the kursus</param>
        /// <param name="skemaObj">a general schema containing all lecture information</param>
        /// <returns>a schema for a given kursus</returns>
        public Skema CreateKursusSkema(string kursusID, Skema skemaObj)
        {
            Skema ResultSkema = new Skema();
            List<Lecture> inputList = skemaObj.LectureList;
            foreach (var item in inputList)
            {
                if (item.KursusObj.KursusKode == kursusID)
                {
                    ResultSkema.LectureList.Add(item);
                }
            }
            return ResultSkema;
        }
       
        
    }
}
