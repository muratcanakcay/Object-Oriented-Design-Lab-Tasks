using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Xml.Console
{
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            string libraryPath = Directory.GetCurrentDirectory() + "\\tortoise_s.xml";

            var formulaT = LibraryReader.ReadLibrary(libraryPath);
            if (formulaT == null) return;

            var participants = new Dictionary<string, string>();
            var tracks = new Dictionary<string, string>();

            foreach (var item in formulaT.Items)
            {
                if (item is Library.trackType)
                {
                    var t = (Library.trackType)(item);
                    WriteLine($"({t.id}, {t.name}) added to tracks.");
                    tracks.Add(t.id, t.name);
                }
            }

            WriteLine();
            foreach (var s in formulaT.participants.snail)
            {
                WriteLine($"Snail ({s.startNumber}, {s.nick}) added to participants.");
                participants.Add(s.startNumber, s.nick);
            }

            WriteLine();
            foreach (var t in formulaT.participants.tortoise)
            {
                WriteLine($"Tortoise ({t.startNumber}, {t.nick}) added to participants.");
                participants.Add(t.startNumber, t.nick);
            }
            
            WriteLine();
            foreach (var item in formulaT.Items)
            { 
                if (item is Library.eventType)
                {
                    var e = (Library.eventType)(item);
                   
                    Write($"Event in {tracks[e.track.id]}  Participants: ");
                    
                    foreach (var p in e.participant.ToArray())
                        Write($"{participants[p.id]},  ");
                    
                    WriteLine();
                }
            }
        }
    }
}
