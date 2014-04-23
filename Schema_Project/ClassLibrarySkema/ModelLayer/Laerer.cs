using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Laerer
    {
        public string LaererFirstName { get; set; }
        public string LaererLastName { get; set; }
        public string LaererKode { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Laerer)
            {
                var that = (Laerer)obj;
                return this.LaererKode == that.LaererKode;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.LaererKode.GetHashCode();
        }

        public static bool operator ==(Laerer l1, Laerer l2)
        {
            return l1.Equals(l2);
        }

        public static bool operator !=(Laerer l1, Laerer l2)
        {
            return !l1.Equals(l2);
        }

        public override string ToString()
        {
            return string.Format("Laerer - Code: {0}", LaererKode);
        }

        ////this parameters probably have to be categorized.
        //public int LaererPreference { get; set; }
        //public List<string> NotAvailableDates { get; set; }
    }
}
