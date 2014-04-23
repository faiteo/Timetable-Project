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

        // there is a hold clash if any of the hold in the lecture is already in some other lecture at the same time
        private bool HoldClash(Lecture lecture)
        {
            throw new Exception();
        }

        // there is a room clash if there is already a lecture at the same time and place
        private bool RoomClash(Lecture lecture)
        {
            throw new Exception();
        }

        // there is a teacher clash if the lecture teacher is already in another lecture at the same time
        private bool TeacherClash(Lecture lecture)
        {
            throw new Exception();
        }

        // RoomHasCapacity is true, if the total number of students can fit in the room
        // i.e. the sum of HoldAntal for all hold in the module is less than the room capacity
        private bool RoomHasCapacity(Lecture lecture)
        {
            throw new Exception();
        }

        // prerequisite: CanAddLecture(lecture)
        public void AddLecture(Lecture lecture)
        {
            this.LectureList.Add(lecture);
        }
    }
}
