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
            var possibleTimesAndPlaces = GeneratePossibleTimes();
            var modules = AllLectures(moodle);
            var schema = new Skema();

            foreach (var module in modules)
            {
                var firstFitTime = possibleTimesAndPlaces.First(t => schema.CanAddLecture(new Lecture(t.Item1, t.Item2, module)));
                schema.AddLecture(new Lecture(firstFitTime.Item1, firstFitTime.Item2, module));
                possibleTimesAndPlaces.Remove(firstFitTime);
            }

            return schema;
        }

        private List<Module> AllLectures(IMoodle moodle) {
            var allCourses = moodle.Courses;
            var allCourseModules = allCourses.Select(c => Enumerable.Repeat(c, c.KursusAntalModul));
            var allLectures = allCourseModules.Select(ms => 
                ms.Select(m => 
                    new Module() { 
                        KursusObj = m, 
                        HoldObjs = moodle.HoldForCourse(m).ToList(), 
                        LaererObj = moodle.MainTeacherForCourse(m) } ));
            return allLectures.JaggedPivot().Aggregate(new List<Module>(), (acc, ms) => acc.Concat(ms).ToList()).ToList();
        }

        // return a list of all possible time and place combinations
        private List<Tuple<LectureTime, Lokale>> GeneratePossibleTimes()
        {
            var weeks = Enumerable.Range(1, 20);
            IEnumerable<DayOfWeek> weekdays = new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            var daytimes = new List<TimeOfDay>() { TimeOfDay.Morning, TimeOfDay.Afternoon };
            var list = new List<Tuple<LectureTime, Lokale>>();
            foreach (var week in weeks)
                foreach (var day in weekdays)
                    foreach (var time in daytimes)
                        foreach (var place in Rooms)
                            list.Add(Tuple.Create(new LectureTime() { WeekNumber = week, WeekDay = day, TimeOfDay = time }, place));
            return list;
        }

        private List<Lokale> Rooms = new List<Lokale>() {
            new Lokale() { LokaleKode = "BH112", LokaleCapacity = 50, LokaleFacility = "Video" },
            new Lokale() { LokaleKode = "BH140", LokaleCapacity = 50, LokaleFacility = "Video" },
            new Lokale() { LokaleKode = "BH114", LokaleCapacity = 30, LokaleFacility = "None" },
            new Lokale() { LokaleKode = "BH142", LokaleCapacity = 30, LokaleFacility = "None" }
        };
    }

    // can take a list of enumerables of enumerables and enumerate over them across.
    //
    // e.g. items   = { { "1", "2", "3", "4" } , 
    //                  { "a", "b", "c" } }; 
    //
    //      results = { { "1", "a" }, 
    //                  { "2", "b" }, 
    //                  { "3", "c" }, 
    //                  { "4" } };
    //
    // found on stackoverflow: http://stackoverflow.com/questions/3989319/zip-n-ienumerablets-together-iterate-over-them-simultaneously
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> JaggedPivot<T>(
          this IEnumerable<IEnumerable<T>> source)
        {
            List<IEnumerator<T>> originalEnumerators = source
              .Select(x => x.GetEnumerator())
              .ToList();

            try
            {
                List<IEnumerator<T>> enumerators = originalEnumerators
                  .Where(x => x.MoveNext()).ToList();

                while (enumerators.Any())
                {
                    List<T> result = enumerators.Select(x => x.Current).ToList();
                    yield return result;
                    enumerators = enumerators.Where(x => x.MoveNext()).ToList();
                }
            }
            finally
            {
                originalEnumerators.ForEach(x => x.Dispose());
            }
        }
    }
}
