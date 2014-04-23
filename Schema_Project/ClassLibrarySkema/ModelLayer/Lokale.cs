using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Lokale
    {
        public string LokaleKode { get; set; }
        public int LokaleCapacity { get; set; }
        public string LokaleFacility { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Lokale)
            {
                var that = (Lokale)obj;
                return this.LokaleKode == that.LokaleKode;
                       
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.LokaleKode.GetHashCode();
        }

        public static bool operator ==(Lokale l1, Lokale l2)
        {
            return l1.Equals(l2);
        }

        public static bool operator !=(Lokale l1, Lokale l2)
        {
            return !l1.Equals(l2);
        }

    }
}
