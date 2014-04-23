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
        public IEnumerable<Laerer> Teachers
        {
            get 
            { 
                return new List<Laerer>() {
                    new Laerer() { LaererFirstName = "Paul", LaererLastName = "Andersen", LaererKode = "PAN" },
                    new Laerer() { LaererFirstName = "Peter", LaererLastName = "Hans", LaererKode = "PHA" },
                    new Laerer() { LaererFirstName = "Philip", LaererLastName = "Jensen", LaererKode = "PJE" },
                    new Laerer() { LaererFirstName = "Karina", LaererLastName = "Williams", LaererKode = "KWI" },
                    new Laerer() { LaererFirstName = "Henrik", LaererLastName = "Walter", LaererKode = "HWA" },
                    new Laerer() { LaererFirstName = "Victor", LaererLastName = "Kenneth", LaererKode = "VKE" },
                    new Laerer() { LaererFirstName = "Christian", LaererLastName = "Baak", LaererKode = "CBA" },
                    new Laerer() { LaererFirstName = "Hans", LaererLastName = "Jakobsen", LaererKode = "HJA" }
                };
            }
        }

        public IEnumerable<Kursus> Courses
        {
            get 
            { 
                return new List<Kursus>() {
                    new Kursus() { KursusKode = "ALG100", KursusName = "Algorithm and Data Structure", KursusAntalModul = 20 },
                    new Kursus() { KursusKode = "SemVer100", KursusName = "Semantic and Verification", KursusAntalModul = 15 },
                    new Kursus() { KursusKode = "STAT100", KursusName = "Statistics", KursusAntalModul = 20 },
                    new Kursus() { KursusKode = "ALGEBRA101", KursusName = "Introduction to Algebra", KursusAntalModul = 20 },
                    new Kursus() { KursusKode = "BUS100", KursusName = "Principles of Business Economics", KursusAntalModul = 20 },
                    new Kursus() { KursusKode = "SOCSC100", KursusName = "Introduction to Social Sciences", KursusAntalModul = 20 },
                    new Kursus() { KursusKode = "OOAD100", KursusName = "Object Oriented Analysis Design", KursusAntalModul = 15 },
                    new Kursus() { KursusKode = "WEB200", KursusName = "Web Programming", KursusAntalModul = 12 },
                    new Kursus() { KursusKode = "COBOL200", KursusName = "Cobol Programming", KursusAntalModul = 10 }
                };
            }
        }

        public IEnumerable<Hold> Hold
        {
            get 
            { 
                return new List<Hold>() {
                    new Hold() { HoldCode = "CSC2014", HoldAntal = 40, HoldName = "Computer Science 2014" },
                    new Hold() { HoldCode = "MTH2014", HoldAntal = 10, HoldName = "Mathematics 2014" },
                    new Hold() { HoldCode = "BE2014", HoldAntal = 20, HoldName = "Business Economics 2014" },
                    new Hold() { HoldCode = "SOC2014", HoldAntal = 20, HoldName = "Sociology 2014" },
                    new Hold() { HoldCode = "CSC2013", HoldAntal = 20, HoldName = "Computer Science 2013" },
                    new Hold() { HoldCode = "CSC2012", HoldAntal = 20, HoldName = "Computer Science 2012" },
                };
            }
        }

        public Laerer MainTeacherForCourse(Kursus course)
        {
            switch (course.KursusKode)
            {
                case "ALG100" : return Teachers.First(t => t.LaererKode == "PAN");
                case "SemVer100" : return Teachers.First(t => t.LaererKode == "PHA");
                case "STAT100" : return Teachers.First(t => t.LaererKode == "PJE");
                case "ALGEBRA101" : return Teachers.First(t => t.LaererKode == "KWI");
                case "BUS100" : return Teachers.First(t => t.LaererKode == "KWI");
                case "SOCSC100" : return Teachers.First(t => t.LaererKode == "HWA");
                case "OOAD100" : return Teachers.First(t => t.LaererKode == "VKE");
                case "WEB200" : return Teachers.First(t => t.LaererKode == "CBA");
                case "COBOL200" : return Teachers.First(t => t.LaererKode == "HJA");
                default : throw new Exception("Unknown course code");
            }
        }

        public IEnumerable<Hold> HoldForCourse(Kursus course)
        {
            switch (course.KursusKode)
            {
                case "ALG100" : return Hold.Where(h => h.HoldCode == "CSC2014" || h.HoldCode == "MTH2014");
                case "SemVer100" : return Hold.Where(h => h.HoldCode == "CSC2014");
                case "STAT100" : return Hold.Where(h => h.HoldCode == "MTH2014" || h.HoldCode == "CSC2012");
                case "ALGEBRA101" : return Hold.Where(h => h.HoldCode == "MTH2014");
                case "BUS100" : return Hold.Where(h => h.HoldCode == "BE2014");
                case "SOCSC100" : return Hold.Where(h => h.HoldCode == "SOC2014");
                case "OOAD100" : return Hold.Where(h => h.HoldCode == "CSC2013");
                case "WEB200" : return Hold.Where(h => h.HoldCode == "CSC2012");
                case "COBOL200" : return Hold.Where(h => h.HoldCode == "BE2014");
                default : throw new Exception("Unknown course code");
            }
        }
    }
}
