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
                };
            }
        }

        public List<Kursus> Courses
        {
            get 
            {
                throw new Exception();
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
