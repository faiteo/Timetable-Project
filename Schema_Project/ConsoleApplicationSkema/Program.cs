﻿using System;
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

            foreach (var hold in moodle.Hold)
                Console.WriteLine(hold);

            foreach (var teacher in moodle.Teachers)
                Console.WriteLine(teacher);

            Console.WriteLine(moodle.LookupTeacher("PAN"));

            Console.WriteLine(moodle.LookupHold("MTH2014"));

            foreach (var teacherCode in moodle.Teachers.Select(t => t.LaererKode))
                Console.WriteLine(moodle.LookupTeacher(teacherCode));

            foreach (var holdCode in moodle.Hold.Select(h => h.HoldCode))
                Console.WriteLine(moodle.LookupHold(holdCode));

            foreach (var course in moodle.Courses)
                Console.WriteLine(course);

            foreach (var module in planner.AllModules(moodle.Courses))
                Console.WriteLine(module);

            foreach (var timeAndPlace in planner.GeneratePossibleTimesAndPlaces(moodle.Rooms))
                Console.WriteLine(timeAndPlace);

            Skema mySkema = planner.GenerateSchema(moodle);

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
