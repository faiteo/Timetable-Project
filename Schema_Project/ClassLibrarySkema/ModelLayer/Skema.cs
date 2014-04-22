using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Skema
    {
        public int SkemaId { get; set; }
        public List <Lecture> LectureList { get; set; }

        public Skema()
        {
            LectureList = new List<Lecture>();
        }

        //public SkemaHold(string weekNumber, string date, string time, string groupCode, string teacherCode, string courseCode, string roomCode)
        //{
             
        //}
    }
}
