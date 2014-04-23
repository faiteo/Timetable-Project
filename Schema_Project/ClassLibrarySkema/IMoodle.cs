using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrarySkema.ModelLayer;

namespace ClassLibrarySkema
{
    public interface IMoodle
    {
        IEnumerable<Laerer> Teachers { get; }
        IEnumerable<Kursus> Courses { get; }
        IEnumerable<Hold> Hold { get; }
        Laerer MainTeacherForCourse(Kursus course);
        IEnumerable<Hold> HoldForCourse(Kursus course);
    }
}
