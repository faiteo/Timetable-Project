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
                    new Lokale() { LokaleKode = "BH112", LokaleCapacity = 100, LokaleFacility = "Video" },
                    new Lokale() { LokaleKode = "BH140", LokaleCapacity = 50, LokaleFacility = "Video" },
                    new Lokale() { LokaleKode = "BH114", LokaleCapacity = 30, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH142", LokaleCapacity = 30, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH116", LokaleCapacity = 40, LokaleFacility = "None" },
                    new Lokale() { LokaleKode = "BH124", LokaleCapacity = 10, LokaleFacility = "None" }
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
        public List<Hold> Hold
        {
            get 
            {
                return new List<Hold>() 
                {
                    new Hold() { HoldCode = "MTH2014", HoldAntal = 10, HoldName = "Mathematics 2014" },
                    new Hold() { HoldCode = "CSC2014", HoldAntal = 40, HoldName = "Computer Science 2014" },
                    new Hold() { HoldCode = "BEC2014", HoldAntal = 20, HoldName = "Business Economics 2014" },
                    new Hold() { HoldCode = "CSC2013", HoldAntal = 20, HoldName = "Computer Science 2013" },
                    new Hold() { HoldCode = "SOC2014", HoldAntal = 20, HoldName = "Sociology 2014" },
                    new Hold() { HoldCode = "CSC2012", HoldAntal = 20, HoldName = "Computer Science 2012" },
                    new Hold() { HoldCode = "ELEC2012", HoldAntal = 15, HoldName = "Electrical Engineering 2012"},
                    new Hold() { HoldCode = "CHEM2012", HoldAntal = 18, HoldName = "Chemistry 2012" },
                    new Hold() { HoldCode = "BEC2011", HoldAntal = 20, HoldName = "Business Economics 2011" },
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
                    new Kursus("COBOL200", "Cobol Programming", 10, new List<string>(){"BEC2014","CSC2013"},"PAN", this),
                    new Kursus("ALG100", "Algorithm and Data Structure", 20, new List<string>(){"CSC2014", "MTH2014"},"PJE", this),
                    new Kursus("SemVer100", "Semantic and Verification", 15, new List<string>(){"CSC2013","CSC2012"},"KWI", this),
                    new Kursus("STAT100", "Statistics", 20 , new List<string>(){"MTH2014","ELEC2012"}, "HWA", this),
                    new Kursus("ALGEBRA101", "Introduction to Algebra", 20 , new List<string>(){"MTH2014","BEC2011"}, "CBA", this),
                    new Kursus("BUS100", "Principles of Business Economics", 20 , new List<string>(){"BEC2011","MTH2014"}, "HJA", this ),
                    new Kursus("SOCSC100", "Introduction to Social Sciences", 20 , new List<string>(){"SOC2014","CHEM2012"}, "JAC", this), 
                    new Kursus("OOAD100", "Object Oriented Analysis Design", 15 , new List<string>(){"CSC2013","CSC2014"}, "MIA",this),
                    new Kursus("WEB200", "Web Programming", 12 , new List<string>(){"CSC2014","BEC2014"}, "PAN", this)
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
    }
}
