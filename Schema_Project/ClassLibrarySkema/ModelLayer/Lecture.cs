using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Lecture
    {
        public int WeekNumber { get; set; }
        public string DateInfo { get; set; }
        public string TimeInfo { get; set; }
        public Hold HoldObj { get; set; }
        public Laerer LaererObj { get; set; }
        public Kursus KursusObj { get; set; }
        public Lokale LokaleObj { get; set; }

        public override string ToString()
        {
            return 
                "Week: " + WeekNumber.ToString() + Environment.NewLine +
                "Date:" + DateInfo + Environment.NewLine +
                "Time:" + TimeInfo + Environment.NewLine +
                "HoldID:" + HoldObj.HoldCode + Environment.NewLine +
                "LærerID:" + LaererObj.LaererKode + Environment.NewLine +
                "KursusID:" + KursusObj.KursusKode + Environment.NewLine +
                "LokaleID:" + LokaleObj.LokaleKode + Environment.NewLine +
                "*****************************";    
        }




    }
}
