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
        public Skema GenerateSchema(IMoodle moodle)
        {
            List<TimeAndPlace> possibleTimesAndPlaces = GeneratePossibleTimesAndPlaces(moodle.Rooms);
            List<Module> modules = AllModules(moodle.Courses);
           
            Skema schema = new Skema();

            foreach (var module in modules)
            {
                //first check if there is a clash (the same teacher/hold has not been booked at the same time, in another location)
                TimeAndPlace firstFitTimeAndPlace = possibleTimesAndPlaces.First(t => schema.CanAddLecture(new Lecture(t.Time, t.Place, module)));
                Lecture lectureToBeAdded = new Lecture(firstFitTimeAndPlace.Time, firstFitTimeAndPlace.Place, module);
                schema.AddLecture(lectureToBeAdded);
                possibleTimesAndPlaces.Remove(firstFitTimeAndPlace);
            }

            return schema;
        }

        // return all the modules in the courses as a single list
        public List<Module> AllModules(List<Kursus> courses) 
        {
            List<Module> moduleList = new List<Module>();
            foreach (var item in courses)
            {
                foreach (var item2 in item.Modules )
                {
                    moduleList.Add(item2);
                }
            }

            return moduleList; 
        }

        // return a list of all possible time and place combinations
        public List<TimeAndPlace> GeneratePossibleTimesAndPlaces(List<Lokale> places)
        {
            //generates a list of integers 1 => 20, this will be used to represent week 1 to 20.
            List<int> weeks = Enumerable.Range(1, 20).ToList();
            List<DayOfWeek> days = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            List<TimeOfDay> dayTimes = new List<TimeOfDay>() { TimeOfDay.Morning, TimeOfDay.Afternoon };

            List<TimeAndPlace> listToReturn = new List<TimeAndPlace>();

            for (int i = 0; i < weeks.Count; i++) 
            {
                foreach (var lokale in places)  
                {
                    foreach (var dayofweek in days) 
                    {
                        foreach (var timeofday in dayTimes) 
                        {
                            listToReturn.Add(new TimeAndPlace()
                               {
                                   Place = lokale,            
                                   Time = new LectureTime()   
                                   {
                                       WeekNumber = i,       
                                       WeekDay = dayofweek,   
                                       TimeOfDay = timeofday  
                                   }
                               }
                            );  

                        } 

                    } 

                }  

            }

            return listToReturn;
        }

        public class TimeAndPlace
        {
            public LectureTime Time { get; set; }
            public Lokale Place { get; set; }

            public override string ToString()
            {
                return string.Format("TimeAndPlace - Place: {0}, Time: {1}", Place, Time);
            }
        }
    }
}
