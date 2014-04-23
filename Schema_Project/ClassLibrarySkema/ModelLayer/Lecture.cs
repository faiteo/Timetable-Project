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
        public LectureTime Time { get; private set; }

        public Lokale Place { get; private set; }

        public Module Module { get; private set; }

        public Lecture(LectureTime time, Lokale place, Module lecture)
        {
            this.Module = lecture;
            this.Place = place;
            this.Time = time;
        }

        public override string ToString()
        {
            return
                "Week: " + Time.WeekNumber.ToString() + Environment.NewLine +
                "Day:" + Time.WeekDay.ToString() + Environment.NewLine +
                "Time:" + Time.TimeOfDay.ToString() + Environment.NewLine +
                "HoldIDs:" + string.Join(", ", Module.KursusObj.HoldObjs.Select(h => h.HoldCode)) + Environment.NewLine +
                "LærerID:" + Module.KursusObj.LaererObj.LaererKode + Environment.NewLine +
                "KursusID:" + Module.KursusObj.KursusKode + Environment.NewLine +
                "LokaleID:" + Place.LokaleKode + Environment.NewLine +
                "*****************************";
        }
    }

    public enum TimeOfDay { Morning, Afternoon }

    public class LectureTime
    {
        public int WeekNumber { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TimeOfDay TimeOfDay { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is LectureTime)
            {
                var that = (LectureTime)obj;
                return this.WeekNumber == that.WeekNumber &&
                       this.WeekDay == that.WeekDay &&
                       this.TimeOfDay == that.TimeOfDay;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return WeekNumber.GetHashCode() ^ WeekDay.GetHashCode() ^ TimeOfDay.GetHashCode();
        }

        public static bool operator ==(LectureTime t1, LectureTime t2)
        {
            return t1.Equals(t2);
        }

        public static bool operator !=(LectureTime t1, LectureTime t2)
        {
            return !t1.Equals(t2);
        }

        public override string ToString()
        {
            return string.Format("LectureTime - Week: {0}, Day: {1}, Time: {2}", WeekNumber, WeekDay, TimeOfDay);
        }
    }
}
