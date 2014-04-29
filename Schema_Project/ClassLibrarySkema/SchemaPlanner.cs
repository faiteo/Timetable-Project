using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrarySkema.ModelLayer;

namespace ClassLibrarySkema
{
    public class SchemaPlanner
    {
        public MasterSchema GenerateSchema(IMoodle moodle)
        {
            List<SchemaCourse> schemaCourses = new List<SchemaCourse>();
            List<Lokale> allRooms = moodle.Rooms;
            Dictionary<Lokale, List<LectureTime>> allRoomTimes = allRooms.ToDictionary(r => r, r => AllTimes());

            // make each course into a SchemaCourse, and remove the lectureTimes for that SchemaCourse 
            foreach (Kursus course in moodle.Courses)
            {
                // generate possible rooms for the course. Rooms must have sufficient capacity
                List<Lokale> possibleRooms = allRooms.Where(r => RoomHasCapacity(r, course)).ToList(); ;

                // Fictionary from possible rooms to the possible times for the course. A possible lecture time must have no teacher clash or hold clash. We already know there is no room clash, since we remove the times we have already used for the schema courses in that room.
                Dictionary<Lokale, List<LectureTime>> possibleRoomTimes = possibleRooms.ToDictionary(r => r, r => allRoomTimes[r].Where(time => IsPossibleTimeForCourse(schemaCourses, course, time)).ToList());

                // the selected roomtime is the first pair of room and list of lecturetimes from the possible roomtimes, where there are enough lecturetimes for the course
                KeyValuePair<Lokale, List<LectureTime>> selectedRoomTime = possibleRoomTimes.Where(kv => kv.Value.Count() >= course.ModuleCount).First();

                // the selected room is the key of the the selected roomtime
                Lokale selectedRoom = selectedRoomTime.Key;

                // the selected room is the required number of lecturetimes for the course, taken from the selected roomtime pair.
                List<LectureTime> selectedTimes = selectedRoomTime.Value.Take(course.ModuleCount).ToList();

                // make a new SchemaCourse and add it to the list of already planned schemacourses.
                schemaCourses.Add(new SchemaCourse() { Course = course, Place = selectedRoom, LectureTimes = selectedTimes });

                // remove the selected times from the available times for the selected room.
                // implemented as remove all lectureTimes from the available times for the room, where such a time is contained in the selected times.
                allRoomTimes[selectedRoom].RemoveAll(t => selectedTimes.Contains(t));
            }
            return new MasterSchema() { SchemaCourse = schemaCourses };
        }

        // generate all combinations of weeks from 1 to 20, days from Monday to Friday and daytimes from morning to afternoon
        public List<LectureTime> AllTimes() 
        {
            var ret = from week in Enumerable.Range(1, 20)
                      from day in new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday }
                      from time in new List<TimeOfDay>() { TimeOfDay.Morning, TimeOfDay.Afternoon }
                      select new LectureTime() { WeekNumber = week, WeekDay = day, TimeOfDay = time };
            return ret.ToList();
        }

        public bool RoomHasCapacity(Lokale room, Kursus course)
        {
            return room.LokaleCapacity >= course.HoldObjs.Select(h => h.HoldAntal).Sum();
        }

        // We already know that the room has capacity, and that nobody else is in the room at the same time. 
        // We want to avoid :
        //   1: that the teacher is somewhere else at the same time
        //   2: that any of the hold is somewhere else at the same time
        public bool IsPossibleTimeForCourse(List<SchemaCourse> planned, Kursus course, LectureTime time)
        {
            return !TeacherClash(planned, course.LaererObj, time) &&
                   !HoldClash(planned, course.HoldObjs, time);
        }

        // there is a teacher clash if the teacher for the lecture has already been assigned to the same timeslot
        public bool TeacherClash(List<SchemaCourse> planned, Laerer teacher, LectureTime time)
        {
            return planned.Where(sc => sc.Course.LaererObj == teacher).Any(sc => sc.LectureTimes.Contains(time));
        }

        // there is a hold clash if any of the hold in the lecture is already in some other lecture at the same time
        private bool HoldClash(List<SchemaCourse> planned, List<Hold> hold, LectureTime time)
        {
            return hold.Any(h => planned.Where(sc => sc.Course.HoldObjs.Contains(h)).Any(sc => sc.LectureTimes.Contains(time)));
        }
    }
}
