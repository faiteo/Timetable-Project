
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
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
