using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Module
    {
        public List<Hold> HoldObjs { get; set; }
        public Laerer LaererObj { get; set; }
        public Kursus KursusObj { get; set; }
    }
}
