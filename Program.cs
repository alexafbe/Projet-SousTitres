using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSousTitres
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            SynchroST syncst = new SynchroST();
            syncst.AfficherSousTitresEnConsole();
            Task.WaitAll(syncst.ShowSubtitles());
            Console.ReadKey();
        }
    }
}
