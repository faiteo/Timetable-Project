using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Hold
    {
        public string HoldCode { get; set; }
        public int HoldAntal { get; set; }
        public string HoldName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Hold)
            {
                var that = (Hold)obj;
                return this.HoldCode == that.HoldCode;
                       
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.HoldCode.GetHashCode();
        }

        public static bool operator ==(Hold h1, Hold h2)
        {
            return h1.Equals(h2);
        }

        public static bool operator !=(Hold h1, Hold h2)
        {
            return !h1.Equals(h2);
        }

        public override string ToString()
        {
            return string.Format("Hold - Code: {0}", HoldCode);
        }
    }
}
