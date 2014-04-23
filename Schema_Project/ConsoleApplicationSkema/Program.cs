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

            Skema mySkema = new SchemaPlanner().GenerateSchema(moodle);

            //create a schema for a group/hold with id: MTH2014
            Skema holdSkema = service.CreateHoldSkema("MTH2014", mySkema, moodle);
  
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
