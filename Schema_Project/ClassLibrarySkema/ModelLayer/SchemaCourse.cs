using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class SchemaCourse
    {
        public Kursus Course { get; set; }
        public Lokale Place { get; set; }
        public List<LectureTime> LectureTimes { get; set; }
    }
}
