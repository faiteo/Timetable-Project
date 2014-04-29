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
        public MasterSchema GenerateSchema(IMoodle moodle)
        {
            return null;
        }

        public class TimeAndPlace
        {
            public LectureTime Time { get; set; }
            public Lokale Place { get; set; }

            public override string ToString()
            {
                return string.Format("TimeAndPlace - Place: {0}, Time: {1}", Place, Time);
            }
        }
    }
}
