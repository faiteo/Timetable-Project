using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    // A lecture is a module that has a time and a place. A concretized module.
    public class Lecture
    {
        public LectureTime Time { get; set; }

        public Lokale Place { get; set; }

        public Kursus Course { get; set; }

        public Laerer Teacher { get; set; }
        public List<Hold> Hold { get; set; }


        public override string ToString()
        {
            return
                "Week: " + Time.WeekNumber.ToString() + Environment.NewLine +
                "Day:" + Time.WeekDay.ToString() + Environment.NewLine +
                "Time:" + Time.TimeOfDay.ToString() + Environment.NewLine +
                "HoldIDs:" + string.Join(", ", Hold.Select(h => h.HoldCode)) + Environment.NewLine +
                "LærerID:" + Teacher.LaererKode + Environment.NewLine +
                "KursusID:" + Course.KursusKode + Environment.NewLine +
                "LokaleID:" + Place.LokaleKode + Environment.NewLine +
                "*****************************";
        }
    }
}
