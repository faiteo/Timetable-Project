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

            //Set all the possible timeslots in all the rooms as free 
            Dictionary<Lokale, List<LectureTime>> freeRoomTimes = new Dictionary<Lokale, List<LectureTime>>();
            foreach (Lokale r in allRooms)
            {
                freeRoomTimes.Add(r, moodle.AllTimes());
            }
            
            // make each course into a SchemaCourse, and remove the lectureTimes for that SchemaCourse Main Loop
            foreach (Kursus course in moodle.Courses)
            {
                // Get all the rooms with sufficient capacity, based on the total number of students taking the course
                List<Lokale> possibleRooms = FindPossibleRooms(course, allRooms);

                // Dictionary from possible rooms to the possible times for the course. A possible lecture time must have no teacher clash or hold clash. We already know there is no room clash, since we remove the times we have already used for the schema courses in that room.
                Dictionary<Lokale, List<LectureTime>> possibleRoomTimes = FindPossibleRoomTimes(schemaCourses, course, freeRoomTimes, possibleRooms);

                //Dictionary<Lokale, List<LectureTime>> possibleRoomTimesFiltered = filterPossibleRoomTimes(possibleRoomTimes);


                // of the rooms in possibleRoomTimes.Keys, select those where the number of possible lecture times is enough for the course
                List<Lokale> possibleRoomsWithEnoughLectureTimes = FindPossibleRoomsWithEnoughLectureTimes(possibleRoomTimes, course);
                
                Lokale selectedRoom;
                try
                {
                    // the selected room is first of the possibleRoomsWithEnoughLectureTimes
                    selectedRoom = possibleRoomsWithEnoughLectureTimes.First();
                }
                catch
                {
                    throw new ExceptionSchemaPlanning(course);
                }

                //possibleRoomTimes[selectedRoom]
                // the selectedLectureTimes is the first course.Course.ModuleCount number of lectureTimes from the possibleLectureTimes for the selected room
                List<LectureTime> selectedLectureTimes = SelectLectureTimes(course, possibleRoomTimes[selectedRoom]);
            
                // make a new SchemaCourse and add it to the list of already planned schemacourses.
                schemaCourses.Add(new SchemaCourse() { Course = course, Place = selectedRoom, LectureTimes = selectedLectureTimes });

                // remove the selected times from the available times for the selected room.
                foreach (LectureTime lt in selectedLectureTimes)
                {
                    freeRoomTimes[selectedRoom].Remove(lt);
                }
            }
            return new MasterSchema() { SchemaCourse = schemaCourses };
        }



        //method for choosing the room with >= the number of lecturetimes from the dictionary containing room/lecturetimes enough for the modules in the course 
        public List<Lokale> FindPossibleRoomsWithEnoughLectureTimes(Dictionary<Lokale, List<LectureTime>> possibleRoomTimes, Kursus course)
        {
            List<Lokale> possibleRoomWithEnoughLectureTimes = new List<Lokale>();
            int numberOfModules = course.ModuleCount;

            foreach (var r in possibleRoomTimes)
            {
                if (r.Value.Count >= numberOfModules)
                {
                    possibleRoomWithEnoughLectureTimes.Add(r.Key);
                }
            }    
            return possibleRoomWithEnoughLectureTimes;
        }



        public List<LectureTime> SelectLectureTimes(Kursus course, List<LectureTime> possibleLectureTimes)
        {
            int lectureCount = course.ModuleCount;
            List<LectureTime> listToReturn = new List<LectureTime>();
            listToReturn = possibleLectureTimes.Take(lectureCount).ToList();
            return listToReturn;
        }

        List<Lokale> FindPossibleRooms(Kursus kursus, List<Lokale> lokalelist)
        {
            List<Lokale> possibleRooms = new List<Lokale>();

            foreach (Lokale lokale in lokalelist)
            {
                if (RoomHasCapacity(lokale, kursus))
                {
                    possibleRooms.Add(lokale);
                }
            }

            return possibleRooms;
        }


      


        //Checks if the total number of students is greater or equal to the size of the lokale 
        public bool RoomHasCapacity(Lokale room, Kursus course)
        {
            //List<int> holdCountList = HoldCount(course);
            //int totalSumOfHold = holdCountList.Sum();
            //return room.LokaleCapacity >= totalSumOfHold;

            return room.LokaleCapacity >= course.HoldObjs.Select(h => h.HoldAntal).Sum();
        }

        // returns the total number of students from each Hold, participating in a given Kursus   
        private List<int> HoldCount(Kursus kursus)
        {
            IEnumerable<int> numberOfStudents = kursus.HoldObjs.Select(h => h.HoldAntal);
            return numberOfStudents.ToList();
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
            // All the already planned schemacourses, where a teacher has been booked to teach a course
            IEnumerable<SchemaCourse> coursesForThisTeacher = planned.Where(sc => sc.Course.LaererObj == teacher);
            return coursesForThisTeacher.Any(sc => sc.LectureTimes.Contains(time));

            //return planned.Where(sc => sc.Course.LaererObj == teacher).Any(sc => sc.LectureTimes.Contains(time));
        }

        // there is a hold clash if any of the hold in the lecture is already in some other lecture at the same time
        private bool HoldClash(List<SchemaCourse> planned, List<Hold> hold, LectureTime time)
        {
            return hold.Any(h => planned.Where(sc => sc.Course.HoldObjs.Contains(h)).Any(sc => sc.LectureTimes.Contains(time)));
        }



        Dictionary<Lokale, List<LectureTime>> FindPossibleRoomTimes(List<SchemaCourse> planned, Kursus course, Dictionary<Lokale, List<LectureTime>> freeRoomTimes, List<Lokale> possibleRooms)
        {
            Dictionary<Lokale, List<LectureTime>> possibleRoomTimes = new Dictionary<Lokale, List<LectureTime>>();
            foreach (var r in possibleRooms)//"possibleRooms" the rooms with enough capacity for the students attending the course.
            {
                possibleRoomTimes[r] = new List<LectureTime>();
                
                foreach (var lt in freeRoomTimes[r])
                {
                    if (IsPossibleTimeForCourse(planned, course, lt))
                    {
                        possibleRoomTimes[r].Add(lt);
                    }
                }                
             }      
            return possibleRoomTimes;
        }

        ////method to filter and select only some particular days from the list of lecturetimes
        //private Dictionary<Lokale, List<LectureTime>> filterPossibleRoomTimes(Dictionary<Lokale, List<LectureTime>> possibleRoomTimes)
        //{
        //    throw new NotImplementedException();
        //}


    }
}







   