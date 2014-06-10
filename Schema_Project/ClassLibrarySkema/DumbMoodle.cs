using ClassLibrarySkema.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema
{
    public class DumbMoodle : IMoodle
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Lokale> Rooms
        {
            get
            {
                return new List<Lokale>() { 
                    new Lokale() { LokaleKode = "BH112", LokaleCapacity = 50, LokaleFacility = "Video" },
                    new Lokale() { LokaleKode = "BH140", LokaleCapacity = 30, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH114", LokaleCapacity = 50, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH142", LokaleCapacity = 50, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH116", LokaleCapacity = 40, LokaleFacility = "Video" },
                    new Lokale() { LokaleKode = "BH124", LokaleCapacity = 40, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH111", LokaleCapacity = 20, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH113", LokaleCapacity = 40, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH144", LokaleCapacity = 40, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH143", LokaleCapacity = 40, LokaleFacility = "None" },

                };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Laerer> Teachers
        {
            get 
            {
                return new List<Laerer>() {
                new Laerer() { LaererFirstName = "Paul", LaererLastName = "Andersen", LaererKode = "PAN" },
                new Laerer() { LaererFirstName = "Philip", LaererLastName = "Jensen", LaererKode = "PJE" },
                new Laerer() { LaererFirstName = "Karina", LaererLastName = "Williams", LaererKode = "KWI" },
                new Laerer() { LaererFirstName = "Henrik", LaererLastName = "Walter", LaererKode = "HWA" },
                new Laerer() { LaererFirstName = "Christian", LaererLastName = "Baak", LaererKode = "CBA" },
                new Laerer() { LaererFirstName = "Hans", LaererLastName = "Jakobsen", LaererKode = "HJA" },
                new Laerer() { LaererFirstName = "Jakob", LaererLastName = "Thomas", LaererKode = "JAC" },
                new Laerer() { LaererFirstName = "Michael", LaererLastName = "Alfred", LaererKode = "MIA" },
                };
            }
        }


        ///
        ///
        public List<Hold> Hold
        {
            get
            {
                return new List<Hold>() 
                {
                    new Hold() { HoldCode = "SWENG2014", HoldAntal = 10, HoldName = "Software Engineering 2014" },
                    new Hold() { HoldCode = "CSC2014", HoldAntal = 20, HoldName = "Computer Science 2014" },
                    new Hold() { HoldCode = "MTH2011", HoldAntal = 20, HoldName = "Mathemetics 2011"},
                    new Hold() { HoldCode = "CSC2013", HoldAntal = 20, HoldName = "Computer Science 2013" },
                    new Hold() { HoldCode = "SWENG2011", HoldAntal = 20, HoldName = "Software Engineering 2011" },
                    new Hold() { HoldCode = "CSC2012", HoldAntal = 20, HoldName = "Computer Science 2012" },
                    new Hold() { HoldCode = "SWENG2012", HoldAntal = 15, HoldName = "Software Engineering 2012"},
                    new Hold() { HoldCode = "SWENG2013", HoldAntal = 18, HoldName = "Software Engineering 2013" },
                    new Hold() { HoldCode = "CSC2011", HoldAntal = 20, HoldName = "Computer Science 2011" },
                    new Hold() { HoldCode = "MTH2013", HoldAntal = 20, HoldName = "Mathemetics 2013" },
                    new Hold() { HoldCode = "MTH2012", HoldAntal = 20, HoldName = "Mathemetics 2012" },
                    new Hold() { HoldCode = "MTH2014", HoldAntal = 15, HoldName = "Mathemetics 2014" },
                };
            }
        }

        public List<Kursus> Courses
        {
            get
            {
                return new List<Kursus>()
                {
                    //by using "this" we are referring to an object of type DumbMoodle. DumbMoodle implements IMoodle interface.
                    new Kursus("COBOL200", "Cobol Programming", 10, new List<string>(){"CSC2013"},"PAN", new List<DayOfWeek>(){DayOfWeek.Thursday}, TimeOfDay.Morning, this),
                    new Kursus("ALG100", "Algor/DataStruct", 15, new List<string>(){"CSC2014", "MTH2014"},"PJE", new List<DayOfWeek>(){DayOfWeek.Monday, DayOfWeek.Wednesday}, TimeOfDay.Morning, this),
                    new Kursus("SemVer100", "Semantic and Verification", 10, new List<string>(){"CSC2012"},"KWI",new List<DayOfWeek>(){DayOfWeek.Wednesday}, TimeOfDay.Afternoon, this),
                    new Kursus("STAT100", "Statistics", 10 , new List<string>(){"MTH2014", "CSC2012"}, "HWA", new List<DayOfWeek>(){DayOfWeek.Thursday}, TimeOfDay.Morning, this),
                    new Kursus("ALGEBRA101", "Introduction to Algebra", 20 , new List<string>(){"MTH2014","CSC2011"}, "CBA", new List<DayOfWeek>(){DayOfWeek.Friday}, TimeOfDay.Morning, this),
                    new Kursus("DBASE100", "Databases", 15 , new List<string>(){"CSC2011"}, "HJA", new List<DayOfWeek>(){DayOfWeek.Monday, DayOfWeek.Thursday}, TimeOfDay.Afternoon, this),
                    new Kursus("SWDES100", "Software Design", 15 , new List<string>(){"SWENG2014", "CSC2011"}, "JAC", new List<DayOfWeek>(){DayOfWeek.Wednesday}, TimeOfDay.Morning, this), 
                    new Kursus("OOAD100", "Object Oriented Analysis Design", 15 , new List<string>(){"CSC2013","SWENG2011"}, "MIA", new List<DayOfWeek>(){DayOfWeek.Thursday}, TimeOfDay.Afternoon, this),
                    new Kursus("WEB200", "Web Programming", 12 , new List<string>(){"SWENG2011","CSC2014"}, "PAN", new List<DayOfWeek>(){DayOfWeek.Wednesday}, TimeOfDay.Afternoon, this)
                };
            }
        }
            
        public Laerer LookupTeacher(string teacherCode)
        {
            return this.Teachers.First(l => l.LaererKode == teacherCode);
        }


        public Hold LookupHold(string holdCode)
        {
            return this.Hold.First(h => h.HoldCode == holdCode);
        }

        // generate all combinations of weeks from 1 to 20, days from Monday to Friday and daytimes from morning to afternoon
        public List<LectureTime> AllTimes()
        {
            List<LectureTime> listToReturn = new List<LectureTime>();
            List<int> weeks = Enumerable.Range(1, 20).ToList();
            List<DayOfWeek> days = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            List<TimeOfDay> times = new List<TimeOfDay>() { TimeOfDay.Morning, TimeOfDay.Afternoon };
            //var ret = from week in weeks
            //          from day in days
            //          from time in times
            //          select new LectureTime() { WeekNumber = week, WeekDay = day, TimeOfDay = time };
            //return ret.ToList();
            for (int i = 1; i <= weeks.Count ; i++)
            {
                foreach (DayOfWeek dow in days)
                {
                    foreach (TimeOfDay tod in times)
                    {
                        listToReturn.Add(new LectureTime()
                            {
                                WeekNumber = i,
                                WeekDay = dow,
                                TimeOfDay = tod
                            });
                    } 
                }
                
            }
            return listToReturn;
        }
    }
}
