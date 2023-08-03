using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_2_MusicEquipment.MusicInstruments
{
    internal class Ukulele : MusicInstrument
    {
        public Ukulele() : base("Ukulele",
            "Hornbostel–Sachs classification: 321.322 (Composite chordophone)",
            "C4–A5 (C6 tuning)",
            "Developed in the 1880s, the ukulele is based on several small, guitar-like instruments of Portuguese origin.")
        {
        }
    }
}
