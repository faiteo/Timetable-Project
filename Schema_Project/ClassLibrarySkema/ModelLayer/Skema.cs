using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Skema
    {
        public int SkemaId { get; set; }
        public List<Lecture> LectureList { get; set; }

        public Skema()
        {
           LectureList = new List<Lecture>();
        }

        public bool CanAddLecture(Lecture lecture)
        {
            return !TeacherClash(lecture) &&
                   !RoomClash(lecture) &&
                   !HoldClash(lecture) &&
                   RoomHasCapacity(lecture);
        }


        // there is a teacher clash if the teacher for the lecture has already been assigned to the same timeslot in another location
        private bool TeacherClash(Lecture lecture)
        {
            bool result = false;
            foreach (Lecture item in this.LectureList)
            {
                if ((lecture.Module.KursusObj.LaererObj.LaererKode == item.Module.KursusObj.LaererObj.LaererKode) &&
                    (lecture.Time == item.Time))
                {
                    result = true;
                }
            }
            return result;
        }


        // there is a room clash if there is already a lecture at the same time and place
        private bool RoomClash(Lecture lecture)
        {
            bool result = false;
            foreach (Lecture item in this.LectureList)
            {
                if ((lecture.Place.LokaleKode == item.Place.LokaleKode) && (lecture.Time == item.Time))
                {
                    result = true;
                }
            }
            return result;
        }

        // there is a hold clash if any of the hold in the lecture is already in some other lecture at the same time
        private bool HoldClash(Lecture lecture)
        {
            bool result = false; 
            foreach (var item in this.LectureList)
            {
                if ((lecture.Module.KursusObj.HoldObjs == item.Module.KursusObj.HoldObjs) && (lecture.Time == item.Time))
	            {
                    result = true;
                }
            }
                return result;
        }




        // RoomHasCapacity is true, if the total number of students can fit in the room
        // i.e. the sum of HoldAntal for all hold in the module is less than the room capacity
        private bool RoomHasCapacity(Lecture lecture)
        {
            //bool result = false;
            //foreach (Lecture item in this.LectureList)
            //{
            //    if((lecture.Module.KursusObj.HoldObjs.))
            //}

            throw new Exception();
        }

        // prerequisite: CanAddLecture(lecture)
        public void AddLecture(Lecture lecture)
        {
            this.LectureList.Add(lecture);
        }
    }
}
