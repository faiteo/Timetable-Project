using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrarySkema.ModelLayer;
using ClassLibrarySkema;


namespace ConsoleApplicationSkema
{
    public class Program
    {
        
        public static void Main(string[] args)
        {

            Class1 service = new Class1();
            

            Skema mySkema = new Skema();

            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "8:15 - 10:00",
                HoldObj = new Hold() { HoldCode = "CSC2014", HoldAntal = 40, HoldName = "Computer Science 2014" },
                KursusObj = new Kursus() { KursusKode = "ALG100", KursusName = "Algorithm and Data Structure", KursusAntalModul = 20 },
                LaererObj = new Laerer() { LaererFirstName = "Paul", LaererLastName = "Andersen", LaererKode = "PAN" },
                LokaleObj = new Lokale() { LokaleKode = "BH112", LokaleCapacity = 50, LokaleFacility = "Video" }
            });

            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "12:30 - 14:15",
                HoldObj = new Hold() { HoldCode = "CSC2014", HoldAntal = 40, HoldName = "Computer Science 2014" },
                KursusObj = new Kursus() { KursusKode = "SemVer100", KursusName = "Semantic and Verification", KursusAntalModul = 15 },
                LaererObj = new Laerer() { LaererFirstName = "Peter", LaererLastName = "Hans", LaererKode = "PHA" },
                LokaleObj = new Lokale() { LokaleKode = "BH140", LokaleCapacity = 50, LokaleFacility = "Video" }
            });

            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "10:15 - 12:00",
                HoldObj = new Hold() { HoldCode = "MTH2014", HoldAntal = 10, HoldName = "Mathematics 2014" },
                KursusObj = new Kursus() { KursusKode = "STAT100", KursusName = "Statistics", KursusAntalModul = 20 },
                LaererObj = new Laerer() { LaererFirstName = "Philip", LaererLastName = "Jensen", LaererKode = "PJE" },
                LokaleObj = new Lokale() { LokaleKode = "BH112", LokaleCapacity = 50, LokaleFacility = "Video" }
            });

            
            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "14:30 - 16:15",
                HoldObj = new Hold() { HoldCode = "MTH2014", HoldAntal = 10, HoldName = "Mathematics 2014" },
                KursusObj = new Kursus() { KursusKode = "ALG100", KursusName = "Algorithm and Data Structure", KursusAntalModul = 20 },
                LaererObj = new Laerer() { LaererFirstName = "Paul", LaererLastName = "Andersen", LaererKode = "PAN" },
                LokaleObj = new Lokale() { LokaleKode = "BH140", LokaleCapacity = 30, LokaleFacility = "None" }
            });


            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "14:30 - 16:15",
                HoldObj = new Hold() { HoldCode = "MTH2014", HoldAntal = 10, HoldName = "Mathematics 2014" },
                KursusObj = new Kursus() { KursusKode = "ALGEBRA101", KursusName = "Introduction to Algebra", KursusAntalModul = 20 },
                LaererObj = new Laerer() { LaererFirstName = "Karina", LaererLastName = "Williams", LaererKode = "KWI" },
                LokaleObj = new Lokale() { LokaleKode = "BH112", LokaleCapacity = 50, LokaleFacility = "Video" }
            });

            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "8:15 - 10:00",
                HoldObj = new Hold() { HoldCode = "BE2014", HoldAntal = 20, HoldName = "Business Economics 2014" },
                KursusObj = new Kursus() { KursusKode = "BUS100", KursusName = "Principles of Business Economics", KursusAntalModul = 20 },
                LaererObj = new Laerer() { LaererFirstName = "Karina", LaererLastName = "Williams", LaererKode = "KWI" },
                LokaleObj = new Lokale() { LokaleKode = "BH114", LokaleCapacity = 30, LokaleFacility = "None" }
            });

            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "10:15 - 12:00",
                HoldObj = new Hold() { HoldCode = "SOC2014", HoldAntal = 20, HoldName = "Sociology 2014" },
                KursusObj = new Kursus() { KursusKode = "SOCSC100", KursusName = "Introduction to Social Sciences", KursusAntalModul = 20 },
                LaererObj = new Laerer() { LaererFirstName = "Henrik", LaererLastName = "Walter", LaererKode = "HWA" },
                LokaleObj = new Lokale() { LokaleKode = "BH114", LokaleCapacity = 30, LokaleFacility = "None" }
            });

            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "8:15 - 10:00",
                HoldObj = new Hold() { HoldCode = "CSC2013", HoldAntal = 20, HoldName = "Computer Science 2013" },
                KursusObj = new Kursus() { KursusKode = "OOAD100", KursusName = "Object Oriented Analysis Design", KursusAntalModul = 15 },
                LaererObj = new Laerer() { LaererFirstName = "Victor", LaererLastName = "Kenneth", LaererKode = "VKE" },
                LokaleObj = new Lokale() { LokaleKode = "BH142", LokaleCapacity = 30, LokaleFacility = "None" }
            });

            
            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "08:15 - 10:00",
                HoldObj = new Hold() { HoldCode = "CSC2012", HoldAntal = 20, HoldName = "Computer Science 2012" },
                KursusObj = new Kursus() { KursusKode = "STAT100", KursusName = "Statistics", KursusAntalModul = 20 },
                LaererObj = new Laerer() { LaererFirstName = "Philip", LaererLastName = "Jensen", LaererKode = "PJE" },
                LokaleObj = new Lokale() { LokaleKode = "BH140", LokaleCapacity = 30, LokaleFacility = "None" }
            });


            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "10:15 - 12:00",
                HoldObj = new Hold() { HoldCode = "CSC2012", HoldAntal = 20, HoldName = "Computer Science 2012" },
                KursusObj = new Kursus() { KursusKode = "WEB200", KursusName = "Web Programming", KursusAntalModul = 12 },
                LaererObj = new Laerer() { LaererFirstName = "Christian", LaererLastName = "Baak", LaererKode = "CBA" },
                LokaleObj = new Lokale() { LokaleKode = "BH142", LokaleCapacity = 30, LokaleFacility = "None" }
            });


            mySkema.LectureList.Add(new Lecture()
            {
                WeekNumber = 17,
                DateInfo = "22/04/2014",
                TimeInfo = "12:30 - 14:15",
                HoldObj = new Hold() { HoldCode = "BE2014", HoldAntal = 20, HoldName = "Business Economics 2014" },
                KursusObj = new Kursus() { KursusKode = "COBOL200", KursusName = "Cobol Programming", KursusAntalModul = 10 },
                LaererObj = new Laerer() { LaererFirstName = "Hans", LaererLastName = "Jakobsen", LaererKode = "HJA" },
                LokaleObj = new Lokale() { LokaleKode = "BH112", LokaleCapacity = 50, LokaleFacility = "Video" }
            });


            //create a schema for a group/hold with id: MTH2014
            Skema holdSkema = service.CreateHoldSkema("MTH2014", mySkema);
  
            foreach (var item in holdSkema.LectureList)
            {
                Console.WriteLine(item.ToString());
            }

            //create a schema for teacher with this initials: PJE
            Skema teacherSkema = service.CreateTeacherSkema("PJE", mySkema);
            foreach (var item in teacherSkema.LectureList)
            {
                Console.WriteLine(item.ToString());
            }

            //create a schema for lokale with this id: BH112
            Skema lokaleSkema = service.CreateLokaleSkema("BH112", mySkema);
            foreach (var item in lokaleSkema.LectureList)
            {
                Console.WriteLine(item.ToString());
            }


            //create a schema for kursus with this id ALG100: 
            Skema kursusSkema = service.CreateKursusSkema("ALG100", mySkema);
            foreach (var item in kursusSkema.LectureList)
            {
                Console.WriteLine(item.ToString());

            }

            Console.ReadKey();
            
        }
    }
}
