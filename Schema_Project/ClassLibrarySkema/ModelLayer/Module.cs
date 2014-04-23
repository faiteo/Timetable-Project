using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Module
    {
        public Kursus KursusObj { get; set; }
        public int ModuleNumber { get; set; }

        public override string ToString()
        {
            return string.Format("Module - Number: {0}, Kursus: {1}", ModuleNumber, KursusObj.KursusKode);
        }
    }
}
