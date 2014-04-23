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
                   !HoldClash(lecture);
        }

        // there is a hold clash if any of the hold in the lecture is already in some other lecture at the same time
        private bool HoldClash(Lecture lecture)
        {
            return LectureList.Where(l => l.Module.HoldObjs.Any(h => lecture.Module.HoldObjs.Contains(h))).Any(l => l.Time == lecture.Time);
        }

        // there is a room clash if there is already a lecture at the same time and place
        private bool RoomClash(Lecture lecture)
        {
            return LectureList.Where(l => l.Place == lecture.Place).Any(l => l.Time == lecture.Time);
        }

        // there is a teacher clash if the lecture teacher is already in another lecture at the same time
        private bool TeacherClash(Lecture lecture)
        {
            return LectureList.Where(l => l.Module.LaererObj == lecture.Module.LaererObj).Any(l => l.Time == lecture.Time);
        }

        // prerequisite: CanAddLecture(lecture)
        public void AddLecture(Lecture lecture)
        {
            this.LectureList.Add(lecture);
        }
    }
}
