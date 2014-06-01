using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrarySkema.ModelLayer;

namespace ClassLibrarySkema
{
    public class ExceptionSchemaPlanning : Exception
    {
        public Kursus kursusObj { get; set; }

        public ExceptionSchemaPlanning(Kursus input)
        {
            this.kursusObj = input;
        }

    }
}
