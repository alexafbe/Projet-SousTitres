using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSousTitres
{
    class Subtitles
    {
        public TimeSpan start;
        public TimeSpan stop;
        public TimeSpan waiting;
        public string sbutitle;

        public Subtitles(string sbutitle, TimeSpan start, TimeSpan stop, TimeSpan waiting)
        {
            this.sbutitle = sbutitle;
            this.start = start;
            this.stop = stop;
            this.waiting = waiting;
        }
    }
}
