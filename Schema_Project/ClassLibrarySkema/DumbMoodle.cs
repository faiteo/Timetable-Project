using ClassLibrarySkema.ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema
{
    public class DumbMoodle : IMoodle
    {
        public List<Lokale> Rooms
        {
            get
            {
                throw new Exception();
            }
        }

        public List<Laerer> Teachers
        {
            get 
            {
                throw new Exception();
            }
        }

        public IEnumerable<Kursus> Courses
        {
            get 
            {
                throw new Exception();
            }
        }

        public IEnumerable<Hold> Hold
        {
            get 
            {
                throw new Exception();
            }
        }
    }
}
