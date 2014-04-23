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
        List<Lokale> Rooms { get; }
        List<Laerer> Teachers { get; }
        List<Kursus> Courses { get; }
        List<Hold> Hold { get; }
        Laerer LookupTeacher(string teacherCode);
        Hold LookupHold(string holdCode);
    }
}
