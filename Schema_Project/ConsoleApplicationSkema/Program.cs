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
            IMoodle moodle = new DumbMoodle();
            SchemaPlanner planner = new SchemaPlanner();

            foreach (var room in moodle.Rooms)
                Console.WriteLine(room);

            Console.ReadLine();

            foreach (var hold in moodle.Hold)
                Console.WriteLine(hold);

            Console.ReadLine();

            foreach (var teacher in moodle.Teachers)
                Console.WriteLine(teacher);

            Console.ReadLine();

            Console.WriteLine(moodle.LookupTeacher("PAN"));

            Console.ReadLine();

            Console.WriteLine(moodle.LookupHold("MTH2014"));

            Console.ReadLine();

            foreach (var teacherCode in moodle.Teachers.Select(t => t.LaererKode))
                Console.WriteLine(moodle.LookupTeacher(teacherCode));

            Console.ReadLine();

            foreach (var holdCode in moodle.Hold.Select(h => h.HoldCode))
                Console.WriteLine(moodle.LookupHold(holdCode));

            Console.ReadLine();

            foreach (var course in moodle.Courses)
                Console.WriteLine(course);

            Console.ReadLine();


            MasterSchema masterSchema = planner.GenerateSchema(moodle);



            //create a schema for kursus with this id ALG100: 
            Skema kursusSkema = service.CreateKursusSkema("ALG100", masterSchema);
            foreach (var item in kursusSkema.LectureList)
            {
                Console.WriteLine(item.ToString());

            }

            //create a schema for teacher with this initials: PJE
            Skema teacherSkema = service.CreateTeacherSkema("PJE", masterSchema);
            foreach (var item in teacherSkema.LectureList)
            {
                Console.WriteLine(item.ToString());
            }

            //create a schema for lokale with this id: BH112
            Skema lokaleSkema = service.CreateLokaleSkema("BH112", masterSchema);
            foreach (var item in lokaleSkema.LectureList)
            {
                Console.WriteLine(item.ToString());
            }


            //create a schema for a group/hold with id: MTH2014
            Skema holdSkema = service.CreateHoldSkema("MTH2014", masterSchema);

            foreach (var item in holdSkema.LectureList)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
            
        }
    }
}
