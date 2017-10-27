using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ProjetSousTitres
{
    class SynchroST
    {
        List<Subtitles> subt = new List<Subtitles>();

        public void AfficherSousTitresEnConsole()
        {

            Regex StartEnd = new Regex(@"\d\d:\d\d:\d\d,\d\d\d");
            Regex SubtitleTxt = new Regex(@"^(\D).+");
            string FilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string text = "";
            TimeSpan start, stop, waiting;

            try
            {
                using (StreamReader ReadExistingFile = new StreamReader(FilePath + @"/subtitles.txt"))
                {
                    string line;

                    while ((line = ReadExistingFile.ReadLine()) != null)
                    {
                        if (line == "")
                        {
                            subt.Add(new Subtitles(text, start, stop, waiting));
                        }
                        if (StartEnd.Match(line).Success)
                        {
                            string[] time = line.Split(' ');
                            start = TimeSpan.Parse(time[0]);
                            stop = TimeSpan.Parse(time[2]);
                            waiting = TimeSpan.Parse(time[2]) - TimeSpan.Parse(time[0]);
                        }
                        if (SubtitleTxt.Match(line).Success)
                        {
                            text = line;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public async Task ShowSubtitles()
        {
            TimeSpan previous = new TimeSpan();

            await Task.Delay(subt[0].start);
            Console.WriteLine(subt[0].sbutitle);
            await Task.Delay(subt[0].waiting);
            Console.Clear();

            for (int showsub = 1; showsub < subt.Count(); showsub++)
            {
                previous = subt[showsub - 1].stop;

                await Task.Delay(subt[showsub].start - previous);
                Console.WriteLine(subt[showsub].sbutitle);
                await Task.Delay(subt[showsub].waiting);
                Console.Clear();
            }
        }
    }
}